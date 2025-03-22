using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Systems : MonoBehaviour
{
    [SerializeField] private List<GameObject> hits, colours, hideInWin = new List<GameObject>();
    [SerializeField] private GameObject[] winBlocks;
    [SerializeField] private GameObject levelCur, winScene, bonusScene;
    [SerializeField] private Text IQText;
    [SerializeField] private Animation animIQ;
    [SerializeField] private Movement movement;
    [SerializeField] private GameObject ads;
    private int pixels = 4;
    private void Start()
    {
        isWinFull();
    }
    public void isWinFull()
    {
        int i = 0;
        int right = 0;
        for (float y = 0; y > -4; y -= 1)
        {
            for (float x = -1.5f; x < 2; x += 1)
            {
                GameObject hit = Physics2D.Raycast(new Vector2(x, y), Vector2.zero, 1).collider.gameObject;
                if (hit.GetComponent<SpriteRenderer>().color == colours[i].GetComponent<SpriteRenderer>().color)
                {
                    right++;
                }
                i++;
                hits.Add(hit);

            }
        }
        levelCur.transform.localScale = new Vector2(pixels / (pixels * pixels) * right, 0.075f);
        levelCur.transform.position = new Vector2(-2 + pixels / (pixels * pixels) * right / 2f, 0.75f);
        if (right == pixels * pixels)
        {
            if ((PlayerPrefs.GetInt("level", 0) + 1) % 5 == 0)
            {
                bonusScene.SetActive(true);
            }
            else
            {
                winScene.SetActive(true);

            }



            PlayerPrefs.SetInt("level", PlayerPrefs.GetInt("level", 0) + 1);
            ads.GetComponent<InterstitialAdExample>().ShowAd();

            /*StartCoroutine(IQSystem(PlayerPrefs.GetInt("IQ", 0), 10));*/
            /*foreach (var item in hideInWin)
            {

                item.SetActive(false);
            }*/
            /*for (int j = 0; j < pixels * pixels; j++)
            {
                winBlocks[j].GetComponent<Image>().color = hits[j].GetComponent<SpriteRenderer>().color;
            }*/

        }
        hits.Clear();
    }

   /* public IEnumerator IQSystem(int percent, int needToAdd)
    {
        IQText.text = (percent) + "%";
        PlayerPrefs.SetInt("IQ", PlayerPrefs.GetInt("IQ", 0) + needToAdd);
        if (PlayerPrefs.GetInt("IQ", 0) >= 100)
        {
            PlayerPrefs.SetInt("IQ", 0);

        }
        yield return new WaitForSeconds(0.6f);
        for (int i = 1; i <= needToAdd; i++)
        {
            IQText.text = (percent + i) + "%";
            yield return new WaitForSeconds(0.05f);
            if (percent + i >= 100)
            {
                animIQ.Play();
                yield return new WaitForSeconds(1);
                for (int j = 1; j <= 100; j++)
                {
                    IQText.text = (100 - j) + "%";
                    yield return new WaitForSeconds(0.01f);
                }
                break;
            }
        }


    }*/
    public void winSceneAfterBonus()
    {
        bonusScene.SetActive(false);
        winScene.SetActive(true);
        
    }
}
