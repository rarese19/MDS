using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isGamePaused = false;

    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject optionsPanel;
    [SerializeField] GameObject keybindsMenu;

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGamePaused)
            {
                if (pauseMenu.activeSelf)
                    ResumeGame();
                else if (optionsPanel.activeSelf){
                    optionsPanel.SetActive(false);
                    pauseMenu.SetActive(true);
                }
                else {
                    keybindsMenu.SetActive(false);
                    optionsPanel.SetActive(true);
                }
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
    }
    
    void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isGamePaused = true;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    public void QuitGame()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;

    }
}
