using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class SceneChange : MonoBehaviour
{
    public void onHighScoreClick()
    {
        SceneManager.LoadScene("Leaderboard",LoadSceneMode.Single);
    }

    public void onPlayClick()
    {
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }

    public void onBackClick()
    {
        SceneManager.LoadScene("Start", LoadSceneMode.Single);
    }
}
