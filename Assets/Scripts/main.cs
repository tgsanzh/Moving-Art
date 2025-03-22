using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class main : MonoBehaviour
{
    [SerializeField] private GameObject skipLevel;

    private float _startAspect = 1179f / 2556f;

    private float _defaultHeight;
    private float _defaultWidth;

    [SerializeField] private Movement movement;
    private void Awake()
    {
        Camera.main.orthographicSize = 1.2125f * movement.pixels;
        _defaultHeight = Camera.main.orthographicSize;
        _defaultWidth = Camera.main.orthographicSize * _startAspect;

        Camera.main.orthographicSize = _defaultWidth / Camera.main.aspect;
    }
    private void Start()
    {
        StartCoroutine(skipLevelWait());
        c = StartCoroutine(wait());
    }
    private IEnumerator skipLevelWait()
    {
        yield return new WaitForSeconds(30);
        skipLevel.SetActive(true);
    }
    [SerializeField] private GameObject ads;
    [SerializeField] private GameObject showTimer;
    bool can = true;
    Coroutine c;
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            StopCoroutine(c);
            showTimer.SetActive(false);
            c = StartCoroutine(wait());

        }
    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(11);
        showTimer.SetActive(true);
        showTimer.transform.GetChild(0).GetComponent<Text>().text = "3";
        yield return new WaitForSeconds(1);
        showTimer.SetActive(true);
        showTimer.transform.GetChild(0).GetComponent<Text>().text = "2";
        yield return new WaitForSeconds(1);
        showTimer.SetActive(true);
        showTimer.transform.GetChild(0).GetComponent<Text>().text = "1";
        yield return new WaitForSeconds(1);
        showTimer.SetActive(false);
        ads.GetComponent<InterstitialAdExample>().ShowAd();
    }
}
