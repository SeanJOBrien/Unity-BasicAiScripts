using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TableWaypointing : MonoBehaviour {

	public int WPCounter = 0;
	public float speed = 2.0f;
	public List<GameObject> waypoints;
	public Dictionary<int, List<GameObject>> table;
	public int targetWP = 0;
	public GameObject target;
	public int health = 0;
	public int healthWP;
	public int ammoWP;
	// Use this for initialization
	void Start () {
		checkFirst();
		findTarget();
		table = new Dictionary<int, List<GameObject>>();
		health = 100;
		// List Waypoints for WP_0
		List<GameObject> tempList_0 = new List<GameObject>();
		tempList_0.Add(waypoints[0]); 	//0  //Self Assigned
		tempList_0.Add(waypoints[1]);	//1
		tempList_0.Add(waypoints[1]); 	//2
		tempList_0.Add(waypoints[1]); 	//3
		tempList_0.Add(waypoints[5]); 	//4
		tempList_0.Add(waypoints[5]); 	//5
		tempList_0.Add(waypoints[5]); 	//6
		tempList_0.Add(waypoints[5]); 	//7
		tempList_0.Add(waypoints[5]); 	//8

		table.Add (0,tempList_0);
		// List Waypoints for WP_1
		List<GameObject> tempList_1 = new List<GameObject>();
		tempList_1.Add(waypoints[0]); 	//0  
		tempList_1.Add(waypoints[1]);	//1 //Self Assigned
		tempList_1.Add(waypoints[2]); 	//2
		tempList_1.Add(waypoints[2]); 	//3
		tempList_1.Add(waypoints[2]); 	//4
		tempList_1.Add(waypoints[0]); 	//5
		tempList_1.Add(waypoints[0]); 	//6
		tempList_1.Add(waypoints[0]); 	//7
		tempList_1.Add(waypoints[0]); 	//8

		table.Add (1,tempList_1);
		// List Waypoints for WP_2
		List<GameObject> tempList_2 = new List<GameObject>();
		tempList_2.Add(waypoints[1]); 	//0  
		tempList_2.Add(waypoints[1]);	//1
		tempList_2.Add(waypoints[2]); 	//2 //Self Assigned
		tempList_2.Add(waypoints[3]); 	//3
		tempList_2.Add(waypoints[3]); 	//4
		tempList_2.Add(waypoints[3]); 	//5
		tempList_2.Add(waypoints[3]); 	//6
		tempList_2.Add(waypoints[3]); 	//7
		tempList_2.Add(waypoints[3]); 	//8

		table.Add (2,tempList_2);
		// List Waypoints for WP_3
		List<GameObject> tempList_3 = new List<GameObject>();
		tempList_3.Add(waypoints[4]); 	//0  
		tempList_3.Add(waypoints[2]);	//1
		tempList_3.Add(waypoints[2]); 	//2 
		tempList_3.Add(waypoints[3]); 	//3 //Self Assigned
		tempList_3.Add(waypoints[4]); 	//4
		tempList_3.Add(waypoints[4]); 	//5
		tempList_3.Add(waypoints[4]); 	//6
		tempList_3.Add(waypoints[4]); 	//7
		tempList_3.Add(waypoints[4]); 	//8

		table.Add (3,tempList_3);
		// List Waypoints for WP_4
		List<GameObject> tempList_4 = new List<GameObject>();
		tempList_4.Add(waypoints[5]); 	//0  
		tempList_4.Add(waypoints[5]);	//1
		tempList_4.Add(waypoints[3]); 	//2 
		tempList_4.Add(waypoints[3]); 	//3
		tempList_4.Add(waypoints[4]); 	//4  //Self Assigned
		tempList_4.Add(waypoints[5]); 	//5
		tempList_4.Add(waypoints[6]); 	//6
		tempList_4.Add(waypoints[6]); 	//7
		tempList_4.Add(waypoints[6]); 	//8

		table.Add (4,tempList_4);
		// List Waypoints for WP_5
		List<GameObject> tempList_5 = new List<GameObject>();
		tempList_5.Add(waypoints[0]); 	//0  
		tempList_5.Add(waypoints[0]);	//1
		tempList_5.Add(waypoints[0]); 	//2 
		tempList_5.Add(waypoints[4]); 	//3
		tempList_5.Add(waypoints[4]); 	//4  
		tempList_5.Add(waypoints[5]); 	//5  //Self Assigned
		tempList_5.Add(waypoints[6]); 	//6
		tempList_5.Add(waypoints[6]); 	//7
		tempList_5.Add(waypoints[6]); 	//8

		table.Add (5,tempList_5);
		// List Waypoints for WP_6
		List<GameObject> tempList_6 = new List<GameObject>();
		tempList_6.Add(waypoints[4]); 	//0  
		tempList_6.Add(waypoints[4]);	//1
		tempList_6.Add(waypoints[4]); 	//2 
		tempList_6.Add(waypoints[4]); 	//3
		tempList_6.Add(waypoints[4]); 	//4  
		tempList_6.Add(waypoints[4]); 	//5
		tempList_6.Add(waypoints[6]); 	//6  //Self Assigned
		tempList_6.Add(waypoints[7]); 	//7
		tempList_6.Add(waypoints[7]); 	//8

		table.Add (6,tempList_6);
		// List Waypoints for WP_7
		List<GameObject> tempList_7 = new List<GameObject>();
		tempList_7.Add(waypoints[6]); 	//0  
		tempList_7.Add(waypoints[6]);	//1
		tempList_7.Add(waypoints[6]); 	//2 
		tempList_7.Add(waypoints[6]); 	//3
		tempList_7.Add(waypoints[6]); 	//4  
		tempList_7.Add(waypoints[6]); 	//5
		tempList_7.Add(waypoints[6]); 	//6  
		tempList_7.Add(waypoints[7]); 	//7  //Self Assigned
		tempList_7.Add(waypoints[8]); 	//8

		table.Add (7,tempList_7);
		// List Waypoints for WP_8
		List<GameObject> tempList_8 = new List<GameObject>();
		tempList_8.Add(waypoints[7]); 	//0  
		tempList_8.Add(waypoints[7]);	//1
		tempList_8.Add(waypoints[7]); 	//2 
		tempList_8.Add(waypoints[7]); 	//3
		tempList_8.Add(waypoints[7]); 	//4  
		tempList_8.Add(waypoints[7]); 	//5
		tempList_8.Add(waypoints[7]); 	//6  
		tempList_8.Add(waypoints[7]); 	//7  
		tempList_8.Add(waypoints[8]); 	//8  //Self Assigned

		table.Add (8,tempList_8);

	}
	
	// Update is called once per frame
	void Update () {
		//tableWaypointingSimple();
		tableWaypointingChase();
		//tableWaypointingObjectives();
		Debug.Log("Target: " + targetWP);
		Debug.Log("CurrentWP: " + WPCounter);
	}

	void tableWaypointingSimple(){
		//--------------------------------------------------------
		// Locate Next Waypoint.
		//--------------------------------------------------------
		Vector3 adjustedPosition = new Vector3(waypoints[WPCounter].transform.position.x,transform.position.y,waypoints[WPCounter].transform.position.z);
		transform.LookAt(adjustedPosition);
		transform.position = Vector3.MoveTowards(transform.position, adjustedPosition, speed*Time.deltaTime);
		if(Vector3.Distance(transform.position, waypoints[WPCounter].transform.position) < 1.0) // Check to see if we have reach waypoint area.
		{
			// Find Next WP
			List<GameObject> tmp = new List<GameObject>();
			if(table.TryGetValue(WPCounter,out tmp)){
				GameObject tmpWp = tmp[targetWP];
				if (WPCounter == waypoints.IndexOf(tmpWp)){
					Debug.Log ("Player In Range");
				} else{
					WPCounter = waypoints.IndexOf(tmpWp);
				}
			} else{
				Debug.Log("Index Not Found.");
			}
		}
	}

	void tableWaypointingChase(){
		//--------------------------------------------------------
		// Locate Next Waypoint.
		//--------------------------------------------------------
		if (WPCounter >= 0){
			Vector3 adjustedPosition = new Vector3(waypoints[WPCounter].transform.position.x,transform.position.y,waypoints[WPCounter].transform.position.z);
			transform.LookAt(adjustedPosition);
			transform.position = Vector3.MoveTowards(transform.position, adjustedPosition, speed*Time.deltaTime);
			if(Vector3.Distance(transform.position, waypoints[WPCounter].transform.position) < 1.0) // Check to see if we have reach waypoint area.
			{
				// Find Next WP
				List<GameObject> tmp = new List<GameObject>();
				if(table.TryGetValue(WPCounter,out tmp)){
					GameObject tmpWp = tmp[targetWP];
					if (WPCounter == waypoints.IndexOf(tmpWp)){
						WPCounter = -1;
					} else{
						findTarget();
						WPCounter = waypoints.IndexOf(tmpWp);
					}
				} else{
					Debug.Log("Index Not Found.");
				}
			}
		} else{
			simpleFollow();
		}
	}

	void tableWaypointingObjectives(){
		//--------------------------------------------------------
		// Locate Next Waypoint.
		//--------------------------------------------------------
		if (WPCounter >= 0){
			Vector3 adjustedPosition = new Vector3(waypoints[WPCounter].transform.position.x,transform.position.y,waypoints[WPCounter].transform.position.z);
			transform.LookAt(adjustedPosition);
			transform.position = Vector3.MoveTowards(transform.position, adjustedPosition, speed*Time.deltaTime);
			if(Vector3.Distance(transform.position, waypoints[WPCounter].transform.position) < 0.5) // Check to see if we have reach waypoint area.
			{
				// Find Next WP
				if(WPCounter == 1) //TODO
				{
					health = 100;
				}
				List<GameObject> tmp = new List<GameObject>();
				if(table.TryGetValue(WPCounter,out tmp)){
					GameObject tmpWp = tmp[targetWP];
					if (WPCounter == waypoints.IndexOf(tmpWp)){
						WPCounter = -1;
					} else{
						findTarget();
						WPCounter = waypoints.IndexOf(tmpWp);
					}
				} else{
					Debug.Log("Index Not Found.");
				}
			}
		} else{
			simpleFollow();
		}
		if(health < 50){
			targetWP = 1;
		}
	}

	void simpleFollow()
	{
		//--------------------------------------------
		// Search For Player
		//--------------------------------------------
		RaycastHit hit;
		Vector3 adjustedPosition = new Vector3(target.transform.position.x,transform.position.y,target.transform.position.z);
		transform.LookAt(adjustedPosition);
		Vector3 fwd = transform.TransformDirection(Vector3.forward);
		if (Physics.Raycast(transform.position, fwd, out hit, 100)) { // Check for objects between *player and *self. @player @NPC
			if(hit.collider.gameObject.name == "Player"){	 
				//--------------------------------------------
				// Can See Player
				//--------------------------------------------
				if (Vector3.Distance(transform.position, target.transform.position) < 1.0f){ // Check if player is in range.
					Debug.Log ("Player In Range");
					if(target.tag == "healthPack"){ //TODO
						health = 100;
					} else{
						health = 0;
					}
				} else{ // Move towards *player. @player
					transform.position = Vector3.MoveTowards(transform.position, adjustedPosition ,speed*Time.deltaTime);
				}
			} else{
				//--------------------------------------------
				// Can't See Player
				//--------------------------------------------
				findTarget();
				checkFirst();
			}
		}
	}

	void findTarget() {
		//--------------------------------------------------------
		// Locate Next Waypoint.
		//--------------------------------------------------------
		float distance = 999999.0f;
		int index = 0;
		for(int i = 0; i < waypoints.Count; i++){
			Vector3 wpPos = new Vector3(waypoints[i].transform.position.x,0.5f,waypoints[i].transform.position.z);
			target.transform.LookAt(wpPos);
			Vector3 fwd = target.transform.TransformDirection (Vector3.forward);
			RaycastHit hit;
			if (!Physics.Raycast(target.transform.position, fwd,out hit, 5)) {
				if (Vector3.Distance(target.transform.position,wpPos) < distance){
					index = i;
					distance = Vector3.Distance(target.transform.position,waypoints[i].transform.position);
				}
			}
		}
		targetWP = index;
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
			Vector3 fwd = transform.TransformDirection(Vector3.forward);
			RaycastHit hit;
			if (!Physics.Raycast(transform.position, fwd,out hit, 5)) {
				if (Vector3.Distance(transform.position,wpPos) < distance){
					index = i;
					distance = Vector3.Distance(transform.position,waypoints[i].transform.position);
				}
			}
		}
		WPCounter = index;
	}
}
