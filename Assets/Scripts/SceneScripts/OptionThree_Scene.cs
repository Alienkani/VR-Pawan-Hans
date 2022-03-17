using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionThree_Scene : MonoBehaviour
{
    OptionThree_States currentState;
    //int sceneIndex;

    // Start is called before the first frame update
    void Start()
    {
        ManageState(OptionThree_States.Idle);

    }

    // Update is called once per frame

    void ManageState(OptionThree_States state)
    {
        currentState = state;
        Debug.Log("Current state changed to " + currentState);
    }

    void OnStateChange()
    {
        switch (currentState)
        {
            case OptionThree_States.Idle:
                {

                    break;
                }
            case OptionThree_States.VoiceOver_One:
                {

                    SoundManager.instance.PlayVO(Response, 0, true);
                    break;
                }

            case OptionThree_States.SwitchScene:
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

        ManageState(OptionThree_States.VoiceOver_One);
        OnStateChange();

    }

    public void OnBack()
    {
        ManageState(OptionThree_States.SwitchScene);
        OnStateChange();
    }
}
