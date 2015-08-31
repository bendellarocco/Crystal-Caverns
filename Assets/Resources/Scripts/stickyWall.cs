using UnityEngine;
using System.Collections;

public class stickyWall : MonoBehaviour {

	public static bool wallStuck = false;
	
	void Start () {

	}

	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D collide){
		if (collide.gameObject.tag == "Player") {
				collide.rigidbody.drag = 4;
				wallStuck = true;
				player.wallJumped = false;
			player.touching = this.gameObject;
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
