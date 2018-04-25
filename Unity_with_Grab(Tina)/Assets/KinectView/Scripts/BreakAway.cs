using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakAway : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// break away once it collide with the hands
	private void OnTriggerEnter(Collider other)
	{
		//if (other.gameObject.name == "normal"){
		if (other.gameObject.name == "HandLeft" || other.gameObject.name == "HandRight"){
			gameObject.GetComponent<Rigidbody> ().useGravity = true;
		}
	}

	// destroy the bin once go outside of the camera
	void OnBecameInvisible(){
		Destroy (gameObject);
	}
}
