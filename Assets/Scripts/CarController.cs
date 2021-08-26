using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CarController : MonoBehaviour
{
    public enum CarDirection
    {
        Left, Right, Forward
    }

    private NavMeshAgent navMeshAgent;
    public Transform leftSphere;
    public Transform rightSphere;
    public Transform forwardSphere;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        GoForward();
    }

    private void Update()
    {

        float closeToDestinaton = navMeshAgent.stoppingDistance * 2;
        if (navMeshAgent.remainingDistance < closeToDestinaton)
        {
            GoForward();
        }
        CheckKeys();
        
    }

   

    // Update is called once per frame
    private void CheckKeys()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            GoLeft();
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            GoRight();
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            GoForward();
        }
    }

    public void GoForward()
    {
        navMeshAgent.SetDestination(forwardSphere.position);
    }

    public void GoLeft()
    {
        navMeshAgent.SetDestination(leftSphere.position);
    }

    public void GoRight()
    {
        navMeshAgent.SetDestination(rightSphere.position);
    }

    public void Go(CarDirection newDirection)
    {
        switch(newDirection)
        {
            case CarDirection.Left:
                GoLeft();
                break;
            case CarDirection.Right:
                GoRight();
                break;
            case CarDirection.Forward:
                GoForward();
                break;
        }
    }
}
