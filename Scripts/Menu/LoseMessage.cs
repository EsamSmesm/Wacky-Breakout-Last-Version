using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoseMessage : MonoBehaviour
{
    public static bool IsLose = false;
    public GameObject LoseMessageUI;



    // Update is called once per frame
    void Update()
    {

        if (BallsLeft.ballsLeft <= 0)
        {

            LoseMessageUI.SetActive(true);
            Time.timeScale = 0;
            

        }
    }

    public void Restart()
    {
        LoseMessageUI.SetActive(false);
        Invoke("LoadScene", 1f);
        AudioManager.Play(AudioClipName.MenuButtonClick);
        
        
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        BallsLeft.ballsLeft = ConfigurationUtils.NumOfBalls;
        Score.score = 0;
    }
}
