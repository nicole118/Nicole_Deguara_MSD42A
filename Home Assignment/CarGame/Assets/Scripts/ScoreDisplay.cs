using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    Text scoreText;
    GameSessions gameSession;

    void Start()
    {
        //gets the value from unity
        scoreText = GetComponent<Text>();
        gameSession = FindObjectOfType<GameSessions>();
    }

    void Update()
    {
        //convert the values to string
        scoreText.text = gameSession.GetScore().ToString();
    }

}
