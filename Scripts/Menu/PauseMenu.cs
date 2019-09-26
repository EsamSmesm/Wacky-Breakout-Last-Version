using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject PauseMenuUI;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
            AudioManager.Play(AudioClipName.PauseGame);
        }

    }
    
    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        GameIsPaused = false;
        Time.timeScale = 1f;
        AudioManager.Play(AudioClipName.MenuButtonClick);
    }

    void Pause()
    {
        PauseMenuUI.SetActive(true);
        GameIsPaused = true;
        Time.timeScale = 0f;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
        AudioManager.Play(AudioClipName.MenuButtonClick);
    }

    public void QuitGame()
    {
        AudioManager.Play(AudioClipName.MenuButtonClick);
        Application.Quit();
       
    }
   
}
