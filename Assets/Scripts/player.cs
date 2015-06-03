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

		//MOVE IF MOVE KEYS DOWN
		if (Input.GetButton ("Horizontal")) {
			if (grappleHook.isHooked == false) {
				Move (Input.GetAxisRaw ("Horizontal"), speed);
				Debug.Log("MOVING");
			}
		}

		//SWING
		if (Input.GetButtonDown ("Horizontal")) {
			if (grappleHook.isHooked == true) {
				Move (Input.GetAxisRaw ("Horizontal"), speed);
				Debug.Log("SWINGING");
			}
		}

		//JUMP KEYS DOWN
		if (Input.GetButtonDown ("Jump")) {
			Jump ();
		}

	}
		
	public void Move(float horizontalInput, float momentum){
		Vector2 moveVelocity = mybody.velocity;
		moveVelocity.x = horizontalInput * momentum;
		mybody.velocity = moveVelocity;

	}

	public void Jump() {

		if (isGrounded == true && grappleHook.isHooked == false) {
			mybody.velocity += jumpVelocity * Vector2.up;
		}
		if (grappleHook.isHooked == true && isGrounded == false) {
			Destroy (playerRid.GetComponent<DistanceJoint2D>(), 0);
			mybody.velocity += releaseVelocity * Vector2.up;
			grappleHook.isHooked = false;


		}
	

	}
}