using UnityEngine;
using System.Collections;

public class fallingObject : MonoBehaviour {

	public float fallSpeed;
	Rigidbody2D target;

	void Start () {
		target = this.GetComponent<Rigidbody2D>();
	}
	

	void Update () {
		RaycastHit2D hit = Physics2D.Raycast (this.transform.position, -Vector2.up);
		if (hit.collider.tag == "Player") {
			target.isKinematic = false;
			target.gravityScale = fallSpeed;
		}
	}

	void OnCollisionEnter2D(Collision2D collide){
		if (collide.gameObject.tag == "Map") {
			Destroy(this.gameObject);
		} else {
			if (collide.gameObject.tag == "Player") {
				Application.LoadLevel (Application.loadedLevel);
			}
		}
	}
}
