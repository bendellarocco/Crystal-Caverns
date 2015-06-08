using UnityEngine;
using System.Collections;

public class stickyWall : MonoBehaviour {

	public static bool wallStuck = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D collide){
		if (collide.gameObject.tag == "Player") {
				collide.rigidbody.drag = 10;
				wallStuck = true;
				player.wallJumped = false;
			if (grappleHook.isHooked == true) {
				grappleHook.isHooked = false;
				Destroy(collide.rigidbody.GetComponent<DistanceJoint2D>(), 0);
			}



		}
	}

	void OnCollisionExit2D(Collision2D collide){
		if (collide.gameObject.tag == "Player") {
			wallStuck = false;
			collide.rigidbody.drag = 0;
			player.wallJumped = false;

			
		}
	}


}
