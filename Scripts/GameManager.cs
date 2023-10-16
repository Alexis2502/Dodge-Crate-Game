using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject crate;
    public float maxX;
    public Transform spawnPoint;
    public float spawnRate;
    public GameObject tapText;
    public TextMeshProUGUI scoreText;
    bool gameStarted = false;
    int score = 0;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && gameStarted==false)
        {
            StartSpawning();
            gameStarted = true;
            tapText.SetActive(false);
        }        
    }

    private void StartSpawning()
    {
        InvokeRepeating("SpawnCrate", 0.5f, spawnRate);
    }

    private void SpawnCrate()
    {
        Vector3 spawnPos = spawnPoint.position;
        spawnPos.x = Random.Range(-maxX, maxX);

        Instantiate(crate, spawnPos, Quaternion.identity);
        score++;
        scoreText.text = score.ToString();
    }
}
