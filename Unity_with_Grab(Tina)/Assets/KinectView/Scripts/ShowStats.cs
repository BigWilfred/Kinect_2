using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowStats : MonoBehaviour {

	public GameObject stats;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (gameObject.transform.childCount == 0) {
			StartCoroutine (show ());
		}
	}

	IEnumerator show(){
		// wait for some times for the stats to show up
		yield return new WaitForSeconds(5);
		if (GameObject.Find ("stats") == null) {
			GameObject newStats = Instantiate (stats);
			newStats.name = "stats";
		}
	}
}
