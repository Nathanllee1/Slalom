using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
public class PlayerController : MonoBehaviour
{
    void Start()
    {
        
    }
    // Update is called once per frame
    private void Update()
    {
        public Rect LeftControlSurface = new Rect(0, 0, Screen.width / 5, Screen.height);
        
        if (Input.touchCount > 0) {//check if there is touch
    

       
        

            Touch touch = Input.GetTouch(0);
            Rect LeftControlSurface;
            if (LeftControlSurface.Contains(touch.position))
            {

            }

        }    
}
*/


public class PlayerController : MonoBehaviour
{
    public Rect LeftControlSurface = new Rect(0, 0, Screen.width / 5, Screen.height);
    //add the right side (figure it out)

    float thrust = 50;
    public Rigidbody testPush;

    private void Awake()
    {
        testPush = GetComponent<Rigidbody>();
    }
    void Update()
    {
        testPush.AddForce(transform.forward * thrust);

        if (Input.touchCount > 0) //check amount of touches
        {
            Touch touch = Input.GetTouch(0);
            if (LeftControlSurface.Contains(touch.position))
            {
                testPush.AddForce(-1, 4, thrust, ForceMode.Impulse);
            }
        }
    }
}
    
  
