using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeUI : BaseUI
{
    [SerializeField] private Button startButton;
    [SerializeField] private Button exitButton;
    SceneManager sceneManager;
    public void Start()
    {
        sceneManager = SceneManager.instance;
    }
    public override void Init(UIManager uiManager)
    {
        base.Init(uiManager);
        startButton.onClick.AddListener(OnClickStartButton);
        exitButton.onClick.AddListener(OnClickExitButton);
    }
    
    public void OnClickStartButton()
    {
        GameManager.instance.StartGame();
    }

    public void OnClickExitButton()
    {
        sceneManager.StartMiniGame(0);        
    }
    
    protected override UIState GetUIState()
    {
        return UIState.Home;
    }
}