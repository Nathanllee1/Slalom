using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class PlayerController : MonoBehaviour
{
    //change aspects of control
    public float stabilizer = 100;
    public Rigidbody Liam;
    public float twistSpeed = 5;
    public float testboost = 200;

    /*
    private Vector3 fp;
    private Vector3 lp;
    private float dragDistance;
    //private List<Vector3> touchPositions = new List<Vector3>();
    */

    //control surfaces
    private Rect LeftControlSurface;
    private Rect RightControlSurface;
    private float ControlOffTime;


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
        //Liam.AddForce(transform.forward * thrust);
        //Liam.AddForce(0, stabilizer, 0);
        //Liam.AddTorque(-transform.right * twistSpeed);


        
        Liam.AddForce(transform.forward * testboost);

        //taps

        if (Input.touchCount > 0) //check amount of touches
        {
            //Liam.AddTorque(-transform.right * twistSpeed);

            Touch touch = Input.GetTouch(0);
            if (LeftControlSurface.Contains(touch.position))
            {
                //float v = Input.GetAxis("Vertical") * twistSpeed * Time.deltaTime;
                //Liam.AddTorque(transform.up * v);
                Liam.AddTorque(0, -twistSpeed, 0);
                Debug.Log("Left");
                
            }
            if (RightControlSurface.Contains(touch.position))
            {
                //Liam.AddForce(1, 4, thrust, ForceMode.Impulse);
                //transform.Rotate(Vector3.right * Time.deltaTime * twistSpeed);
                //float v = Input.GetAxis("Vertical") * twistSpeed * Time.deltaTime;
                Liam.AddTorque(0, twistSpeed, 0);
                Debug.Log("Right");
            }
        }


        //swipes
        
        
    }
}

/*
foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                startPos = touch.position;
                startTime = Time.time;
            }

            if(touch.phase == TouchPhase.Ended)
            {
                endPos = touch.position;
                diffTime = Time.time - startTime;
                startTime = 0;
            }

            DragDistance = (startPos - endPos).magnitude;


            if (diffTime != 0)
            {
                speed = DragDistance / diffTime;
            }

            if (speed != Vector2.zero)
            {
                Debug.Log("startTime / diffTime = " + startTime + "/" + diffTime);
            }
            //Turn swipelength into force
            
        }

*/