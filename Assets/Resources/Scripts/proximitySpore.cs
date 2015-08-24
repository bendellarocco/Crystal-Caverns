using UnityEngine;
using System.Collections;

public class proximitySpore : MonoBehaviour {
	
	public float range;
	float distance;
	public float timer;
	float countdown;

	//TEMP BLINK STUFF
	float delay = 0.25f;
	Renderer rend;

	// Use this for initialization
	void Start () {
		countdown = timer;
		rend = this.GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {

		distance = Vector3.Distance (player.myTrans.position, this.transform.position);

		if (distance <= range) {
			if (countdown <= 0) {
				explode ();
			} else {
				countdown -= Time.deltaTime;
				rend.enabled = false;
				Invoke("show", delay);

			}

		} else {
			countdown = timer;
		}
	
	}


	void show() {
		rend.enabled = true;
	}

	void explode ()
	{
		Application.LoadLevel (Application.loadedLevel);
	}	
}
