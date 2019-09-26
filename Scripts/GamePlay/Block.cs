using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

    protected float BlockWorth;

	// Use this for initialization
	void Start () {
		
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag=="Ball")
        {
            Score.score += 1;
            Destroy(gameObject);
            AudioManager.Play(AudioClipName.BallHit);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
