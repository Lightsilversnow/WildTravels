using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndMenu : MonoBehaviour
{
    [SerializeField] Canvas EndGameCanvas;

    private void Start()
    {
        EndGameCanvas.enabled = false;
    }


    public void HandleCompleted()
    {
        EndGameCanvas.enabled = true;
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

    }

}
