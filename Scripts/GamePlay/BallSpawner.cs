using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{

    [SerializeField]
    public GameObject BallPrefab;
    public bool retrySpawn;
    Vector2 spawnLocationMin;
    Vector2 spawnLocationMax;
    Timer timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = gameObject.AddComponent<Timer>();

        this.SetTimer();
        this.Spawner();

        GameObject tempBall = Instantiate(BallPrefab);
        BoxCollider2D collider = tempBall.GetComponent<BoxCollider2D>();
        float ballColliderHalfWidth = collider.size.x / 2;
        float ballColliderHalfHeight = collider.size.y / 2;
        spawnLocationMin = new Vector2(
             tempBall.transform.position.x - ballColliderHalfWidth,
             tempBall.transform.position.y - ballColliderHalfHeight);
        spawnLocationMax = new Vector2(
            tempBall.transform.position.x + ballColliderHalfWidth,
            tempBall.transform.position.y + ballColliderHalfHeight);

        Destroy(tempBall);
        
         
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (timer.Finished)
        {
            Spawner();
            timer.Stop();
            SetTimer();
           
        }

        if (retrySpawn)
        {
            Spawner();
        }

        
    }

    // spawnning new ball 
    public void Spawner()
    {

        
        if (Physics2D.OverlapArea(spawnLocationMin, spawnLocationMax) == null)
        {
             retrySpawn = false;
             Instantiate(BallPrefab);
            
        }
        else
        {
            retrySpawn = true;
        }
        
    

    }

    public void SetTimer()
    {
        timer.Duration = Random.Range(ConfigurationUtils.MinSpwanSeconds, ConfigurationUtils.MaxSpwanSeconds);
        timer.Run();
    }


    
}
