using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Landing_Screen : MonoBehaviour
{
    LandingScreen_States currentState;
    int sceneIndex;
    [SerializeField]
    GameObject optionPanel,introPanel,LoginPanel;
    // Start is called before the first frame update
    void Start()
    {
        ManageState(LandingScreen_States.Idle);

    }

    // Update is called once per frame
   
    void ManageState(LandingScreen_States state)
    {
        currentState = state;
        Debug.Log("Current state changed to " + currentState);
    }

    void OnStateChange()
    {
        switch(currentState)
        {
            case LandingScreen_States.Idle:
                {
                    //SoundManager.instance.PlayVO(Response, 0, true);
                    optionPanel.SetActive(false);
                    introPanel.SetActive(true);
                    break;
                }
           
            case LandingScreen_States.PanelOpen:
                {
                    //SoundManager.instance.PlayVO(Response, 0, true);
                    optionPanel.SetActive(true);
                    introPanel.SetActive(false);
                    break;
                }
            case LandingScreen_States.SwitchScene:
                {
                    optionPanel.SetActive(false);
                    introPanel.SetActive(false);
                    SceneSwitchManager.instance.SwitchScene(sceneIndex);
                    break;
                }
        }
    }

    void Response(bool isvoEnd)
    {
        Debug.Log("Is wait for VO end " + isvoEnd);
        ManageState(LandingScreen_States.PanelOpen);
        OnStateChange();
    }

    public void OnContinue()
    {

        //ManageState(LandingScreen_States.VoiceOver_One);
        OnStateChange();

    }

    public void OnOptionChoose(int index)
    {


        ManageState(LandingScreen_States.SwitchScene);
        sceneIndex = index;
        OnStateChange();
    }
}
