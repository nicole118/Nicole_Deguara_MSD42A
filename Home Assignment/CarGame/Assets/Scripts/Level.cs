using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Level : MonoBehaviour
{
    [SerializeField] float delayInSec = 2f;

    //waits for 2 sec and then loads the game over scene
    IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(delayInSec);
        SceneManager.LoadScene("GameOver");
    }

    //loads the Game Over scene
    public void LoadGameOverScreen()
    {
        StartCoroutine(WaitAndLoad());
    }

    public void LoadStart()
    {
        //loads the first scene in the Project
        SceneManager.LoadScene(0);
    }

    public void LoadGame()
    {
        //loads the scene of the actual game
        SceneManager.LoadScene("CarGame");

        //reset the game from the beginning
        FindObjectOfType<GameSessions>().ResetGame();

    }

    public void LoadGameOver()
    {
        //loads the gaame over
        StartCoroutine(WaitAndLoad());
    }

    public void QuitGame()
    {
        //quits the game
        Application.Quit();
    }

}
