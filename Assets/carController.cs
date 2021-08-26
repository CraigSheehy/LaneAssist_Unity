using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carController : MonoBehaviour
{
    public float Force, Steering, Breaking;
    public WheelCollider FrontLeft, FrontRight, RearLeft, RearRight;

    private void Start()
    {

    }

    private void Update()
    {
        float vertical = Input.GetAxis("Vertical") * Force;
        float horizontal = Input.GetAxis("Horizontal") * Steering;

        RearRight.motorTorque = vertical;
        RearLeft.motorTorque = vertical;

        FrontLeft.motorTorque = horizontal;
        FrontRight.motorTorque = horizontal;

        //if Q is pressed break
        if (Input.GetKey(KeyCode.Q))
        {
            //break
            RearLeft.brakeTorque = Breaking;
            RearRight.brakeTorque = Breaking;
        }

        else
        {
            RearRight.brakeTorque = 0f;
            RearLeft.brakeTorque = 0f;
        }

        if (Input.GetAxis("Vertical") == 0)
        {
            RearLeft.brakeTorque = Breaking;
            RearRight.brakeTorque = Breaking;
        }

        else
        {
            RearLeft.brakeTorque = 0f;
            RearRight.brakeTorque = 0f;
        }
    }

}
