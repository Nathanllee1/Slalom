using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class PlayerController : MonoBehaviour
{
    
    Rect LeftControlSurface = new Rect(0, 0, Screen.width / 5, Screen.height);
    //add the right side (figure it out)
   
    public float thrust = 50;
    public float stabilizer = 100;
    public Rigidbody testPush;
    public float twistForce = 500;

    private void Awake()
    {
        
    }
    void FixedUpdate()
    {
        testPush.AddForce(transform.forward * thrust);
        testPush.AddForce(0, stabilizer, 0);

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


/*
using UnityEngine;
using System.Collections;

public class ExampleClass : MonoBehaviour
{
    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;
    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;

        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }

}
*/

