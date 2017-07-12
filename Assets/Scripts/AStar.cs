using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AStar : MonoBehaviour {


	public Dictionary <int, int> table;
	public List<GameObject> tiles;

	public int currentTile;

	// Use this for initialization
	void Start () {
		table = new Dictionary<int,int>();
		checkFirst();
	    		//-----0-----------------1-----------------2-----------------3-----------------4-----------------5-----------------6-------\\
		 /*-0-*/table.Add(0, 0);  table.Add(1, 0);  table.Add(2, 0);  table.Add(3, 0);  table.Add(4, 0);  table.Add(5, 0);  table.Add(6, 0);
		 /*-1-*/table.Add(7, 0);  table.Add(8, -1); table.Add(9, -1); table.Add(10, -1);table.Add(11, -1);table.Add(12, -1);table.Add(13, 0);
		 /*-2-*/table.Add(14, 0); table.Add(15, -1);table.Add(16, 0); table.Add(17, 0); table.Add(18, 0); table.Add(19, -1);table.Add(20, 0);
		 /*-3-*/table.Add(21, 0); table.Add(22, -1);table.Add(23, 0); table.Add(24, -1);table.Add(25, -1);table.Add(26, -1);table.Add(27, 0);
		 /*-4-*/table.Add(28, 0); table.Add(29, -1);table.Add(30, 0); table.Add(31, 0); table.Add(32, 0); table.Add(33, 0); table.Add(34, 0);
		 /*-5-*/table.Add(35, 0); table.Add(36, -1);table.Add(37, -1);table.Add(38, -1);table.Add(39, -1);table.Add(40, 0); table.Add(41, -1);
		 /*-6-*/table.Add(42, 0); table.Add(43, 0); table.Add(44, 0); table.Add(45, 0); table.Add(46, 0); table.Add(47, 0); table.Add(48, 0);
	}
	
	// Update is called once per frame
	void Update () {
		int[] tmpArray = surrondingTiles();
		for (int i = 0; i < tiles.Count; i++){
			int index;
			if(table.TryGetValue(i,out index)){
				if (index == -1){
					//Debug.Log(tiles[i]);
				} else{

				}
			} else{
				Debug.Log ("invalid.Log");
			}
		}
		Debug.Log ("Current: "+ currentTile);
	}
	void checkFirst() {
		//--------------------------------------------------------
		// Locate Next Waypoint.
		//--------------------------------------------------------
		float distance = 999999.0f;
		int index = 0;
		for(int i = 0; i < tiles.Count; i++){
			Vector3 wpPos = new Vector3(tiles[i].transform.position.x,0.5f,tiles[i].transform.position.z);
			transform.LookAt(wpPos);
			Vector3 fwd = transform.TransformDirection(Vector3.forward);
			RaycastHit hit;
			float targetDistance = Vector3.Distance(transform.position,wpPos);
			if (!Physics.Raycast(transform.position, fwd,out hit, targetDistance)) {
				if (targetDistance < distance){
					index = i;
					distance = targetDistance;
				}
			}
		}
		currentTile = index;
	}
//		if (hit.collider.gameObject.tag == "Tile"){
//			if (targetDistance < distance){
//				index = i;
//				distance = targetDistance;
//			}
//		}
//	} else
		
	int[] surrondingTiles() {
		int[] tempArray = new int[8];

		tempArray[0] = currentTile-8;
		tempArray[1] = currentTile-1;
		tempArray[2] = currentTile+6;
		tempArray[3] = currentTile+7;
		tempArray[4] = currentTile+8;
		tempArray[5] = currentTile+1;
		tempArray[6] = currentTile-6;
		tempArray[7] = currentTile-7;
		Debug.Log("Array" + tempArray[0] + ": " +
		          tempArray[1] + ": " +
		          tempArray[2] + ": " +
		          tempArray[3] + ": " +
		          tempArray[4] + ": " +
		          tempArray[5] + ": " +
		          tempArray[6] + ": " +
		          tempArray[7]
		          );

		return tempArray;
	}
}
