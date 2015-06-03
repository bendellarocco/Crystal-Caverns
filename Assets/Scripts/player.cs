using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {

	public float speed = 7;
	public float jumpVelocity = 7;
	public float releaseVelocity = 1;
	Transform myTrans, tagGround;
	Rigidbody2D mybody;
	public GameObject playerRid;

	
	public bool isGrounded = false;

	// Use this for initialization
	void Start () {
		mybody = this.GetComponent<Rigidbody2D>();
		myTrans = this.transform;
		tagGround = GameObject.Find(this.name + "/tag_ground").transform;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		isGrounded = Physics2D.Linecast (myTrans.position, tagGround.position);


		if (Input.acceleration.x > .09 || Input.acceleration.x < -.09) {
			Move ((Input.acceleration), speed);
		}


		//JUMP KEYS DOWN
		if (Input.GetButtonDown ("Jump")) {
			Jump ();
		}

	}
		
	public void Move(Vector2 horizontalInput, float momentum){
		if (grappleHook.isHooked == false) {
			Vector2 moveVelocity = mybody.velocity;
			//NORMALIZE INPUT SO ITS LESS TWITCHY
			horizontalInput.Normalize();

			//MULTIPLY BY DELTATIME SO IT MOVES PER SECOND NOT PER FRAME
			horizontalInput *= Time.deltaTime;

			transform.Translate((horizontalInput.x * 12), 0, 0);
			Debug.Log(horizontalInput.x * 12);
		}

	}

	public void Jump() {

		if (isGrounded == true && grappleHook.isHooked == false) {
			mybody.velocity += jumpVelocity * Vector2.up;
		}
		if (grappleHook.isHooked == true && isGrounded == false) {
			Release ();
		}
	}

	public void Release() {
		Destroy (playerRid.GetComponent<DistanceJoint2D>(), 0);
		mybody.velocity += releaseVelocity * Vector2.up;
		grappleHook.isHooked = false;
	}
}