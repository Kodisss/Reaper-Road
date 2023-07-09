using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public event Action startGame, endGame, boostActivated;

    public bool isPlaying = false;

    public int score = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            if (!isPlaying)
            {
                isPlaying = true;
            }
        }
        else
            Destroy(gameObject);
    }

    public void BoostPhantom()
    {
        boostActivated?.Invoke();
    }

    public void StartGame()
    {
        startGame?.Invoke();
    }

    public void EndGame()
    {
        endGame?.Invoke();
    }
}
