 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {
    // move the paddle
    public Rigidbody2D rb2d;
    public float halfColliderWidth;
    float halfColliderHeight;
    const float BounceAngleHalfRange = 60 * Mathf.Deg2Rad;


    // Use this for initialization
    void Start () {
       
        rb2d = GetComponent<Rigidbody2D>();
        halfColliderWidth = GetComponent<BoxCollider2D>().size.x / 2;
        halfColliderHeight = GetComponent<BoxCollider2D>().size.y / 2;

    }


    void FixedUpdate ()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput != 0)
        {
            Vector2 position = rb2d.position;
            position.x += horizontalInput * ConfigurationUtils.PaddleMoveUnitsPerSecond *
                Time.deltaTime;
            position.x = CalculateClampedX(position.x);
            rb2d.MovePosition(position);
        }


    }
    
    public float CalculateClampedX(float x)
    {
        if (x - halfColliderWidth <= ScreenUtils.ScreenLeft)
        {
            x = ScreenUtils.ScreenLeft + halfColliderWidth;
        }
        else if (x + halfColliderWidth>= ScreenUtils.ScreenRight)
        {
             x = ScreenUtils.ScreenRight - halfColliderWidth;
        }

        return x;

    }
    
    /// <summary>
    /// Detects collision with a ball to aim the ball
    /// </summary>
    /// <param name="coll">collision info</param>
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Ball"))
        {
            // calculate new ball direction
            float ballOffsetFromPaddleCenter = transform.position.x -
                coll.transform.position.x;
            float normalizedBallOffset = ballOffsetFromPaddleCenter /
                halfColliderWidth;
            float angleOffset = normalizedBallOffset * BounceAngleHalfRange;
            float angle = Mathf.PI / 2 + angleOffset;
            Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

            // tell ball to set direction to new direction
            Ball ballScript = coll.gameObject.GetComponent<Ball>();
            ballScript.SetDirection(direction);

            AudioManager.Play(AudioClipName.BallHit);
        }
    }

    /*
    bool TopCollision(Collision2D coll)
    {
        const float tolerance = 0.05f;

        // on top collisions, both contact points are at the same y location
        ContactPoint2D[] contacts = coll.contacts;
        return Mathf.Abs(contacts[0].point.y - contacts[1].point.y) < tolerance;
    }
    */

    // Update is called once per frame
    void Update () {
      
	}
}
