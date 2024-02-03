using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Popup : MonoBehaviour
{

    [SerializeField]
    private TMPro.TextMeshProUGUI Cointext;
    public string Token = "YOUR_TOKEN";
    public string UserId = "YOUR_USER_ID";

    public Animator Animator;

    // Start is called before the first frame update
    void Start()
    {
        BitLabs.Init(Token, UserId);

        BitLabs.AddTag("userType", "new");
       

        BitLabs.SetRewardCallback(gameObject.name);

        Cointext.text = "0";
    }

  
    public void OnPopup()
    {

        if (Cointext.text == "10000")
        {

            loading();
        }
        else
        {
            Animator.SetTrigger("pop");

        }
    }


    public void ShowSurveys()
    {
        BitLabs.LaunchOfferWall();
    }

    public void RewardCallback(string payout)
    {
       /// no backend server available
       /// Cointext.text = payout;
        Cointext.text = "10000";
        Animator.SetTrigger("unpop");

    }

    void loading()
    {
        SceneManager.LoadScene("Level 200", LoadSceneMode.Single);
    }

    public void resetcoin()
    {
       Cointext.text = "0";
    }

    public void Quit()
    {
        Application.Quit();
    }
}
