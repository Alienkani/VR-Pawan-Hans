using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginScreen : MonoBehaviour
{
    LoginScreen_States currentState;
    
    [SerializeField]GameObject PanelIntro,TutorialPanel;
    // Start is called before the first frame update
    void Start()
    {
        ManageState(LoginScreen_States.Tutorial);
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
            case LoginScreen_States.Tutorial:
                {
                    PanelIntro.SetActive(false);
                    
                    TutorialPanel.SetActive(true);
                    //SoundManager.instance.PlayVO(Response, 0, true);
                    break;
                }
            case LoginScreen_States.Intro:
                {
                    PanelIntro.SetActive(true);
                    
                    TutorialPanel.SetActive(false);
                    
                    break;
                }
            case LoginScreen_States.SwitchScene:
                {

                    SceneSwitchManager.instance.SwitchScene(1);
                    break;
                }
            
        }
    }

   public void OnTriggerPress()
    {
        ManageState(LoginScreen_States.Intro);
        OnStateChange();
    }

    public void OnContinue()
    {
       

        ManageState(LoginScreen_States.SwitchScene);
        OnStateChange();

    }


   
}
