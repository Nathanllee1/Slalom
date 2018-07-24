
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class PlayerControllerSki : MonoBehaviour
{
    //general
    public Rigidbody Liam;
    private Touch touch;

    RaycastHit hit;


    //change aspects of control
    public float stabilizer = 100;
    public float twistSpeed = 5;
    public float swipeTwistSpeed = 5;
    public float swipeForce = 20;

    //translate to force
    //private float forwardForce;
    public float swipeOrTap = 440;

    //control surfaces
    private Rect LeftControlSurface;
    private Rect RightControlSurface;

    //swipe
    private Vector2 startPos;
    private Vector2 endPos;
    private float diffTime;
    private float startTime;
    private float DragDistance;
    private float speed;
    private float XDist;
    private float YDist;

    //detection
    private bool Swipe;
    private bool upDown;
    private bool touchCheck;

    //tester to check distance from ground
    private float groundDistance;


    public float testBoost = 800;


    void Awake()
    {
        Liam = GetComponent<Rigidbody>();
        LeftControlSurface = new Rect(0, 0, Screen.width / 2, Screen.height);
        RightControlSurface = new Rect(Screen.width / 2, 0, Screen.width / 2, Screen.height);
        //Touch touch = Input.GetTouch(0);
    }
    
    void FixedUpdate()
    {
        //Liam.AddForce(transform.forward * testBoost);



        //keep the player stable at ground level
        //groundDistance = Physics.Raycast(Liam.position, Vector3.down);
        
        if (Physics.Raycast(transform.position, -Vector3.down, out hit))
        {
            print("Found an object - distance: " + hit.distance);
        }
        

        if (Input.touchCount > 0) //check amount of touches
        {
            touchCheck = true;
            Debug.Log("Touch detected");
            
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
                float forwardForce = speed * DragDistance;
                Debug.Log("Amount of force is" + forwardForce);



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

                if (Input.touchCount == 0)
                {

                    Debug.Log("Stopped");
                }
            }
        }

        
    }

    void swipeToForce()
    {
        
    }


    void implementControl(float forwardForce)
    {
        
    }

    void touchType()
    {
        //Check if it's a swipe or a tap
        if (DragDistance < swipeOrTap)
        {
            twistSpeed = swipeTwistSpeed;
            Swipe = true;
        }
        Debug.Log("Touch check is working");
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