using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing.Text;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    Rigidbody2D rb;
    TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (touchPosition.x < 0)
            {
                rb.AddForce(Vector2.left * moveSpeed);
            }
            else
            {
                rb.AddForce(-Vector2.left * moveSpeed);
            }
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Crate")
        {
            SaveToLeaderboard();
        }
    }

    private void SaveToLeaderboard()
    {
        string fileDir = "D:/Games/2D Android Game/Saves/Leaderboard.txt";
        scoreText = GameObject.Find("GameManager").GetComponent<GameManager>().scoreText;
        int highestScore;
        using (FileStream filestream = new FileStream(fileDir, FileMode.OpenOrCreate, FileAccess.ReadWrite))
        {
            using(StreamReader sr = new StreamReader(filestream))
            {
                highestScore = Int16.Parse(sr.ReadLine());
                sr.Close();
            }
            if (highestScore < Int16.Parse(scoreText.text))
            {
                using (StreamWriter writer = File.CreateText(fileDir))
                {
                    writer.Write(scoreText.text);
                    writer.Close();
                }
                SceneManager.LoadScene("NewHighScore",LoadSceneMode.Single);
            }
            else
            {
                SceneManager.LoadScene("Start");
            }
        }
    }
}
