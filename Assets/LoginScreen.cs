using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginScreen : MonoBehaviour
{
    LoginScreen_States currentState;
    [SerializeField]
    GameObject continueBtn;
    [SerializeField]GameObject PanelIntro;
    // Start is called before the first frame update
    void Start()
    {
        ManageState(LoginScreen_States.VoiceOver_Play);
        OnStateChange();

    }

    // Update is called once per frame

    void ManageState(LoginScreen_States state)
    {
        currentState = state;
        Debug.Log("Current state changed to " + currentState);
    }

    void OnStateChange()
    {
        switch (currentState)
        {
            case LoginScreen_States.VoiceOver_Play:
                {
                    PanelIntro.SetActive(true);
                    continueBtn.SetActive(false);
                    SoundManager.instance.PlayVO(Response, 0, true);
                    break;
                }
            case LoginScreen_States.VoiceOver_End:
                {

                    continueBtn.SetActive(true);
                    break;
                }
            case LoginScreen_States.SwitchScene:
                {
                    continueBtn.SetActive(false);
                    SceneSwitchManager.instance.SwitchScene(1);
                    break;
                }
        }
    }

    void Response(bool isvoEnd)
    {
        Debug.Log("Is wait for VO end " + isvoEnd);
        ManageState(LoginScreen_States.VoiceOver_End);
        OnStateChange();
    }

    public void OnContinue()
    {
       

        ManageState(LoginScreen_States.SwitchScene);
        OnStateChange();

    }


   
}
