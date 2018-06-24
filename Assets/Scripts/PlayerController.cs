using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class PlayerController : MonoBehaviour
{
    
    Rect LeftControlSurface = new Rect(0, 0, Screen.width / 2, Screen.height);
    Rect RightControlSurface = new Rect(Screen.width / 2, 0, Screen.width / 2, Screen.height);
    
   
    public float thrust = 50;
    public float stabilizer = 100;
    public Rigidbody Liam;
    public float twistSpeed = 500;

    private void Awake()
    {
        
    }
    void Update()
    {
        //Liam.AddForce(transform.forward * thrust);
        //Liam.AddForce(0, stabilizer, 0);

        

        if (Input.touchCount > 0) //check amount of touches
        {
            Touch touch = Input.GetTouch(0);
            if (LeftControlSurface.Contains(touch.position))
            {
                transform.Rotate(Vector3.left * Time.deltaTime * twistSpeed);
            }
            if (RightControlSurface.Contains(touch.position))
            {
                //Liam.AddForce(1, 4, thrust, ForceMode.Impulse);
                transform.Rotate(Vector3.left * Time.deltaTime * twistSpeed);

            }
        }
    }
}


