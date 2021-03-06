using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kinect = Windows.Kinect;

public class DragAndDrop : MonoBehaviour {

	private bool draggingItem = false;
	private bool colliding = false;
	private bool rotate = false;
	private GameObject draggedObject;
	private Vector3 mLastPosition;

	private Vector3 previousGrabPosition;

    


    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		if (draggingItem) {
			//draggedObject.transform.Rotate(new Vector3(0,0,Time.deltaTime*500));
		}
		InvokeRepeating("calculateSpeed", 0f,5.0f);
		mLastPosition = transform.position;

    }

	public void DragOrPickUp(string gameObjectName)
	{
        //position of HandLeft or HandRight
        Vector3 inputPosition = GameObject.Find(gameObjectName).transform.position;

        Debug.Log("__________");
        if (colliding && draggedObject!=null) {

            draggingItem = true;
			draggedObject.GetComponent<Rigidbody> ().useGravity = false;
			//previousGrabPosition = draggedObject.transform.position;
			// so the object won't go drag through floor
			if (inputPosition.y > -5.48) {
                draggedObject.transform.position = inputPosition;

            } else {
				draggedObject.transform.position = new Vector3 (inputPosition.x, -5.48f, inputPosition.z);
			}
		} else {
			draggingItem = false;
		}

	}

	void calculateSpeed(){
		if (transform.position != mLastPosition && draggingItem) {
			rotate = true;
		} else {
			rotate = false;
		}

	}
		

	void OnTriggerEnter (Collider col)
	{
        string draggedName = col.ToString();
        string[] split = draggedName.Split('(');

        if (split[0] == "bin") {
            colliding = true;
            draggedObject = col.gameObject;
            previousGrabPosition = draggedObject.transform.position;

        } else {
            Debug.Log("out of bin");
            colliding = false;
		}
	}

    
	void OnTriggerExit (Collider col)
	{
		Debug.Log ("exit");
		draggingItem = false;
		colliding = false;
		if (draggedObject != null) {
			//previousGrabPosition = draggedObject.transform.position;
			//DropItem ();
		}
	}


	public bool getDrag(){
		return draggingItem;
	}

	public void DropItem()
	{
        
		// throwing the object base on length between start and end object position

		Rigidbody rb = draggedObject.GetComponent<Rigidbody> ();

		Vector3 throwVector = draggedObject.transform.position - previousGrabPosition;
        Debug.Log(draggedObject.transform.position);
        Debug.Log(previousGrabPosition);
        
        //float speed = throwVector.magnitude / Time.deltaTime;
        float speed = throwVector.magnitude / 1f;

		Vector3 throwVelocity = speed * throwVector.normalized;
		rb.velocity = throwVelocity;
		draggingItem = false;
		draggedObject.GetComponent<Rigidbody> ().useGravity = true;

	}
		
}
