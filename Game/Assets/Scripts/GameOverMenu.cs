using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour {
    public GameObject pause;
    // Use this for initialization
    public void Game()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Unpaused()
    {
        pause.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Pause() {
        Time.timeScale = 0f;
        pause.SetActive(true);
    }
}
