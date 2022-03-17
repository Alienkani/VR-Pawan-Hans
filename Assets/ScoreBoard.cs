using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreBoard : Singleton<ScoreBoard>
{
    [SerializeField]
    float avarageTime;// A average time user takes to explore all scenes
    [Space(20)]
    [SerializeField]
    TextMeshProUGUI scoretext;
    bool startTimer;
    float timeSpent;
    [SerializeField]
    string Prefs_Type;
    [SerializeField]
    GameObject scoreBoard;
    void Start()
    {
        timeSpent = 0;
        //startTimer = false;
        startTimer = true;
        if(scoreBoard)
        {
            scoreBoard.SetActive(false);
        }
    }
    

    void Update()
    {
        if(startTimer)
        {
            timeSpent += Time.deltaTime;
        }
    }

    public void CalculateScoreA()
    {
        Globals.Score = "0";

        if (PlayerPrefs.HasKey(Prefs_Type))
        {
            int playerCount = PlayerPrefs.GetInt(Prefs_Type);
            Debug.Log("Player Count is " + playerCount);
            playerCount++;
            Debug.Log("Player Count is " + playerCount);
                
            PlayerPrefs.SetInt(Prefs_Type, playerCount);
            Globals.name = "Player " + playerCount;



        }
        else
        {
            PlayerPrefs.SetInt(Prefs_Type, 1);
            Globals.name = "Player " + 1;
        }

        Globals.Score = Mathf.CeilToInt(timeSpent).ToString();

        CsvReadWrite.instance.SaveScore(Globals.name, Globals.Score);
    }

    public void CalculateScoreB()
    {
        Globals.Score = "0";

        if (PlayerPrefs.HasKey("B"))
        {
            int playerCount = PlayerPrefs.GetInt("B");
            PlayerPrefs.SetInt("B", playerCount++);
            Globals.name = "Player " + playerCount;



        }
        else
        {
            PlayerPrefs.SetInt("B", 1);
            Globals.name = "Player " + 1;
        }

        Globals.Score = Mathf.CeilToInt(timeSpent).ToString();

        CsvReadWrite.instance.SaveScore(Globals.name, Globals.Score);
    }
    public void CalculateScoreC()
    {
        Globals.Score = "0";

        if (PlayerPrefs.HasKey("C"))
        {
            int playerCount = PlayerPrefs.GetInt("C");
            PlayerPrefs.SetInt("C", playerCount++);
            Globals.name = "Player " + playerCount;



        }
        else
        {
            PlayerPrefs.SetInt("C", 1);
            Globals.name = "Player " + 1;
        }

        int timeTemp = Mathf.CeilToInt(timeSpent);
        if(timeTemp<=avarageTime)
        {
            Globals.Score = "1000";
        }
        else if (timeTemp <= avarageTime-100)
        {
            Globals.Score = "900";
        }
        else if (timeTemp <= avarageTime - 200)
        {
            Globals.Score = "800";
        }
        else if (timeTemp <= avarageTime - 300)
        {
            Globals.Score = "700";
        }
        else if (timeTemp <= avarageTime - 400)
        {
            Globals.Score = "600";
        }
        else if (timeTemp <= avarageTime - 500)
        {
            Globals.Score = "500";
        }
        else if (timeTemp <= avarageTime - 600)
        {
            Globals.Score = "400";
        }
        else
        {
            Globals.Score = "300";
        }
        CsvReadWrite.instance.SaveScore(Globals.name, Globals.Score);
        ShowScore(Globals.Score);
    }
    void ShowScore(string scoreTxt)
    {
        if(scoretext)
        {
            scoretext.text = scoreTxt;
        }
        if (scoreBoard)
        {
            scoreBoard.SetActive(true);
        }
    }
}
