using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CarMove : MonoBehaviour
{
    public float Force, Steering, Breaking, turnInput, moveInput, turnSpeed;
    public WheelCollider FrontLeft, FrontRight, RearLeft, RearRight;

    private void Start()
    {
        
    }

    private void Update()
    {
        moveInput = Input.GetAxis("Vertical") * Force;
        turnInput = Input.GetAxis("Horizontal") * Steering;

        RearRight.motorTorque = moveInput;
        RearLeft.motorTorque = moveInput;

        FrontLeft.steerAngle = turnInput;
        FrontRight.steerAngle = turnInput;

        //if Q is pressed break
        if(Input.GetKey(KeyCode.Q))
        {
            //break
            RearLeft.brakeTorque = Breaking;
            RearRight.brakeTorque = Breaking;
        }


        if(Input.GetAxis("Vertical") == 0)
        {
            RearLeft.brakeTorque = Breaking;
            RearRight.brakeTorque = Breaking;
        }

    }
}
