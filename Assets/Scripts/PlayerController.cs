using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class PlayerController : MonoBehaviour
{
    //general
    public Rigidbody Liam;


    //change aspects of control
    public float stabilizer = 100;
    public float twistSpeed = 5;
    public float testboost = 200;
    public float swipeForce = 20;

    //translate to force
    private float forwardForce;

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
    




    private void Awake()
    {
        Liam = GetComponent<Rigidbody>();
        LeftControlSurface = new Rect(0, 0, Screen.width / 2, Screen.height);
        RightControlSurface = new Rect(Screen.width / 2, 0, Screen.width / 2, Screen.height);
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

                //Touch touch = Input.GetTouch(0);
                if (LeftControlSurface.Contains(touch.position))
                {

                    Liam.AddTorque(0, -twistSpeed, 0);
                    Debug.Log("Left" + "Strength = " + forwardForce + "Speed = " + speed + "Distance = " + DragDistance);
                    Liam.AddForce(transform.forward * forwardForce);
                    //stick animation and sound here
                }
                if (RightControlSurface.Contains(touch.position))
                {

                    Liam.AddTorque(0, twistSpeed, 0);
                    Debug.Log("Right" + "Strength = " + forwardForce + "Speed = " + speed + "Distance = " + DragDistance);
                    Liam.AddForce(transform.forward * forwardForce);
                }

           
            }
        }

    }
}

/*
if (diffTime != 0)
            {
                
            }

            if (speed != Vector2.zero)
            {
                Debug.Log("startTime / diffTime = " + startTime + "/" + diffTime);
            }
*/