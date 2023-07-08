using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public event Action startGame, endGame, boostActivated;

    public bool isPlaying = false;

    private void Awake()
    {
        instance = this;
    }

    private void OnStart()
    {
        if (!isPlaying)
        {
            isPlaying = true;
            StartGame();
        }
    }

    public void StartGame()
    {
        startGame?.Invoke();
    }

    public void EndGame()
    {
        endGame?.Invoke();
    }

    public void BoostPhantom()
    {
        boostActivated?.Invoke();
    }
}
