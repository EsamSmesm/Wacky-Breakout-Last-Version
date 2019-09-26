using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        AudioManager.Play(AudioClipName.MenuButtonClick);
        
    }

    
    public void Help()
    {
        AudioManager.Play(AudioClipName.MenuButtonClick);
    }
    

    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
        AudioManager.Play(AudioClipName.MenuButtonClick);
        
    }
}
