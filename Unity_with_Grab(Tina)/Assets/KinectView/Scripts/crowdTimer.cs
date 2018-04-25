using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crowdTimer : MonoBehaviour {

	private float targetTime = 10.0f;
	public GameObject crowd;
	public GameObject crowd1;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		targetTime -= Time.deltaTime;
		//Debug.Log (targetTime);
		if ((2.0f < targetTime) && (targetTime < 3.0f)) {
			if (GameObject.Find ("crowd") == null) {
				GameObject newcrowd = Instantiate (crowd);
				newcrowd.name = "crowd";
			}
		} else if (targetTime <= 0.0f) {
			if (GameObject.Find ("crowd1") == null) {
				GameObject newcrowd1 = Instantiate (crowd1);
				newcrowd1.name = "crowd1";
			}
		}
	}
}
