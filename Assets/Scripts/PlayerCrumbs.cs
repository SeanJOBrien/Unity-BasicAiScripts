using UnityEngine;
using System.Collections;

public class PlayerCrumbs : MonoBehaviour {

	private Vector3 LastCrumb;
	// Use this for initialization
	void Start () {
		dropCrumb();
	}
	
	// Update is called once per frame
	void Update () {
		if( Vector3.Distance(gameObject.transform.position, LastCrumb)>2.2){
			dropCrumb();
		}
	}

	void dropCrumb() {
		GameObject ball = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		ball.transform.position = new Vector3(transform.position.x,1.0f,transform.position.z);
		MeshRenderer otherScript = ball.GetComponent<MeshRenderer>();
		otherScript.renderer.enabled = false;
		LastCrumb = ball.transform.position;
		ball.tag = "breadCrumb";
		Destroy(ball,3.0f);
	}
}
