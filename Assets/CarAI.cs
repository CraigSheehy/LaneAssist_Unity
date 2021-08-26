using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarAI : MonoBehaviour
{
    private CarController carController;
    private int nextHitNumber = 0;
    private CarController.CarDirection[] directions =
    {
        CarController.CarDirection.Left,
        CarController.CarDirection.Forward,
        CarController.CarDirection.Forward,
        CarController.CarDirection.Left
    };

    private void Awake()
    {
        carController = GetComponent<CarController>();
    }

    void OnTriggerEnter(Collider hit)
    {
        print("You hit something with tag = " + hit.tag);
        if(hit.CompareTag("OpenCV"))
        {
            CarController.CarDirection direction = directions[nextHitNumber];
            carController.Go(direction);
            nextHitNumber++;
        }
    }


}
