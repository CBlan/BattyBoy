using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public KeyCode pauseButton;
    public GameObject pausePanel;
    public bool paused;

    public static PauseManager instance;

    private void Start()
    {
        instance = this;

    }

    public void Update()
    {
        if (Input.GetKeyDown(pauseButton))
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        paused = !paused;
        pausePanel.SetActive(paused);

        if (paused)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0f;
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1f;
        }
    }

    public void ResetScene()
    {
        PauseGame();
        SceneManager.LoadScene("Main");
    }

    public void Quit()
    {
        Application.Quit();
    }


}
