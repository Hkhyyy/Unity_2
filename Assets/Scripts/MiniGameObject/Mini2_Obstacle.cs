using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mini2_Obstacle : MonoBehaviour
{
    MiniGameManager gameManager;
    
    public float highPosY = 1f;
    public float lowPosY = -1f;

    public float holeSizeMin = 1f;
    public float holeSizeMax = 3f;

    public Transform topObject;
    public Transform bottomObject;

    public float widthPadding = 4f;

    public void Start()
    {
        gameManager = MiniGameManager.instance;
    }

    public Vector3 SetRandomPlace(Vector3 lastPosition, int obstacleCount)
    {
        float holeSize = Random.Range(holeSizeMin, holeSizeMax);
        float halfHoleSize = holeSize / 2f;
        topObject.localPosition = new Vector3(0, halfHoleSize);
        bottomObject.localPosition = new Vector3(0, -halfHoleSize);

        Vector3 placePosition = lastPosition + new Vector3(widthPadding, 0);
        placePosition.y = Random.Range(lowPosY, highPosY);
        
        transform.position = placePosition;
        
        return placePosition;
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        Mini2_player player = other.GetComponent<Mini2_player>();
        if(player != null)
            gameManager.AddScore(1);
    }
}
