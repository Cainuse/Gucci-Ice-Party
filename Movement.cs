using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
	public float moveSpd = 2;
	bool facingRight=true;
	bool canJump = false;

	// Use this for initialization
	void Start () {
		
	}




	void Update(){

		CharacterController controller = GetComponent<CharacterController>();
		if (controller.isGrounded) {
			canJump = true;
		}




	}
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetKey (KeyCode.RightArrow)) {
			transform.Translate (moveSpd * Time.deltaTime, 0, 0);
			if (!facingRight) {
				Flip ();
			}
		}
		else if (Input.GetKey (KeyCode.LeftArrow)) {
			transform.Translate (-moveSpd * Time.deltaTime, 0, 0);
			if (facingRight) {
				Flip ();
			}

		}

		if (Input.GetKey (KeyCode.UpArrow)) {
			transform.Translate (moveSpd * Time.deltaTime, 0, 0);

		}



	}


	void Flip(){
		facingRight = !facingRight;
		Vector3 curScale = transform.localScale;
		curScale.x *= -1;

		transform.localScale = curScale;

		Debug.Log ("Hi");

	}
}
