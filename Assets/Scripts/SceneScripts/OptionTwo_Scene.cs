using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionTwo_Scene : MonoBehaviour
{
    OptionTwo_States currentState;
    //int sceneIndex;
    
    // Start is called before the first frame update
    void Start()
    {
        ManageState(OptionTwo_States.Idle);

    }

    // Update is called once per frame

    void ManageState(OptionTwo_States state)
    {
        currentState = state;
        Debug.Log("Current state changed to " + currentState);
    }

    void OnStateChange()
    {
        switch (currentState)
        {
            case OptionTwo_States.Idle:
                {
                    
                    break;
                }
            case OptionTwo_States.VoiceOver_One:
                {
                    
                    SoundManager.instance.PlayVO(Response, 0, true);
                    break;
                }
            
            case OptionTwo_States.SwitchScene:
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

        ManageState(OptionTwo_States.VoiceOver_One);
        OnStateChange();

    }

    public void OnBack()
    {
        ManageState(OptionTwo_States.SwitchScene);
        OnStateChange();
    }
}
