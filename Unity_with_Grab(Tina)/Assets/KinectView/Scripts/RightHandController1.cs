using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightHandController1 : MonoBehaviour {

	private Vector3 mousePos;

	// Use this for initialization
	void Start () {
	}


	// for testing collision without kinect
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			Vector3 position = this.transform.position;
			position.x-=0.03f;
			this.transform.position = position;
		}
		if (Input.GetKey(KeyCode.RightArrow))
		{
			Vector3 position = this.transform.position;
			position.x+=0.03f;
			this.transform.position = position;
		}
		if (Input.GetKey(KeyCode.UpArrow))
		{
			Vector3 position = this.transform.position;
			position.y+=0.03f;
			this.transform.position = position;
		}
		if (Input.GetKey(KeyCode.DownArrow))
		{
			Vector3 position = this.transform.position;
			position.y-=0.03f;
			this.transform.position = position;
		}

	}
		
		
}
