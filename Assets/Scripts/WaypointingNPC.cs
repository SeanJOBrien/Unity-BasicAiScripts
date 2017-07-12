using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WaypointingNPC : MonoBehaviour {

	public int WPCounter = 0;
	public float speed = 2.0f;
	public List<GameObject> waypoints;
	// Use this for initialization
	void Start () {
		checkFirst();
	}
	
	// Update is called once per frame
	void Update () {
		waypointing();
	}
	void waypointing(){ 
		//--------------------------------------------------------
		// Locate Next Waypoint.
		//--------------------------------------------------------
		transform.LookAt(waypoints[WPCounter].transform.position);
		Vector3 adjustedPosition = new Vector3(waypoints[WPCounter].transform.position.x,transform.position.y,waypoints[WPCounter].transform.position.z);
		transform.position = Vector3.MoveTowards(transform.position, adjustedPosition, speed*Time.deltaTime);
		if(Vector3.Distance(transform.position, waypoints[WPCounter].transform.position) < 1.0) // Check to see if we have reach waypoint area.
		{
			if(WPCounter == (waypoints.Count-1)){ // If waypoints current *counter is at max in *array reset. @WPCounter @waypoints
				WPCounter = 0;
			}else{ // Otherwise work away.
				WPCounter++;
			}
		}
	}

	void checkFirst() {
		//--------------------------------------------------------
		// Locate Next Waypoint.
		//--------------------------------------------------------
		float distance = 999999.0f;
		int index = 0;
		for(int i = 0; i < waypoints.Count; i++){
			Vector3 wpPos = new Vector3(waypoints[i].transform.position.x,0.5f,waypoints[i].transform.position.z);
			transform.LookAt(wpPos);
			Vector3 fwd = transform.TransformDirection (Vector3.forward);
			RaycastHit hit;
			if (!Physics.Raycast(transform.position, fwd,out hit, 5)) {
				if (Vector3.Distance(transform.position,waypoints[i].transform.position) < distance){
					index = i;
					distance = Vector3.Distance(transform.position,waypoints[i].transform.position);
				}
			}
		}
		WPCounter = index;
	}
}
