using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewHighScore : MonoBehaviour
{
    public TextMeshProUGUI score;
    int scoreInt;
    // Start is called before the first frame update
    void Start()
    {
        string fileDir = "D:/Games/2D Android Game/Saves/Leaderboard.txt";
        using (FileStream filestream = new FileStream(fileDir, FileMode.Open, FileAccess.ReadWrite))
        {
            using (StreamReader sr = new StreamReader(filestream))
            {
                scoreInt = sr.Read()-48;
                sr.Close();
            }
        }
        score.text = scoreInt.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            SceneManager.LoadScene("Start");
        }
    }
}
