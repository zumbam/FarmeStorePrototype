using UnityEngine;
using System.Collections;

public class trackPoint : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnDrawGizmos(){
		Gizmos.color = Color.black;
		Gizmos.DrawSphere (transform.position, 0);

	}
}
