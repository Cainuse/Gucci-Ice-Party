using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class KillEnemy : MonoBehaviour {
	AudioSource MansNotHot; 

	// Use this for initialization
	void Start () {
		MansNotHot = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D col)
	{
		//all projectile colliding game objects should be tagged "Enemy" or whatever in inspector but that tag must be reflected in the below if conditional
		Debug.Log("TAG " + col.gameObject.tag);
		if (col.gameObject.tag == "Enemy") {
			Destroy (col.gameObject);
			//add an explosion or something
			//destroy the projectile that just caused the trigger collision

			if (!MansNotHot.isPlaying) MansNotHot.Play ();
		
		}
	}
}
