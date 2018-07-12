using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfRighter : MonoBehaviour {

    public Transform target;
    public float RightSpeed = 40;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        var pointUp = Quaternion.RotateTowards(gameObject.transform.rotation, Quaternion.LookRotation(transform.up), Time.deltaTime * RightSpeed);
        gameObject.transform.rotation = pointUp;
    } 
    
            
        

}
