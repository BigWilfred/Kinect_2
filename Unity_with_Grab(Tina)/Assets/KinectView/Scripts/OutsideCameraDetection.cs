using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutsideCameraDetection : MonoBehaviour {

	private AnimationAndMovement movement;

	// Use this for initialization
	void Start () {
		GameObject person = GameObject.Find ("person");
		movement = person.GetComponent<AnimationAndMovement> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// destroy the bin once go outside of the camera
	void OnBecameInvisible(){
		Destroy (gameObject);
		movement.setLocation(-6.2f);
	}
}
