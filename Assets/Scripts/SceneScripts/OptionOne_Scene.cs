using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionOne_Scene : MonoBehaviour
{
    OptionOne_States currentState;
    //int sceneIndex;
    
    // Start is called before the first frame update
    void Start()
    {
        ManageState(OptionOne_States.Idle);

    }

    // Update is called once per frame

    void ManageState(OptionOne_States state)
    {
        currentState = state;
        Debug.Log("Current state changed to " + currentState);
    }

    void OnStateChange()
    {
        switch (currentState)
        {
            case OptionOne_States.Idle:
                {
                    
                    break;
                }
            case OptionOne_States.VoiceOver_One:
                {
                    
                    SoundManager.instance.PlayVO(Response, 0, true);
                    break;
                }
            
            case OptionOne_States.SwitchScene:
                {
                    
                    SceneSwitchManager.instance.SwitchScene(0);
                    break;
                }
        }
    }

    void Response(bool isvoEnd)
    {
        Debug.Log("Is wait for VO end " + isvoEnd);
        //ManageState(LandingScreen_States.PanelOpen);
        OnStateChange();
    }

    public void OnContinue()
    {

        ManageState(OptionOne_States.VoiceOver_One);
        OnStateChange();

    }

    public void OnBack()
    {
        ManageState(OptionOne_States.SwitchScene);
        OnStateChange();
    }
}
