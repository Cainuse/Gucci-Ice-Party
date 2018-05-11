using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using System.Collections;
using UnityEngine.Audio;

namespace UnityStandardAssets._2D
{
	[RequireComponent(typeof (PlatformerCharacter2D))]
	public class Platformer2DUserControl : MonoBehaviour
	{
		private PlatformerCharacter2D m_Character;
		private bool m_Jump;
		public GameObject bulletPrefab;
		public GameObject brickPrefab;
		public GameObject lemonPrefab;
		public GameObject icePrefab;
		public Transform bulletSpawn;
		private float nextActionTime= 0.0f;
		public float period = 500.0f;

		public float curTime;

		public string weapon = "bricks";

		bool readyToFire = false;

		AudioSource Lemonade; 
		AudioSource Bricks;
		AudioSource Icy;

		private void Awake()
		{
			//			curTime = Time.time;
			m_Character = GetComponent<PlatformerCharacter2D>();
		}

		void Start() {
			InvokeRepeating("Fire", 2.0f, 0.5f);		

			var aSources = GetComponents<AudioSource>();
			Lemonade = aSources[0];
			Bricks = aSources[1];
			Icy = aSources[2];
		}

		private void Update()
		{
			if (!m_Jump)
			{
				// Read the jump input in Update so button presses aren't missed.
				m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
			}



		}


		private void FixedUpdate()
		{
			// Read the inputs.
			bool crouch = Input.GetKey(KeyCode.LeftControl);
			float h = CrossPlatformInputManager.GetAxis("Horizontal");
			// Pass all parameters to the character control script.
			m_Character.Move(h, crouch, m_Jump);
			m_Jump = false;

			//			if (Time.time >= (curTime + period)){
			//				curTime = Time.time;
			//				Fire ();
			//			}

			string url = "https://nwhacks-637cf.firebaseio.com/weapon.json";
			WWW www = new WWW(url);
			StartCoroutine(WaitForRequest(www));

		}

		IEnumerator WaitForRequest(WWW www)
		{
			yield return www;

			// check for errors
			if (www.error == null)
			{
				//				Debug.Log("WWW Ok!: " + www.text + " " + weapon);
				if (weapon != www.text) {
					weapon = www.text;
				}

				//				switch (www.text)
				//				{
				//				case "bricks":
				//					weapon = "bricks";
				//					break;
				//				case "lemonade":
				//					weapon = "lemonade";
				//					break;
				//				case "ice":
				//					weapon = "ice";
				//					break;
				//				default:
				//					Console.WriteLine("Default case");
				//					break;
				//				}

				//				Debug.Log("WWW Ok!: " + www.text);
			} else {
				Debug.Log("WWW Error:"+ www.error);
			}    
		}

		void Fire(){
			Debug.Log ("REEEEE");
			if (weapon == "\"bricks\"") {
				PlayBricks ();
				FireBricks ();
			} else if (weapon == "\"lemonade\"") {
				PlayLemonade ();
				FireLemonade ();

			} else if (weapon == "\"ice\"") {
				PlayIcy ();
				FireIce ();
			} else {

				FireLemonade ();
			}


		}

		void PlayBricks() {
			if (!Bricks.isPlaying) Bricks.Play ();
			if (Lemonade.isPlaying) Lemonade.Stop () ;
			if (Icy.isPlaying) Icy.Stop ();

		}

		void PlayLemonade() {
			if (!Lemonade.isPlaying) Lemonade.Play ();
			if (Bricks.isPlaying) Bricks.Stop ();
			if (Icy.isPlaying) Icy.Stop ();

		}

		void PlayIcy() {
			if (!Icy.isPlaying) Icy.Play ();
			if (Bricks.isPlaying) Bricks.Stop ();
			if (Lemonade.isPlaying) Lemonade.Stop ();


		}

		void FireBricks(){
			var bullet = (GameObject)Instantiate (
				brickPrefab,
				bulletSpawn.position,
				bulletSpawn.rotation
			);
			Vector3 curScale = transform.localScale;
			curScale.y = 0;
			curScale.z = 0;

			bullet.GetComponent<Rigidbody2D> ().velocity = curScale * 0.3;


			Destroy (bullet, 2.0f);
		}
		void FireLemonade(){
			var bullet = (GameObject)Instantiate (
				lemonPrefab,
				bulletSpawn.position,
				bulletSpawn.rotation
			);
			Vector3 curScale = transform.localScale;
			curScale.y = 0;
			curScale.z = 0;

			bullet.GetComponent<Rigidbody2D> ().velocity = curScale * 0.4;


			Destroy (bullet, 2.0f);
		}
		void FireIce(){
			var bullet = (GameObject)Instantiate (
				icePrefab,
				bulletSpawn.position,
				bulletSpawn.rotation
			);
			Vector3 curScale = transform.localScale;
			curScale.y = 0;
			curScale.z = 0;

			bullet.GetComponent<Rigidbody2D> ().velocity = curScale * 0.1;


			Destroy (bullet, 2.0f);
		}
	}
}
