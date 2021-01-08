using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Obstacles Wave Config")]

public class WaveConfig : ScriptableObject
{
    //Obstacle Prefab to Spawn
    [SerializeField] GameObject obstaclePrefab;

    //Path Prefab on which to move
    [SerializeField] GameObject pathPrefab;

    //Obstacle Movement Speed
    [SerializeField] float ObstacleSpeed = 2f;

    //Number of ubstacles per wave
    [SerializeField] int numberOfObstacles = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject GetObstaclePrefab()
    {
        return obstaclePrefab;
    }

    public GameObject GetPathPrefab()
    {
        return pathPrefab;
    }

    public int GetNumberOfObstacles()
    {
        return numberOfObstacles;
    }

    public float GetObstacleSpeed()
    {
        return ObstacleSpeed;
    }


}
