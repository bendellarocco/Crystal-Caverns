using UnityEngine;
using System.Collections;

public class killOnTouch : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D collide){
		if (collide.gameObject.tag == "Player") {
			Application.LoadLevel (Application.loadedLevel);
		}
	}
}
