using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChasePlayer : MonoBehaviour {


	public GameObject player;
	public float speed = 2.0f;
	Vector3 startLocal;
	private List<Vector3> NpcBreadcrumbs;

	// Use this for initialization
	void Start () {
		startLocal = transform.position;
		NpcBreadcrumbs = new List<Vector3>();
	}
	
	// Update is called once per frame
	void Update () {
		//simpleFollow();
		//returnPathFollow();
		returnPathFollowCrumbs();
	}

	void simpleFollow()
	{
		//--------------------------------------------
		// Search For Player
		//--------------------------------------------
		RaycastHit hit;
		transform.LookAt(player.transform.position);
		Vector3 fwd = transform.TransformDirection(Vector3.forward);
		if (Physics.Raycast(transform.position, fwd, out hit, 100)) { // Check for objects between *player and *self. @player @NPC
			if(hit.collider.gameObject.name == "Player"){	 
				//--------------------------------------------
				// Can See Player
				//--------------------------------------------
				if (Vector3.Distance(transform.position, player.transform.position) < 1.0f){ // Check if player is in range.
					Debug.Log ("Player In Range");
				} else{ // Move towards *player. @player
					Vector3 adjustedPosition = new Vector3(player.transform.position.x,gameObject.transform.position.y,player.transform.position.z);
					transform.position = Vector3.MoveTowards(transform.position, adjustedPosition ,speed*Time.deltaTime);
				}
			} else{
				//--------------------------------------------
				// Can't See Player
				//--------------------------------------------
				if (Vector3.Distance(transform.position, startLocal) < 0.5f){ // Reset position once at *start. @startLocal Prevents drofting of *self. @NPC
					transform.position = startLocal;
				} else{ // Move towards *start. @startLocal
					transform.LookAt(startLocal);
					transform.position = Vector3.MoveTowards(transform.position, startLocal,speed*Time.deltaTime);
				}
			}
		}
	}

	void returnPathFollow() {
		//--------------------------------------------
		// Search For Player
		//--------------------------------------------
		RaycastHit hit; 
		transform.LookAt(player.transform.position);
		Vector3 fwd = transform.TransformDirection (Vector3.forward);
		if (Physics.Raycast(transform.position, fwd, out hit, 100)) { // Check for objects between *player and *self. @player @NPC
			if(hit.collider.gameObject.name == "Player"){	 
				//--------------------------------------------
				// Can See Player
				//--------------------------------------------
				if (NpcBreadcrumbs.Count > 0){	// Drop Breadcrumb and add to *array. @NpcBreadcrumbs
					if( Vector3.Distance(transform.position, NpcBreadcrumbs[NpcBreadcrumbs.Count-1])>1.0f){
						NpcBreadcrumbs.Add(gameObject.transform.position);
					}
				} else{ // Drop first BreadCrumb and add to *array. @NpcBreadcrumbs
					NpcBreadcrumbs.Add(transform.position);
				}	
				if (Vector3.Distance(transform.position, player.transform.position) < 1.0f){ // Check if player is in range.
					Debug.Log ("Player In Range");
				} else{ // Move towards *player. @player
					Vector3 adjustedPosition = new Vector3(player.transform.position.x,gameObject.transform.position.y,player.transform.position.z);
					transform.position = Vector3.MoveTowards(transform.position, adjustedPosition ,speed*Time.deltaTime);				}
			} else {
				//--------------------------------------------
				// Can't See Player
				//--------------------------------------------
				if (NpcBreadcrumbs.Count > 0){ // If Breadcrumbs exist in *array. @NpcBreadcrumbs
					returnToStart();
				} else{ // Default back to the start id crumbs not found.
					if (Vector3.Distance(transform.position, startLocal) < 0.5f){ // Reset position once at *start. @startLocal Prevents drofting of *self. @NPC
						transform.position = startLocal;
					} else{ // Move towards *start. @startLocal
						transform.LookAt(startLocal);
						transform.position = Vector3.MoveTowards(transform.position, startLocal,speed*Time.deltaTime);
					}
				}
			} 
		}
	}
	void returnPathFollowCrumbs() {
		//--------------------------------------------
		// Search For Player
		//--------------------------------------------
		RaycastHit hit; 
		transform.LookAt(player.transform.position);
		Vector3 fwd = transform.TransformDirection (Vector3.forward);
		if (Physics.Raycast(transform.position, fwd, out hit, 100)) { // Check for objects between *player and *self. @player @NPC
			if(hit.collider.gameObject.name == "Player"){	 
				//--------------------------------------------
				// Can See Player
				//--------------------------------------------
				if (NpcBreadcrumbs.Count > 0){	// Drop Breadcrumb and add to *array. @NpcBreadcrumbs
					if( Vector3.Distance(transform.position, NpcBreadcrumbs[NpcBreadcrumbs.Count-1])>1.0f){
						NpcBreadcrumbs.Add(gameObject.transform.position);
					}
				} else{ // Drop first BreadCrumb and add to *array. @NpcBreadcrumbs
					NpcBreadcrumbs.Add(transform.position);
				}	
				if (Vector3.Distance(transform.position, player.transform.position) < 1.0f){ // Check if player is in range.
					Debug.Log ("Player In Range");
				} else{ // Move towards *player. @player
					Vector3 adjustedPosition = new Vector3(player.transform.position.x,gameObject.transform.position.y,player.transform.position.z);
					transform.position = Vector3.MoveTowards(transform.position, adjustedPosition ,speed*Time.deltaTime);				}
			} else{
				//--------------------------------------------
				// Can't See Player
				//--------------------------------------------
				GameObject[] crumbs = GameObject.FindGameObjectsWithTag("breadCrumb");
				float shortest = 99999999.0f;
				if (crumbs.Length > 0){ // Check if *player Breadcrumb in sight. @player
					GameObject closestCrumb = crumbs[0];
					for (int i = 0; i < crumbs.Length; i++){ // Search for closest *player Breadcrumb. @player
						if(Vector3.Distance(transform.position, crumbs[i].transform.position)< shortest){
							shortest = Vector3.Distance(transform.position, crumbs[i].transform.position);
							closestCrumb = crumbs[i];
						}
					}
					//--------------------------------------------
					// Follow Breadcrumb path.
					//------------------------------------------
					transform.LookAt(closestCrumb.transform.position);
					fwd = transform.TransformDirection(Vector3.forward);
					if (Physics.Raycast(transform.position, fwd, out hit, 100)) { //Check for object between *self and Breadcrumb. @player
						if(hit.collider.gameObject.tag == "breadCrumb"){ // Check Breadcrumb was hit.
							if( Vector3.Distance(transform.position, NpcBreadcrumbs[NpcBreadcrumbs.Count-1])>1.0f){
								NpcBreadcrumbs.Add(gameObject.transform.position);
							}
							Vector3 adjustedPosition = new Vector3(player.transform.position.x,gameObject.transform.position.y,player.transform.position.z);
							transform.position = Vector3.MoveTowards(transform.position, adjustedPosition ,speed*Time.deltaTime);							
							if( Vector3.Distance(transform.position, closestCrumb.transform.position)<1.0f){ // Once withing range remove Breadcrumb.
								Destroy(closestCrumb);
							}
						}else if(NpcBreadcrumbs.Count > 0){ // No Breadcrumbs in *array. @NpcBreadcrumb
							returnToStart();
						} else{ // Default back to the start id crumbs not found.
							if (Vector3.Distance(transform.position, startLocal) < 0.5f){ // Reset position once at *start. @startLocal Prevents drofting of *self. @NPC
								transform.position = startLocal;
							} else{ // Move towards *start. @startLocal
								transform.LookAt(startLocal);
								transform.position = Vector3.MoveTowards(transform.position, startLocal,speed*Time.deltaTime);
							}
						}
					} else if(NpcBreadcrumbs.Count > 0){ // No Breadcrumbs in *array. @NpcBreadcrumb
						returnToStart();
					} else{ // Default back to the start id crumbs not found.
						if (Vector3.Distance(transform.position, startLocal) < 0.5f){ // Reset position once at *start. @startLocal Prevents drofting of *self. @NPC
							transform.position = startLocal;
						} else{ // Move towards *start. @startLocal
							transform.LookAt(startLocal);
							transform.position = Vector3.MoveTowards(transform.position, startLocal,speed*Time.deltaTime);
						}
					}
				} else{
				if (NpcBreadcrumbs.Count > 0){ // If Breadcrumbs exist in *array. @NpcBreadcrumbs
						returnToStart();
					} else{ // Default back to the start id crumbs not found.
						if (Vector3.Distance(transform.position, startLocal) < 0.5f){ // Reset position once at *start. @startLocal Prevents drofting of *self. @NPC
							transform.position = startLocal;
						} else{ // Move towards *start. @startLocal
							transform.LookAt(startLocal);
							transform.position = Vector3.MoveTowards(transform.position, startLocal,speed*Time.deltaTime);
						}
					}
				}
			} 
		}
	} 

	void returnToStart() {
		//-------------------------------------------------
		// Return to *start via the *array of Breadcrumbs
		// @startLocal @NpcBreadcrumbs
		//-------------------------------------------------
		transform.LookAt(NpcBreadcrumbs[NpcBreadcrumbs.Count-1]);
		transform.position = Vector3.MoveTowards(transform.position, NpcBreadcrumbs[NpcBreadcrumbs.Count-1], speed*Time.deltaTime);
		if(Vector3.Distance(gameObject.transform.position, NpcBreadcrumbs[NpcBreadcrumbs.Count-1])<0.1f){ // Remove Breadcrumb from *array. @NpcBreadcrumbs
			NpcBreadcrumbs.RemoveAt(NpcBreadcrumbs.Count-1);
		}
	}
}
