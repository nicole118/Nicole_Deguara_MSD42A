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

    //Number of obstacles per wave
    [SerializeField] int numberOfObstacles = 5;

    [SerializeField] float TimeBetweenSpawns = 4f;

    // Start is called before the first frame update

    public GameObject GetObstaclePrefab()
    {
        return obstaclePrefab;
    }

    public List<Transform> GetWaypoints()
    {
        var waves = new List<Transform>();

        //add each child that is in the pathPrefabs to the List waves
        foreach (Transform child in pathPrefab.transform)
        {
            waves.Add(child);
        }

        return waves;
    }


    public int GetNumberOfObstacles()
    {
        return numberOfObstacles;
    }

    public float GetObstacleSpeed()
    {
        return ObstacleSpeed;
    }

    public float GetTimeBetweenSpawns()
    {
        return TimeBetweenSpawns;
    }
}
