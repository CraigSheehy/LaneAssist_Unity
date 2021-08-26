using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarAI2 : MonoBehaviour
{
    private float speed = 15;
    public Transform leftSphere;
    public Transform rightSphere;

    private void FixedUpdate()
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.AddForce(transform.forward * speed);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.LookAt(leftSphere);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.LookAt(rightSphere);
        }
    }
}
