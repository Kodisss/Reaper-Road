using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Windows;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        GameManager.instance.isPlaying = true;
        GameManager.instance.score = 0;
        SceneManager.LoadScene("Game");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
