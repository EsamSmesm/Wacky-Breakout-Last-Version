using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    // move the ball
    private Rigidbody2D rb2d;
    Timer deathTimer;
    Timer timer;

    const int delay = 1;

    bool init = true;
    // Use this for initialization
    void Start () {


        deathTimer = gameObject.AddComponent<Timer>();
        deathTimer.Duration = ConfigurationUtils.BallLifeTime;
        deathTimer.Run();

        timer = gameObject.AddComponent<Timer>();
        timer.Duration = delay;
        timer.Run();


       

    }

    public void SetDirection(Vector2 direction)
    {
        rb2d = GetComponent<Rigidbody2D>();
        float  dirMagnitude = rb2d.velocity.magnitude;
        rb2d.velocity = direction*dirMagnitude;
    }

    // get the ball moving
    public void MoveBall()
    {
        float angle = -90 * Mathf.Deg2Rad;
        Vector2 force = new Vector2(
           ConfigurationUtils.BallImpulseForce * Mathf.Cos(angle),
           ConfigurationUtils.BallImpulseForce * Mathf.Sin(angle));
        GetComponent<Rigidbody2D>().AddForce(force);

        
    }

    void OnBecameInvisible()
    {
        if (transform.position.y <= ScreenUtils.ScreenBottom && !deathTimer.Finished)
        {
            
            Camera.main.GetComponent<BallSpawner>().Spawner();
            Destroy(this.gameObject);
        }


        BallsLeft.ballsLeft -= 1;
    }
    // Update is called once per frame
    void Update () {

        if (timer.Finished && init)
        {
            MoveBall();
            timer.Stop();
            init = false;
        }

        if (deathTimer.Finished)
        {
            Camera.main.GetComponent<BallSpawner>().Spawner();
            Destroy(gameObject);
           
        }

       

        }
}
