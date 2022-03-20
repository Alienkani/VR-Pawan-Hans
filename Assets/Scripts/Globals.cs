using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Globals
{
   
    public static string Score;
    public static string name;


}

enum LoginScreen_States
{
    Tutorial,
    Intro,
    SwitchScene
}


enum LandingScreen_States
{
    Idle,
    SwitchScene
}


enum OptionOne_States
{
    Step1,
    Step2,
    Step3,
    Step4,
    Step5,
    Step6,
    Step7
   
}
enum OptionTwo_States
{
    Idle,
    VoiceOver_One,
    SwitchScene

}
enum OptionThree_States
{
    Idle,
    VoiceOver_One,
    SwitchScene

}

[System.Serializable]
public class Steps
{
    public Transform target;
    public AudioClip[] vO;
    public string animBoolName;
    public ActionTypes actionType;
}
public enum ActionTypes
{
    Step1,
    Step2,
    Step3,
    Step4,
    Step5,
    Step6,
    Step7,
    Step8,
    Step9,
    Step10
}