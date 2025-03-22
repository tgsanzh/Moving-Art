using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFromScene : MonoBehaviour
{
    [SerializeField] private int level;
    [SerializeField] private GameObject gm;
    [SerializeField] private GameObject need;
    [SerializeField] private List<string> levels;
    void Start()
    {
        int hundred = level / 100;
        int ten = level / 10 % 10;
        print(hundred + ", " + ten + ", " + level % 10);
        print(gm.transform.GetChild(hundred).GetChild(ten).GetChild(level % 10));
        for(int h = 0; h < 10; h++) 
        {
            for (int t = 0; t < 10; t++)
            {
                for (int l = 0; l < 10; l++)
                {
                    print(h + ", " + t + ", " + l);
                    Transform current = gm.transform.GetChild(h).GetChild(t).GetChild(l % 10);
                    string add = current.name + ":";
                    for (int b = 0; b < 16; b++)
                    {
                        add += current.GetChild(b).GetComponent<SpriteRenderer>().color.r + "-";
                        add += current.GetChild(b).GetComponent<SpriteRenderer>().color.g + "-";
                        add += current.GetChild(b).GetComponent<SpriteRenderer>().color.b + "-";
                        add += current.GetChild(b).GetComponent<SpriteRenderer>().color.a + "/";
                    }
                    levels.Add(add);

                }
            }
        }
        need.name = levels[level].Split(":")[0].ToUpper();
        string[] colors = levels[level].Split(":")[1].Split("/");
        for (int i = 0; i < 16; i++)
        {
            need.transform.GetChild(i).GetComponent<SpriteRenderer>().color= new Color(float.Parse(colors[i].Split("-")[0]), float.Parse(colors[i].Split("-")[1])
                , float.Parse(colors[i].Split("-")[2]), float.Parse(colors[i].Split("-")[3]));
        }
        //Level_1:1-1-1-1/1-1-1-1/1-1-1-1/1-1-1-1/1-1-1-1/0-0-0-1/1-1-1-1/0-0-0-1/1-1-1-1/1-1-1-1/0-0-0-1/1-1-1-1/1-1-1-1/1-1-1-1/1-1-1-1/1-1-1-1/
    }

}
