using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    //a list of WaveConfigs
    [SerializeField] List<WaveConfig> waveConfigs;
    [SerializeField] bool looping = false;

    int beginWave = 1;


    // Start is called before the first frame update
    IEnumerator Start()
    {
        //set the 1st wave to the current one
        var currentWave = waveConfigs[beginWave];

        do
        {
            //start the spawner coroutine with the current wave
            yield return StartCoroutine(SpawnAllWaves());

            StartCoroutine(SpawnAllObstaclesInWave(currentWave));
        }

        while (looping);
    }


    private IEnumerator SpawnAllObstaclesInWave(WaveConfig waveConfig)
    {
        for (int obCount = 0; obCount < waveConfig.GetNumberOfObstacles(); obCount++)
        {

            //spawn obstacles
            Instantiate(
            waveConfig.GetObstaclePrefab(),
            waveConfig.GetWaypoints()[0].transform.position,
            Quaternion.identity);

            //wait for the amount of time between spawns
            yield return new WaitForSeconds(waveConfig.GetTimeBetweenSpawns());

        }
    }

    private IEnumerator SpawnAllWaves()
    {
        //loop until it reaches the last in List
        for (int waveIndex = beginWave; waveIndex < waveConfigs.Count; waveIndex++)
        {
            var currentWave = waveConfigs[waveIndex];
            //wait for all enemies in Wave to spawn before going to next loop
            yield return StartCoroutine(SpawnAllObstaclesInWave(currentWave));
        }
    }


}
