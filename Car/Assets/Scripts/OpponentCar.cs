using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentCar : MonoBehaviour
{
    [Header("Car Engine")]
    public float movingSpeed;
    public float turningSpeed = 12f;
    public float breakSpeed = 50f;
    
    [Header("Destination var")]
    public Vector3 destination;
    public bool destinationReached;

    private void Update(){
        Drive();
        print(destinationReached);
    }
    public void Drive(){
        if (transform.position !=destination)
        {
            Vector3 destinationDirection = destination - transform.position;
            destinationDirection.y = 0;
            float destinationDistance = destinationDirection.magnitude;
            if (destinationDistance >= breakSpeed)
            {
                //Steering
                destinationReached = false;
                Quaternion targetRotation =Quaternion.LookRotation(destinationDirection);
                transform.rotation =Quaternion.RotateTowards(transform.rotation,targetRotation, turningSpeed * Time.deltaTime);
                //move vehicle
                transform.Translate(Vector3.forward*movingSpeed*Time.deltaTime);
            }
            else
            {
                destinationReached = true;
            }
        }
    }

    public void LocateDestination(Vector3 destination){
        this.destination=destination;
        destinationReached = false;
    }
}
