using UnityEngine;
using System.Collections;

public class bouncyMushroom : MonoBehaviour {

	public float bounce;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D hit) {
		if (hit.collider.tag == "Player") {
			//hit.rigidbody.AddForce(new Vector2(-hit.relativeVelocity.x, hit.relativeVelocity.y) * bounce, ForceMode2D.Impulse);
			//hit.rigidbody.AddForce(Vector2.up * bounce, ForceMode2D.Impulse);
		}

	}
}
