using UnityEngine;
using System.Collections;

public class grappleHook : MonoBehaviour {

	Vector3 target;
	float swingDirection;
	public float grappleVelocity = 20;
	private LineRenderer lineRenderer;

	// Use this for initialization
	void Start () {
		lineRenderer = this.GetComponent<LineRenderer>();
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonDown(0)) 
		{
			newGrapple();
		}
	}

	public void Grapple()
	{

			target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			target.z = transform.position.z;
			
			
			if (transform.position.x > target.x) {
				swingDirection = -1;
			}
			else {
				swingDirection = 1;
			}
		transform.position = Vector3.MoveTowards(transform.position, target, grappleVelocity * Time.deltaTime);

	}

	public void newGrapple(){
		//GET USERS MOUSE CLICK INPUT
		target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		target.z = transform.position.z;

		//SEND OUT RAY TO CHECK FOR ANY HITS
		RaycastHit2D hit = Physics2D.Linecast(transform.position, target);
		if (hit.collider != null) {
			Debug.Log (hit.point);

			//IF COLLISION DRAW LINE FROM PLAYER TO HIT LOCATION
			lineRenderer.SetPosition (0, this.transform.position);
			lineRenderer.SetPosition (1, hit.point);
		} else {
			//NO HIT, REMOVE SECOND POINT OF LINE
			Debug.Log("MISSED SHOT");
			lineRenderer.SetPosition (1, this.transform.position);
		}

	}
}
