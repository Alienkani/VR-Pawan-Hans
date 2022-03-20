using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Landing_Screen : MonoBehaviour
{
    LandingScreen_States currentState;
    int sceneIndex;
    [SerializeField]
    GameObject optionPanel;
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
                    optionPanel.SetActive(true);
                    //introPanel.SetActive(true);
                    break;
                }
           
            
            case LandingScreen_States.SwitchScene:
                {
                    optionPanel.SetActive(false);
                    //introPanel.SetActive(false);
                    SceneSwitchManager.instance.SwitchScene(sceneIndex);
                    break;
                }
        }
    }

    

    

    public void OnOptionChoose(int index)
    {


        ManageState(LandingScreen_States.SwitchScene);
        sceneIndex = index;
        OnStateChange();
     
    }

    public void OnHover(GameObject obj)
    {
        LeanTween.scale(obj, new Vector3(1.1f, 1.1f, 1.1f), 0.2f);
    }
    public void OnExit(GameObject obj)
    {
        LeanTween.scale(obj, Vector3.one, 0.2f);
    }


}
