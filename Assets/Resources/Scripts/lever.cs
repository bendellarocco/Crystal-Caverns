﻿using UnityEngine;
using System.Collections;

public class lever : MonoBehaviour {

	public static bool active = false;
	public GameObject interactTarget;

	void Start () {
	
	}
	

	void Update () {
	
	}

	void activate(){
		if (active == false) {
			interactTarget.transform.Rotate(0,0,90);
			active = true;
		} else {
			interactTarget.transform.Rotate(0,0,-90);
			active = false;
		}

	}
}