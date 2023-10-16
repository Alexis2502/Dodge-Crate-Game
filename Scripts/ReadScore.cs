using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TMPro;
using UnityEngine;

public class ReadScore : MonoBehaviour
{
    public TextMeshProUGUI score;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        string fileDir = "D:/Games/2D Android Game/Saves/Leaderboard.txt";
        int highestScore;
        using (FileStream filestream = new FileStream(fileDir, FileMode.Open, FileAccess.Read))
        {
            using (StreamReader sr = new StreamReader(filestream))
            {
                highestScore = sr.Read()-48;
                sr.Close();
            }
        }
        score.text = highestScore.ToString();
    }
}
