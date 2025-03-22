using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop_Controller : MonoBehaviour
{
    [SerializeField] private GameObject[] lockedSkin;
    [SerializeField] private GameObject[] unlockedSkin;

    [SerializeField] private GameObject[] lockedBackground;
    [SerializeField] private GameObject[] unlockedBackground;

    [SerializeField] private GameObject[] lockedBackgroundSkin;
    [SerializeField] private GameObject[] unlockedBackgroundSkin;

    private void OnEnable()
    {
        int[] target = {5, 10, 15, 20, 25, 30, 35, 40, 45 };
        for (int i = 0; i < lockedSkin.Length; i++)
        {
            if(PlayerPrefs.GetInt("level", 0) >= target[i] - 1)
            {
                lockedSkin[i].SetActive(false);
                unlockedSkin[i].SetActive(true);

                lockedBackground[i].SetActive(false);
                unlockedBackground[i].SetActive(true);

                lockedBackgroundSkin[i].SetActive(false);
                unlockedBackgroundSkin[i].SetActive(true);
            }
            else
            {
                lockedSkin[i].SetActive(true);
                unlockedSkin[i].SetActive(false);

                lockedBackground[i].SetActive(true);
                unlockedBackground[i].SetActive(false);

                lockedBackgroundSkin[i].SetActive(true);
                unlockedBackgroundSkin[i].SetActive(false);
            }
        }
        
    }
}
