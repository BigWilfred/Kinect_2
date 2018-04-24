using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kinect = Windows.Kinect;

public class RightHandController : MonoBehaviour {

    public GameObject bin;
	private DragAndDrop dropLeft;
	private DragAndDrop dropRight;

    private BodySourceView bodySourceView;
    private Vector3 mousePos;
    private Kinect.Body chosenBody;
    private BodySourceView bodyView;
    private CollisionManager collisionManager;

    private int binCount = 0;

    //private GameObject binObject;
    // Use this for initialization
    void Start () {
        

        bodyView = GameObject.Find("BodyView").GetComponent<BodySourceView>();
        chosenBody = bodyView.getTrackedBody();

        bodySourceView = GameObject.Find("BodyView").GetComponent<BodySourceView>();

        collisionManager = GameObject.Find("CollisionManager").GetComponent<CollisionManager>();
    }



	// Update is called once per frame
	void Update () {
        //mousePos =  (GameObject.Find("HandLeft").transform.position);
        //transform.position = mousePos;

        //Debug.Log(GameObject.Find("HandLeft").transform.position);

        if (GameObject.Find("HandLeft") != null) {
            dropLeft = GameObject.Find("HandLeft").GetComponent<DragAndDrop>();
        }
        if (GameObject.Find("HandRight") != null) {
            dropRight= GameObject.Find("HandRight").GetComponent<DragAndDrop>();
        }

        //creates initial bin
        if (collisionManager.CheckHandsShowing() && GameObject.Find("bin(Clone)") == null) {

            Transform tester = new GameObject().transform;

            Debug.Log(tester.ToString());
            GameObject newBin = Instantiate(bin, tester);

        }


        if (bodySourceView.getLeftCloseFlag() && gameObject.name == "HandLeft") {
            dropLeft.DragOrPickUp("HandLeft");
        }
        if (bodySourceView.getRightCloseFlag() && gameObject.name == "HandRight") {
            dropRight.DragOrPickUp("HandRight");
        }

        //if hand is open
        if (!bodySourceView.getLeftCloseFlag() && gameObject.name == "HandLeft" && dropLeft.getDrag())
        {
            dropLeft.DropItem();
        }
        //this is to check whether the hand are active


        /*
        if (HasInput) {
			drop.DragOrPickUp ();
		} else {
			if (drop.getDrag()) {
				drop.DropItem();
			}
		}
        */
    }

}
