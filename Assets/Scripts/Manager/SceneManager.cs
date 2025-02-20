using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SceneManager : MonoBehaviour
{
    public static SceneManager instance;
    
    private bool isPlayerNear = false; 
    public float detectionRange = 2f;  // 플레이어와의 거리 범위 설정
    public GameObject player;  // 플레이어 오브젝트
    public TextMeshProUGUI infoText;
    public Vector3 offset = new Vector3(0.7f, 0.7f, 0);
    public int miniGameID;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    
    private void Update()
    {
        if (player != null)
        {
            // 플레이어와의 거리 계산
            float distance = Vector3.Distance(player.transform.position, transform.position);
            // 일정 범위 내에 들어오면 이벤트 발생
            if (distance <= detectionRange)
            {
                if (!isPlayerNear) // 처음으로 근처에 들어왔을 때만 이벤트 발생
                {
                    isPlayerNear = true;
                    OnPlayerNear();
                }
            }
            else
            {
                if (isPlayerNear) // 플레이어가 범위를 벗어나면 상태 리셋
                {
                    isPlayerNear = false;
                    OnPlayerAway();
                }
            }
        }

        // E 버튼이 눌렸을 때 동작 수행
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E))
        {
            OnInteract();
        }
    }

    void OnPlayerNear()
    {
        // UI 텍스트 띄우기
        if (infoText != null)
        {
            infoText.gameObject.SetActive(true);
            infoText.text = "Press 'E' to interact";
            
            // 오브젝트 위치에 맞춰 UI 텍스트 위치 조정
            Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position + offset); 
            infoText.transform.position = screenPos;
        }
        else
        {
            Debug.Log(infoText + "가 없습니다.");
        }
    }

    void OnPlayerAway()
    {
        // 플레이어가 범위를 벗어났을 때 UI 텍스트 숨기기
        if (infoText != null)
        {
            infoText.gameObject.SetActive(false);
        }
    }

    void OnInteract()
    {
        // GameManager와 miniGameID가 올바르게 참조되었는지 확인
        if (GameManager.instance != null)
        {
            Debug.Log("E 버튼을 눌러서 미니게임을 시작합니다!");
            StartMiniGame(miniGameID);
        }
        else
        {
            Debug.LogError("GameManager 인스턴스가 없습니다.");
        }

    }
    
    
    public void StartMiniGame(int miniGameID)
    {
        Debug.Log("미니게임 " + miniGameID + "를 시작합니다!");
        // 미니게임 ID에 따라 다른 씬을 로드
        switch (miniGameID)
        {
            case 0:
                UnityEngine.SceneManagement.SceneManager.LoadScene("MainScene");
                break;
            case 1:
                UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
                break;
            case 2:
                UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene2");
                break;
            default:
                UnityEngine.SceneManagement.SceneManager.LoadScene("MainScene");
                break;
        }
    }
    
}
