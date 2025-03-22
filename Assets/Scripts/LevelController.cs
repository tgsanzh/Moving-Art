using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    private int currentLevel;
    [SerializeField] private Text[] levelText;
    [SerializeField] private Image[] levelBackground;
    [SerializeField] private Color green, yellow, red;
    void Start()
    {
        int start = 0;
        currentLevel = PlayerPrefs.GetInt("level", 0) + 1;
        if (currentLevel % 5 != 0)
        {
            start = (currentLevel - currentLevel % 5) + 1;
        }
        else
        {
            start = currentLevel - 4;
        }
        for(int i = 0; i < levelText.Length; i++)
        {
            levelText[i].text = (start + i).ToString();
            if(start + i < currentLevel)
            {
                levelBackground[i].color = green;
            }
            else if(start + i == currentLevel)
            {
                levelBackground[i].color = yellow;
                levelBackground[i].transform.localScale = new Vector3(1.2f, 1.2f, 1);
                levelText[i].color = Color.black;
            }
            else
            {
                levelBackground[i].color = red;
            }
        }
    }

}
