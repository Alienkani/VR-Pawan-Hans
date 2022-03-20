using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionOne_Scene : MonoBehaviour
{
    OptionOne_States currentState;
    [SerializeField]
    Steps[] steps;
    [SerializeField]
    GameObject CameraRig,Scoreboard,Helicopter;
    bool voicOverEnd;
    [SerializeField]
    Button[] hotspots;
    [SerializeField]
    Animator anim;
    //int sceneIndex;
    
    // Start is called before the first frame update
    void Start()
    {
        //ManageState(OptionOne_States.Step1);
        foreach (var spot in hotspots)
        {
            spot.gameObject.SetActive(false);
        }
        StartCoroutine(DoAction(steps[0]));

    }

 

  

    IEnumerator DoAction(Steps step)
    {
        
        switch (step.actionType)
        {
            case ActionTypes.Step1:
                {
                    voicOverEnd = false;
                    WhiteScreen.instance.FadeIn(1f);
                    CameraRig.transform.position = step.target.position;
                    CameraRig.transform.rotation = step.target.rotation;

                    yield return new WaitForSeconds(1);
                    WhiteScreen.instance.FadeOut(1f);
                    yield return new WaitForSeconds(2);

                    /// Intro VO play and wait
                    SoundManager.instance.PlayVO(Response, step.vO[0], true);
                    while (!voicOverEnd)
                    {
                        yield return null;

                    }
                    yield return new WaitForSeconds(2f);
                    // Click hotspot play

                    // play Last next Vo
                    voicOverEnd = false;
                    SoundManager.instance.PlayVO(Response, step.vO[1], true);
                    while (!voicOverEnd)
                    {
                        yield return null;

                    }
                    foreach (var spot in hotspots)
                    {
                        spot.gameObject.SetActive(false);
                    }
                    hotspots[0].interactable = true;
                    hotspots[0].gameObject.SetActive(true);

                    // Click hotspot play

                    yield return new WaitForEndOfFrame();



                    break;
                }
           
           
            case ActionTypes.Step2:
                {
                    voicOverEnd = false;
                    WhiteScreen.instance.FadeIn(1f);
                    yield return new WaitForSeconds(2);
                    CameraRig.transform.position = step.target.position;
                    CameraRig.transform.rotation = step.target.rotation;
                    //CameraRig.transform.parent = Helicopter.transform;

                    yield return new WaitForSeconds(1);
                    WhiteScreen.instance.FadeOut(1f);
                    yield return new WaitForSeconds(2f);
                    SoundManager.instance.PlayVO(Response, step.vO[0], true);
                    while (!voicOverEnd)
                    {
                        yield return null;

                    }

                    yield return new WaitForSeconds(2f);

                    // Play next VO
                    voicOverEnd = false;
                    SoundManager.instance.PlayVO(Response, step.vO[1], true);
                    while (!voicOverEnd)
                    {
                        yield return null;

                    }
                    foreach (var spot in hotspots)
                    {
                        spot.gameObject.SetActive(false);
                    }
                    hotspots[1].interactable = true;
                    hotspots[1].gameObject.SetActive(true);
                    yield return new WaitForEndOfFrame();

                    break;
                }
            

            case ActionTypes.Step3:
                {
                    voicOverEnd = false;
                   
                    SoundManager.instance.PlayVO(Response, step.vO[0], true);
                    while (!voicOverEnd)
                    {
                        yield return null;

                    }
                    yield return new WaitForSeconds(2f);
                    /////////////////////////////
                    //voicOverEnd = false;
                    ////WhiteScreen.instance.FadeIn(1f);

                    ///// Intro VO play and wait
                    //SoundManager.instance.PlayVO(Response, step.vO[1], true);
                    //while (!voicOverEnd)
                    //{
                    //    yield return null;

                    //}
                    foreach (var spot in hotspots)
                    {
                        spot.gameObject.SetActive(false);
                    }
                    hotspots[2].interactable = true;
                    hotspots[2].gameObject.SetActive(true);

                    yield return new WaitForEndOfFrame();


                    break;
                }
            case ActionTypes.Step4:
                {
                    voicOverEnd = false;
                    SoundManager.instance.PlayVO(Response, step.vO[0], true);
                    while (!voicOverEnd)
                    {
                        yield return null;

                    }
                    yield return new WaitForSeconds(2f);
                    ///////////////////////////////////

                    //voicOverEnd = false;
                    ////WhiteScreen.instance.FadeIn(1f);

                    ///// Intro VO play and wait
                    //SoundManager.instance.PlayVO(Response, step.vO[1], true);
                    //while (!voicOverEnd)
                    //{
                    //    yield return null;

                    //}
                    yield return new WaitForSeconds(1);

                    WhiteScreen.instance.FadeIn(1f);
                    yield return new WaitForSeconds(2);
                    CameraRig.transform.position = step.target.position;
                    CameraRig.transform.rotation = step.target.rotation;
                    CameraRig.transform.parent = null;

                    yield return new WaitForSeconds(1);
                    WhiteScreen.instance.FadeOut(1f);
                    yield return new WaitForSeconds(1f);
                    Invoke("WaitAndHit", 3f);
                    


                    break;
                }
            case ActionTypes.Step5:
                {

                    voicOverEnd = false;

                    SoundManager.instance.PlayVO(Response, step.vO[0], true);
                    while (!voicOverEnd)
                    {
                        yield return null;

                    }


                    foreach (var spot in hotspots)
                    {
                        spot.gameObject.SetActive(false);
                    }
                    hotspots[3].interactable = true;
                    hotspots[3].gameObject.SetActive(true);

                    yield return new WaitForEndOfFrame();


                    break;
                }
           
            case ActionTypes.Step6:
                {
                    Scoreboard.SetActive(true);
                    voicOverEnd = false;

                    SoundManager.instance.PlayVO(Response, step.vO[0], true);
                    while (!voicOverEnd)
                    {
                        yield return null;

                    }
                    yield return new WaitForEndOfFrame();
                    break;
                }
        }
        yield return new WaitForEndOfFrame();

    }
    void Response(bool isvoEnd)
    {
        Debug.Log("Is wait for VO end " + isvoEnd);
        voicOverEnd = true;
    }


    public void OnClick(int index)
    {
        StartCoroutine(OnClickHotspot(index));
    }
    IEnumerator OnClickHotspot(int index)
    {
        if (index == 0)
        {
            anim.SetTrigger("Step1");
            while(!anim.GetCurrentAnimatorStateInfo(0).IsName("CarGo_Load_Idle"))
            {
                yield return new WaitForSeconds(0.1f);
               
            }
            yield return new WaitForSeconds(3f);
            StartCoroutine(DoAction(steps[1]));
        }
        if(index==1)
        {
            WhiteScreen.instance.FadeIn(1f);
            yield return new WaitForSeconds(2);
            CameraRig.transform.position = steps[2].target.position;
            CameraRig.transform.rotation = steps[2].target.rotation;
            CameraRig.transform.parent = Helicopter.transform;

            yield return new WaitForSeconds(1);
            WhiteScreen.instance.FadeOut(1f);
            yield return new WaitForSeconds(2f);
            anim.SetTrigger("Step2");
            yield return new WaitForSeconds(8f);
            voicOverEnd = false;
            //WhiteScreen.instance.FadeIn(1f);

            /// Intro VO play and wait
            SoundManager.instance.PlayVO(Response, steps[1].vO[2], true);
            while (!voicOverEnd)
            {
                yield return null;

            }

            while (!anim.GetCurrentAnimatorStateInfo(0).IsName("Travel_Idle"))
            {
                yield return new WaitForSeconds(0.1f);

            }
            yield return new WaitForSeconds(3f);
            StartCoroutine(DoAction(steps[2]));
        }
        if (index == 2)
        {
            anim.SetTrigger("Step3");
            while (!anim.GetCurrentAnimatorStateInfo(0).IsName("Land_Idle"))
            {
                yield return new WaitForSeconds(0.1f);

            }
            yield return new WaitForSeconds(3f);
            StartCoroutine(DoAction(steps[3]));
        }
       

        if (index == 3)
        {
            anim.SetTrigger("Step4");
            while (!anim.GetCurrentAnimatorStateInfo(0).IsName("CarGo_Unload_Idle"))
            {
                yield return new WaitForSeconds(0.1f);

            }
            yield return new WaitForSeconds(3f);
            StartCoroutine(DoAction(steps[5]));
        }


    }
   


    void WaitAndHit()
    {
        StartCoroutine(DoAction(steps[4]));
    }
    public void OnBack()
    {
        SceneSwitchManager.instance.SwitchScene(1);
    }
    
}
