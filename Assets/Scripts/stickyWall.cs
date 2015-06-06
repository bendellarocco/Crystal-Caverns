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
			collide.rigidbody.drag = 15;
			wallStuck = true;

		}
	}

	void OnCollisionExit2D(Collision2D collide){
		if (collide.gameObject.tag == "Player") {
			wallStuck = false;
			collide.rigidbody.drag = 0;

			
		}
	}


}
