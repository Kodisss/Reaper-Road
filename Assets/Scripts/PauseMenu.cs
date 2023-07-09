using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    private bool isPaused;

    // Start is called before the first frame update
    private void Start()
    {
        pauseMenu.SetActive(false);
        isPaused = false;
    }

    public bool GetPaused()
    {
        return isPaused;
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        GameManager.instance.score = 0;
        SceneManager.LoadScene("Game");
    }

    private void OnPause(InputValue value)
    {
        if (isPaused)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }

    private void OnUnpause(InputValue value)
    {
        if(isPaused) ResumeGame();
    }
}
