using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AI : MonoBehaviour {
	
    public Transform Player;
	public float speed = 2f;
	private float minDistance = 0.2f;
	private float range;
	// Use this for initialization
	void Start() {
		
	}

	// Update is called once per frame
	void Update () {
		Player = GameObject.FindWithTag ("Player").transform;
		range = Vector2.Distance (transform.position, Player.position);
		if (range > minDistance) {
			Debug.Log (range);
			Player = GameObject.FindWithTag ("Player").transform;
			transform.position = Vector2.MoveTowards (transform.position, Player.position, speed * Time.deltaTime);
		}
 
    }

	void OnTriggerEnter2D(Collider2D col)
	{
		//all projectile colliding game objects should be tagged "Enemy" or whatever in inspector but that tag must be reflected in the below if conditional
		Debug.Log("TAG " + col.gameObject.tag);
		if (col.gameObject.tag == "Player") {
			Destroy (col.gameObject);
			//add an explosion or something
			//destroy the projectile that just caused the trigger collision

			//if (!MansNotHot.isPlaying) MansNotHot.Play ();

		}
	}



}
