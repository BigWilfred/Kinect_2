using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour {

    public Sprite rightCompleteSprite;
    public Sprite leftCompleteSprite;
    public Material rest;

    private CollisionCheck leftSide;
    private CollisionCheck rightSide;
    private Color colour;

	private GameObject crowd;
	private GameObject crowd1;

    private float timerLimit = 5.0f;

    private bool handsShowing = false;

    private void Start()
    {
        
        leftSide = GameObject.Find("touch1").GetComponent<CollisionCheck>();
        rightSide = GameObject.Find("touch2").GetComponent<CollisionCheck>();
        colour = GameObject.Find("touch1").GetComponent<Renderer>().material.color;
        colour = Color.red;
    }

    private void Update()
    {
        if (leftSide.CheckLeftSide() && rightSide.CheckRightSide())
        {
            float originalTimer = timerLimit;
            float alphaPercent = timerLimit / originalTimer;
            timerLimit -= Time.deltaTime;
            //Color colour = GameObject.Find("touch1").GetComponent<Renderer>().material.color;
            //colour.a = alphaPercent;
            

            if (timerLimit <= 0 && handsShowing == false)
            {

                //TINA HELP! why am i getting all these null pointers!
                //i think these shouldnt be in the Update, or have a flag for once 
                if (GameObject.Find("HandLeft") != null)
                {
                    SpriteRenderer leftHandSR = GameObject.Find("HandLeft").GetComponent<SpriteRenderer>();
                    leftHandSR.sprite = leftCompleteSprite;
                }

                if (GameObject.Find("HandRight") != null) {
                    SpriteRenderer rightHandSR = GameObject.Find("HandRight").GetComponent<SpriteRenderer>();
                    rightHandSR.sprite = rightCompleteSprite;
                }

                if (GameObject.Find("touch1") != null) {
                    GameObject.Find("touch1").SetActive(false);
                }
                if (GameObject.Find("touch2")) {
                    GameObject.Find("touch2").SetActive(false);
                }

                handsShowing = true;
            }
        }
        else {
            //reset timer if one hand leaves
            timerLimit = 5.0f;
        }
    }

    public bool CheckHandsShowing() {
        return handsShowing;
    }

}
