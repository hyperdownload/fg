using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    private bool canPause = true;
    private bool isPaused;
    [SerializeField] private GameObject pausePanel;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }
    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f; // Pausa el tiempo en el juego
        pausePanel.SetActive(true); // Activa el panel de pausa
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        isPaused = false;
        pausePanel.SetActive(false); // Desactiva el panel de pausa
    }
}
