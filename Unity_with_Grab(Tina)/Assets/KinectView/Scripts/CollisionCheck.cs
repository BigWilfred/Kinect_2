using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCheck : MonoBehaviour {

    private bool leftHand = false;
    private bool rightHand = false;

    private void OnTriggerEnter(Collider other)
    {
        string hand = other.ToString();
        string[] split = hand.Split(' ');

        if (split[0].Equals("HandLeft"))
        {
            leftHand = true;

        }
        if (split[0].Equals("HandRight"))
        {
            rightHand = true;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        string hand = other.ToString();
        string[] split = hand.Split(' ');

        if (split[0].Equals("HandLeft"))
        {
            leftHand = false;
        }
        if (split[0].Equals("HandRight"))
        {
            rightHand = false;
        }
    }

    public bool CheckLeftSide() {
        return leftHand;
    }
    public bool CheckRightSide()
    {
        return rightHand;
    }
}
