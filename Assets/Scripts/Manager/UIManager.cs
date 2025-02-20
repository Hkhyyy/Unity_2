using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum UIState
{
    Home,
    Game,
    GameOver
}

public class UIManager : MonoBehaviour
{
    public int miniGameIndex;
    
    HomeUI homeUI;
    GameUI gameUI;
    GameOverUI gameOverUI;
    
    private UIState currentState;

    private void Awake()
    {
        if (miniGameIndex == 1)
        {
            homeUI = GetComponentInChildren<HomeUI>(true);
            homeUI.Init(this);
            gameUI = GetComponentInChildren<GameUI>(true);
            gameUI.Init(this);
            gameOverUI = GetComponentInChildren<GameOverUI>(true);
            gameOverUI.Init(this);
        
            ChangeState(UIState.Home);
        }        
    }

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI restartText;

    public void Start()
    {
        if (restartText == null)
        {
            Debug.LogError("restart text is null");
        }
        
        if (scoreText == null)
        {
            Debug.LogError("scoreText is null");
            return;
        }
        
        restartText.gameObject.SetActive(false);
    }

    public void SetRestart()
    {
        restartText.gameObject.SetActive(true);
    }

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }
    
    public void SetPlayGame()
    {
        ChangeState(UIState.Game);
    }
    
    public void SetGameOver()
    {
        ChangeState(UIState.GameOver);
    }

    public void ChangeWave(int waveIndex)
    {
        gameUI.UpdateWaveText(waveIndex);
    }

    public void ChangePlayerHP(float currentHP, float maxHP)
    {
        gameUI.UpdateHPSlider(currentHP/ maxHP);
    }
    
    public void ChangeState(UIState state)
    {
        currentState = state;
        homeUI.SetActive(currentState);
        gameUI.SetActive(currentState);
        gameOverUI.SetActive(currentState);
    }
}