using UnityEngine;
using System.Collections;

public class fallingObject : MonoBehaviour {

	public float fallSpeed;
	Rigidbody2D target;
	Vector3 originalPosition;

	void Start () {
		target = this.GetComponent<Rigidbody2D>();
		originalPosition = this.transform.position;
	}
	

	void Update () {
		RaycastHit2D hit = Physics2D.Raycast (this.transform.position, -Vector2.up);
		if (hit.collider.tag == "Player") {
			target.isKinematic = false;
			target.gravityScale = fallSpeed;
		}
	}
}
