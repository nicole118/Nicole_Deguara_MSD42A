using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSessions : MonoBehaviour
{
    int score = 0;

    private void Awake()
    {
        SetUpSingleton();
    }

    //only one session can be running
    private void SetUpSingleton()
    {
        int numberGameSessions = FindObjectsOfType<GameSessions>().Length;
        if (numberGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    //gets the score
    public int GetScore()
    {
        return score;
    }

    public void AddToScore(int scoreVal)
    {
        //the score is updated with the valye of scoreValue
        score += scoreVal;
    }

    public void ResetGame()
    {
        //destroys the current game session
        Destroy(gameObject);
    }


}
