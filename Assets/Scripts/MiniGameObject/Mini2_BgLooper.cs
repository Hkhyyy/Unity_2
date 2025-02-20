using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mini2_BgLooper : MonoBehaviour
{
    public int numBgCount = 5;
    
    public int obstacleCount = 0;
    public Vector3 obstacleLastPosition  = Vector3.zero;
    
    void Start()
    {
        Mini2_Obstacle[] obstacles = GameObject.FindObjectsOfType<Mini2_Obstacle>();
        obstacleLastPosition = obstacles[0].transform.position;
        obstacleCount = obstacles.Length;
        
        for(int i = 0; i < obstacleCount; i++)
        {
            obstacleLastPosition = obstacles[i].SetRandomPlace(obstacleLastPosition, obstacleCount);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BackGround"))
        {
            float widthOfBgObject = ((BoxCollider2D)collision).size.x;
            Vector3 pos = collision.transform.position;

            pos.x += widthOfBgObject * numBgCount;
            collision.transform.position = pos;
            return;
        }
        
        Mini2_Obstacle obstacle = collision.GetComponent<Mini2_Obstacle>();
        if (obstacle)
        {
            obstacleLastPosition = obstacle.SetRandomPlace(obstacleLastPosition, obstacleCount);
        }
    }
}

