using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {

	public float speed = 10;
	public float jumpVelocity = 10;
	public float releaseVelocity = 1;
	public LayerMask playerMask;
	Transform myTrans, tagGround;
	Rigidbody2D mybody;
	Vector3 target;
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
		target = transform.position;
		isGrounded = Physics2D.Linecast (myTrans.position, tagGround.position);

		Move (Input.GetAxisRaw ("Horizontal"));
		if (Input.GetButtonDown ("Jump")) {
			Jump ();
		}

	}
		
	public void Move(float horizontalInput){
		Vector2 moveVelocity = mybody.velocity;
		moveVelocity.x = horizontalInput * speed;
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