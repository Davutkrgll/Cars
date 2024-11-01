using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OpponentCarWaypoints : MonoBehaviour
{
    [Header("Opponent Car")]
    public OpponentCar opponentCar;
    public WayPoints currentWayPoint;

    private void Awake(){
        opponentCar = GetComponent<OpponentCar>();
        
    }
    private void Start(){

       opponentCar.LocateDestination(currentWayPoint.GetPosition());

    }

    private void Update(){

        
       
        
        if (opponentCar.destinationReached==true)
        {
            currentWayPoint = currentWayPoint.nextWayPoint;
            opponentCar.LocateDestination(currentWayPoint.GetPosition());
        }
    }
}
