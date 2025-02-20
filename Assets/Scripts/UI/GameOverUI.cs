using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : BaseUI
{
    [SerializeField] private Button restartButton;
    [SerializeField] private Button exitButton;
    
    SceneManager sceneManager;
    public void Start()
    {
        sceneManager = SceneManager.instance;
    }

    public override void Init(UIManager uiManager)
    {
        base.Init(uiManager);
        restartButton.onClick.AddListener(OnClickRestartButton);
        exitButton.onClick.AddListener(OnClickExitButton);
    }
    
    public void OnClickRestartButton()
    {
        MiniGameManager.instance.RestartGame();
    }

    public void OnClickExitButton()
    {
        sceneManager.StartMiniGame(0);
    }

    protected override UIState GetUIState()
    {
        return UIState.GameOver;
    }
}