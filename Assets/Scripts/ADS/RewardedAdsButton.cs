using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;

public class RewardedAdsButton : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    [SerializeField] string bonusID = "Bonus";
    [SerializeField] string skipID = "Skip";
    [SerializeField] string iqID = "IQ";
    [SerializeField] string _iOSAdUnitId = "Rewarded_iOS";

    void Awake()
    {
        // Get the Ad Unit ID for the current platform:


        // Disable the button until the ad is ready to show:
    }

    // Call this public method when you want to get an ad ready to show.
    public void LoadAd()
    {
        // IMPORTANT! Only load content AFTER initialization (in this example, initialization is handled in a different script).
        Advertisement.Load(bonusID, this);
        Advertisement.Load(skipID, this);
        Advertisement.Load(iqID, this);
    }

    // If the ad successfully loads, add a listener to the button and enable it:
    public void OnUnityAdsAdLoaded(string adUnitId)
    {

    }

    // Implement a method to execute when the user clicks the button:
    public void ShowAdBonus()
    {
        // Then show the ad:
        Advertisement.Show(bonusID, this);
    }
    public void ShowAdSkip()
    {
        // Then show the ad:
        Advertisement.Show(skipID, this);
    }
    public void ShowAdIQ()
    {
        // Then show the ad:
        Advertisement.Show(iqID, this);
    }

    // Implement the Show Listener's OnUnityAdsShowComplete callback method to determine if the user gets a reward:
    [SerializeField] private GameObject btnGet;
    [SerializeField] private Systems systems;
    public void OnUnityAdsShowComplete(string adUnitId, UnityAdsShowCompletionState showCompletionState)
    {
        if (adUnitId.Equals(bonusID) && showCompletionState.Equals(UnityAdsShowCompletionState.COMPLETED))
        {
            Debug.Log("BONUS");

        }
        else if (adUnitId.Equals(skipID) && showCompletionState.Equals(UnityAdsShowCompletionState.COMPLETED))
        {
            PlayerPrefs.SetInt("level", PlayerPrefs.GetInt("level", 0) + 1);
            PlayerPrefs.SetInt("IQ", PlayerPrefs.GetInt("IQ", 0) + 10);
            if (PlayerPrefs.GetInt("IQ", 0) >= 100)
            {
                PlayerPrefs.SetInt("IQ", 0);

            }
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            print("ASD");
        }
        /*else if (adUnitId.Equals(iqID) && showCompletionState.Equals(UnityAdsShowCompletionState.COMPLETED))
        {
            btnGet.SetActive(false);
            StartCoroutine(systems.IQSystem(PlayerPrefs.GetInt("IQ", 0), 20));
        }*/
    }

    // Implement Load and Show Listener error callbacks:
    public void OnUnityAdsFailedToLoad(string adUnitId, UnityAdsLoadError error, string message)
    {
        // Use the error details to determine whether to try to load another ad.
    }

    public void OnUnityAdsShowFailure(string adUnitId, UnityAdsShowError error, string message)
    {
        // Use the error details to determine whether to try to load another ad.
    }

    public void OnUnityAdsShowStart(string adUnitId) {
        LoadAd();
    }
    public void OnUnityAdsShowClick(string adUnitId) { }

 
}