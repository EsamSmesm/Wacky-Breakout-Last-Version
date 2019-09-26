using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinMessage : MonoBehaviour
{
    public static bool IsWin = false;
    public GameObject WinMessageUI;


    
    // Update is called once per frame
    void Update()
    {
        GameObject[] gameObjects;
        gameObjects = GameObject.FindGameObjectsWithTag("Block");
        if (gameObjects.Length == 0)
        {

            WinMessageUI.SetActive(true);
            Time.timeScale = 0;
            
        }
    }

    public void Restart()
    {
        WinMessageUI.SetActive(false);  
        AudioManager.Play(AudioClipName.MenuButtonClick);
        Invoke("LoadScene", 1f);
       
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        BallsLeft.ballsLeft = ConfigurationUtils.NumOfBalls;
        Score.score = 0;
    }

}
