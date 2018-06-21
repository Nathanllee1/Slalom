using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform target;

    void Update()
    {
        if (target)
        {
            transform.position = Vector3.Lerp(transform.position, target.position, 0.1f) + new Vector3 (0, 1, 1);
        }
    }
}