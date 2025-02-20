using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameManager : MonoBehaviour
{
    public static MiniGameManager instance;
    
    public int currentScore = 0;
    
    UIManager uiManager;

    public UIManager UIManager
    {
        get { return uiManager; }
    }
    
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        uiManager = FindObjectOfType<UIManager>();
    }
    
    private void Start()
    {
        uiManager.UpdateScore(0);
    }
    
    public void M2_GameOver()
    {
        Debug.Log("Game Over");
        uiManager.SetRestart();
    }
    
    public void RestartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }
    
    public void AddScore(int score)
    {
        currentScore += score;
        uiManager.UpdateScore(currentScore);
    }
}
