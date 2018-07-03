﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class PlayerController : MonoBehaviour
{
    //general
    public Rigidbody Liam;
    private Touch touches;


    //change aspects of control
    public float stabilizer = 100;
    public float twistSpeed = 5;
    public float swipeTwistSpeed = 5;
    public float swipeForce = 20;

    //translate to force
    private float forwardForce;
    public float swipeOrTap = 440;

    //control surfaces
    private Rect LeftControlSurface;
    private Rect RightControlSurface;

    //swipe
    private Vector2 startPos;
    private Vector2 endPos;
    private float diffTime;
    private float startTime;
    private Vector2 DragDistance;
    private float speed;

    //detection
    private bool Swipe;
    private bool upDown;
    



    private void Awake()
    {
        Liam = GetComponent<Rigidbody>();
        LeftControlSurface = new Rect(0, 0, Screen.width / 2, Screen.height);
        RightControlSurface = new Rect(Screen.width / 2, 0, Screen.width / 2, Screen.height);
        Touch touch = Input.GetTouch(0);
    }

    void Update()
    {
        if (Input.touchCount > 0) //check amount of touches
        {
            //all the control scripts
            foreach (Touch touch in Input.touches)
            {
                if (touch.phase == TouchPhase.Began)
                {
                    Vector2 startPos = touch.position;
                    float startTime = Time.time;
                }

                if (touch.phase == TouchPhase.Ended)
                {
                    endPos = touch.position;
                    diffTime = Time.time - startTime;
                    startTime = 0;
                }


                float XDist = Mathf.Abs(startPos.x - endPos.x);
                float YDist = Mathf.Abs(startPos.y - endPos.y);

                //Pythagorean
                float DragDistance = Mathf.Sqrt(XDist * XDist + YDist * YDist);
                

                float speed = DragDistance / diffTime;


                //Turn swipelength into force
                float forwardForce = speed * swipeForce * DragDistance;


                //Implement it all

                
                //Check if it's a swipe or a tap
                if (DragDistance < swipeOrTap)
                {
                    twistSpeed = swipeTwistSpeed;
                    Swipe = true;
                }

                //Touch touch = Input.GetTouch(0);
                
            }
        
        }
    }
    void swipeToForce()
    {
        foreach (Touch touch in Input.touches)
        {
            if (LeftControlSurface.Contains(touch.position))
            {

                Liam.AddTorque(0, twistSpeed, 0);
                Debug.Log("Left" + "Strength = " + forwardForce + " Speed = " + speed + " Distance = " + DragDistance + " Time = " + diffTime);
                Liam.AddForce(transform.forward * forwardForce);
                //stick animation and sound here
            }
            if (RightControlSurface.Contains(touch.position))
            {

                Liam.AddTorque(0, -twistSpeed, 0);
                Debug.Log("Right" + " Strength = " + forwardForce + " Speed = " + speed + " Distance = " + DragDistance + " Time = " + diffTime);
                Liam.AddForce(transform.forward * forwardForce);
            }
        }
    }
}
/*
void touchController()
{
    //Touch touch = Input.GetTouch(0);
    if (LeftControlSurface.Contains(touch.position))
    {

        Liam.AddTorque(0, twistSpeed, 0);
        Debug.Log("Left" + "Strength = " + forwardForce + " Speed = " + speed + " Distance = " + DragDistance + " Time = " + diffTime);
        Liam.AddForce(transform.forward * forwardForce);
        //stick animation and sound here
    }
    if (RightControlSurface.Contains(touch.position))
    {

        Liam.AddTorque(0, -twistSpeed, 0);
        Debug.Log("Right" + " Strength = " + forwardForce + " Speed = " + speed + " Distance = " + DragDistance + " Time = " + diffTime);
        Liam.AddForce(transform.forward * forwardForce);
    }
}
*/