using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    [SerializeField] Canvas StartGameCanvas;

        private void Start()
    {
        StartGameCanvas.enabled = true;
    }

    public void StartGame()
    {
        StartGameCanvas.enabled = false;
    }

    public void ReloadGame()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void QuitGame() 
    {
        Application.Quit();
    }
}
