using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System;

public class CsvReadWrite : Singleton<CsvReadWrite>
{

    public List<string[]> rowDataScore = new List<string[]>();
    
    string folderPathScore;
    string filePath_Score;


    // Use this for initialization
    void Start()
    {
        folderPathScore = getPath();
        
        filePath_Score = folderPathScore + "Score.csv";
       
        StartCoroutine(CreateOrEditScore("Name","CaseAScore","CaseBScore","CaseCScore"));
        
    }

    public void SaveScore(string name,string caseAScore, string caseBScore, string caseCScore)
    {
        StartCoroutine(CreateOrEditScore(name,caseAScore, caseBScore, caseCScore));
    }

    
    /// <summary>
    /// If file exist edit the data or if not create a new file
    /// </summary>
    /// <returns></returns>
    IEnumerator CreateOrEditScore(string pname,string caseAScore,string caseBScore,string caseCScore)
    {

        // Creating First row of titles manually..
        string[] rowDataTemp = new string[4];
        rowDataTemp[0] = pname;
        rowDataTemp[1] = caseAScore;
        rowDataTemp[2] = caseBScore;
        rowDataTemp[3] = caseCScore;
        


        
        if (!Directory.Exists(folderPathScore))
        {
            //Debugger.instance.AddLog("dIRECTORY nOT EXIST");
            rowDataScore.Add(rowDataTemp);
            Directory.CreateDirectory(folderPathScore);
            while (!Directory.Exists(folderPathScore))
            {
                yield return null;
            }

            string[][] output = new string[rowDataScore.Count][];

            for (int i = 0; i < output.Length; i++)
            {
                output[i] = rowDataScore[i];
            }

            int length = output.GetLength(0);
            string delimiter = ",";

            StringBuilder sb = new StringBuilder();

            for (int index = 0; index < length; index++)
                sb.AppendLine(string.Join(delimiter, output[index]));

            StreamWriter outStream = System.IO.File.CreateText(filePath_Score);
            outStream.WriteLine(sb);
            outStream.Close();

        }
        else
        {
            //Debugger.instance.AddLog("dIRECTORY EXIST");

            rowDataScore.Clear();
            string[] lines = File.ReadAllLines(filePath_Score);
            foreach(string line in lines)
            {
                if(line.Contains(","))
                {
                    string[] filed = line.Split(',');
                    rowDataScore.Add(filed);
                    //print(filed[0]);
                }
            }
            //print(rowDataScore.Count);
            bool alreayexist = false;
            for (int i = 0; i < rowDataScore.Count; i++)
            {
                string[] row = rowDataScore[i];
                if(row[0]==pname)
                {
                    row[1] = caseAScore;
                    row[2] = caseBScore;
                    row[3] = caseCScore;
                    rowDataScore[i] = row;
                    alreayexist = true;

                }
            }
            if(!alreayexist)
                rowDataScore.Add(rowDataTemp);
            
            string[][] output = new string[rowDataScore.Count][];

            for (int i = 0; i < output.Length; i++)
            {
                output[i] = rowDataScore[i];
            }

            int length = output.GetLength(0);
            string delimiter = ",";

            StringBuilder sb = new StringBuilder();

            for (int index = 0; index < length; index++)
                sb.AppendLine(string.Join(delimiter, output[index]));

            StreamWriter myStream = new StreamWriter(filePath_Score, false);
            myStream.Write(sb);
            myStream.Close();

        }
        yield return new WaitForEndOfFrame();

    }

   

    // Following method is used to retrive the relative path as device platform
    private string getPath()
    {
        
#if UNITY_EDITOR
            return Application.dataPath + "/CSV_Score/";
#elif UNITY_ANDROID
        return Application.persistentDataPath + "/CSV_Score/";
#elif UNITY_IPHONE
        return Application.persistentDataPath+"/"+"Saved_data.csv";
#else
        return Application.dataPath +"/"+"Saved_data.csv";
#endif
        
        
       

    }
}

