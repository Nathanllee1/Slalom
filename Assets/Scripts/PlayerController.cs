using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class PlayerController : MonoBehaviour
{
    
    
    
   
    
    public float stabilizer = 100;
    public Rigidbody Liam;
    public float twistSpeed = 5;
    public float testboost = 200;

    private Vector3 fp;
    private Vector3 lp;
    private float dragDistance;
    //private List<Vector3> touchPositions = new List<Vector3>();

    private Rect LeftControlSurface;
    private Rect RightControlSurface;

    private void Awake()
    {
        Liam = GetComponent<Rigidbody>();
        Debug.Log("DebugLog");
        Rect LeftControlSurface = new Rect(0, 0, Screen.width / 2, Screen.height);
        Rect RightControlSurface = new Rect(Screen.width / 2, 0, Screen.width / 2, Screen.height);
    }
    void Update()
    {
        //Liam.AddForce(transform.forward * thrust);
        //Liam.AddForce(0, stabilizer, 0);
        //Liam.AddTorque(-transform.right * twistSpeed);
        Liam.AddForce(transform.forward * testboost);

        


        if (Input.touchCount > 0) //check amount of touches
        {
            //Liam.AddTorque(-transform.right * twistSpeed);

            Touch touch = Input.GetTouch(0);
            if (LeftControlSurface.Contains(touch.position))
            {
                Liam.AddTorque(-transform.up * twistSpeed);
                Debug.Log("Left");
            }
            if (RightControlSurface.Contains(touch.position))
            {
                //Liam.AddForce(1, 4, thrust, ForceMode.Impulse);
                //transform.Rotate(Vector3.right * Time.deltaTime * twistSpeed);
                Liam.AddTorque(transform.up * twistSpeed);
                Debug.Log("Right");
            }
        }
    }
}


