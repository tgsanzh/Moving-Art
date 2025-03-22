using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class levelcreater : MonoBehaviour
{
    [SerializeField] private string[] levels;
    [SerializeField] private Text levelText;
    [SerializeField] private List<GameObject> colorsofx;
    [SerializeField] private GameObject[] colorsofblock;
    private void Awake()
    {
        levelText.text = levels[PlayerPrefs.GetInt("level", 0)].Split(":")[0].ToUpper();
        string[] colors = levels[PlayerPrefs.GetInt("level", 0)].Split(":")[1].Split("/");
        for (int i = 0; i < 16; i++)
        {
            colorsofx[i].GetComponent<SpriteRenderer>().color = new Color(float.Parse(colors[i].Split("-")[0]), float.Parse(colors[i].Split("-")[1])
                , float.Parse(colors[i].Split("-")[2]), float.Parse(colors[i].Split("-")[3]));
            
        }


        for (int i = 0; i < 16; i++)
        {
            int s = Random.Range(0, colorsofx.Count);
            colorsofblock[i].GetComponent<SpriteRenderer>().color = colorsofx[s].GetComponent<SpriteRenderer>().color;
            colorsofx.RemoveAt(s);

        }

    }
    public void level_next()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
