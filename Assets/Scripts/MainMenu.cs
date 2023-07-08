using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Windows;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("PrototypeMainLevel");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
