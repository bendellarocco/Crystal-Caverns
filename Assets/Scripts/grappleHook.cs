using UnityEngine;
using System.Collections;

public class grappleHook : MonoBehaviour {

	public GameObject player;
	public Transform jointTransform;
	public Rigidbody2D joint;

	Vector3 target;
	float swingDirection;
	public LineRenderer lineRenderer;
	public static bool isHooked = false;
	private DistanceJoint2D distanceJoint;

	// Use this for initialization
	void Start () {
		lineRenderer = this.GetComponent<LineRenderer>();
	}
	
	// Update is called once per frame
	void Update () {

		//REMOVE LINE IF NOT HOOKED
		if (isHooked == false) {
			lineRenderer.SetPosition (1, this.transform.position);
		}

		lineRenderer.SetPosition (0, this.transform.position);

		if (Input.GetMouseButtonDown(0)) 
		{
			newGrapple();
		}
	}

	public void newGrapple(){
		Debug.Log (isHooked);

		if (isHooked == false) {

			Destroy (distanceJoint);
			//GET USERS MOUSE CLICK INPUT
			target = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			target.z = transform.position.z;

			//SEND OUT RAY TO CHECK FOR ANY HITS
			RaycastHit2D hit = Physics2D.Linecast (transform.position, target);
			if (hit.collider != null) {
				//IF COLLISION DRAW LINE FROM PLAYER TO HIT LOCATION
				lineRenderer.SetPosition (1, hit.point);

				//MOVE JOINT
				jointTransform.position = new Vector3 (hit.point.x, hit.point.y, 0);

				//CREATE DISTANCE JOINT
				distanceJoint = player.AddComponent<DistanceJoint2D> ();
				distanceJoint.distance = 7;
				distanceJoint.connectedBody = joint;

				isHooked = true;

			} else {
				//NO HIT, REMOVE SECOND POINT OF LINE
				Debug.Log ("MISSED SHOT");
				lineRenderer.SetPosition (1, this.transform.position);
			}

		}
	}
}
