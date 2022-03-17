using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreBoard : MonoBehaviour
{
    [SerializeField]
    float avarageTime;// A average time user takes to explore all scenes
    [Space(20)]
    [SerializeField]
    TextMeshProUGUI scoretext;
    bool startTimer;
    float timeSpent;
    void Reset()
    {
        timeSpent = 0;
        startTimer = false;
    }
    public void StartTimer()
    {
        startTimer = true;
    }

    void Update()
    {
        if(startTimer)
        {
            timeSpent += Time.deltaTime;
        }
    }

    void CalculateScore()
    {
       
    }
    void ShowScore()
    {

    }
}
