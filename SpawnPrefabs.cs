using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPrefabs : MonoBehaviour {

	// these are global variables to be set in the inspector. 
	public float spawnTime = 1f;
	//The amount of time between each spawn.
	public float spawnDelay = 1f;
	//The amount of time before spawning starts.
	public GameObject[] Sharks;
	public Vector3 enposition;

	// use this for initialization 
	void Start () {
		InvokeRepeating ("CreateSharks", 0f, 1.5f); // call and repeat function CreateCars at runtime, and there after every 1.5 seconds
	}
	// CreateCars is called every 1.5 seconds
	void CreateShark () {
		int sharkIndex = Random.Range (0, Sharks.Length);
		Instantiate (Sharks [sharkIndex], enposition, transform.rotation);

	}

}
