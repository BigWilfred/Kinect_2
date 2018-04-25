using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// class to move the person, sure to later changed to Stuart's animation
// But a png will do for now
public class AnimationAndMovement : MonoBehaviour {
	public GameObject bin;
	public GameObject brench;
	public GameObject part;
	public Sprite personOnBrench;
	private Vector3 location;
	private float speed = 2f;
	private float step;

	// Use this for initialization
	void Start () {
		// start position to move to
		location.x = 14.19f;
		//location.x = -8.19f;
		location.y = -2.35f;
	}
	
	// Update is called once per frame
	void Update () {
		step = speed * Time.deltaTime;
		// moving the character in
		moveCharacter();
	}

	public void setLocation (float toLocation){
		location.x = toLocation;
	}

	public void moveCharacter (){
		if (!transform.position.Equals(location)) {
			transform.position = Vector3.MoveTowards (transform.position, location, step);
		} 
	}


	void OnTriggerEnter (Collider col)
	{
		if (col.gameObject.name == "bench"){
			location = transform.position;
			Destroy (gameObject);
			SpriteRenderer brenchSprite = col.gameObject.GetComponent<SpriteRenderer>();
			brenchSprite.sprite = personOnBrench;
			if (GameObject.Find ("PersonParts") == null) {
				GameObject newpart = Instantiate (part);
				newpart.name = "PersonParts";
			}
		}
	}
		
}
