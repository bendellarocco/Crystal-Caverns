using UnityEngine;
using System.Collections;

public class proximitySpore : MonoBehaviour {

	bool inRange = false;
	public float range;
	float distance;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

		distance = Vector3.Distance (player.myTrans.position, this.transform.position);

		if (distance <= range) {
			Debug.Log ("TOO FUCKIN CLOSE");
		}
	
	}
}
