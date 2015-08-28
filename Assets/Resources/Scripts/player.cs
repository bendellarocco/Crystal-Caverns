using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {

	float speed = 20;
	float jumpVelocity = 7;
	float swingVelocity = 3;
	public static Transform myTrans; 
	Transform tagGround;
	public static Rigidbody2D mybody;
	bool isGrounded = false;
	public static bool wallJumped = false;
	int mask = 1 << 9;
	float rotation;
	
	void Start () {
		mask = ~mask;
		mybody = this.GetComponent<Rigidbody2D>();
		myTrans = this.transform;
		tagGround = GameObject.Find(this.name + "/tag_ground").transform;
		rotation = transform.localScale.x;
	}

	void FixedUpdate () {
		isGrounded = Physics2D.Linecast (myTrans.position, tagGround.position, mask);

		//TEST IF YOURE FALLING TOO FAST YOU DIE
		if (mybody.velocity.y < -17) {
			Application.LoadLevel (Application.loadedLevel);;
		}

		//MOVE/SWING
		if (Input.acceleration.x > .09 || Input.acceleration.x < -.09) {
			if (Input.acceleration.x > .09){
				transform.localScale = new Vector3 (rotation, transform.localScale.y, transform.localScale.z);
			}else {
				transform.localScale = new Vector3 (-rotation, transform.localScale.y, transform.localScale.z);
			}

			if (grappleHook.isHooked == false || grappleHook.interacting == true) {
					Move ((Input.acceleration), speed);
				}else {
					Swing ((Input.acceleration), swingVelocity);
				}
		}
	}
		
	public void Move(Vector2 horizontalInput, float momentum){
		//NORMALIZE INPUT SO ITS LESS TWITCHY
		horizontalInput.Normalize();

		//MULTIPLY BY DELTATIME SO IT MOVES PER SECOND NOT PER FRAME
		horizontalInput *= Time.deltaTime;
		horizontalInput *= momentum;
		//horizontalInput.x = Mathf.Abs (horizontalInput.x);


		//SLOW DOWN INPUT IF ITS TOO HIGH
		if (horizontalInput.x > .11) {
			horizontalInput.x = .11f;
		} else 
			if (horizontalInput.x < -.11) {
			horizontalInput.x = -.11f;
		}

		//MOVE PLAYER
		transform.Translate((horizontalInput.x), 0, 0);
	}

	public void Swing(Vector2 horizontalInput, float momentum){
		//horizontalInput.x = Mathf.Abs (horizontalInput.x);
			mybody.AddForce(transform.right * horizontalInput.x * momentum);
	}

	public void Jump() {

		//CORRECT JUMP ALGORITH.  CHECKS IF PLAYER IS ON THE GROUND/HOOKED/OR STUCK TO WALL
		if (isGrounded == true && grappleHook.isHooked == false) {
			mybody.velocity += jumpVelocity * Vector2.up;
		} else {
				if (stickyWall.wallStuck == true) {
					if (wallJumped == false) {
						mybody.drag = 0;
						wallJumped = true;
					}
				}
			}
		}

	public static void Release() {
		Destroy (mybody.GetComponent<SpringJoint2D>(), 0);
		Destroy (mybody.GetComponent<DistanceJoint2D>(), 0);
		grappleHook.isHooked = false;
		grappleHook.interacting = false;
	}
}