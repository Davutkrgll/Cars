using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCarScripts : MonoBehaviour
{
    [Header("Wheels collider")]
    public WheelCollider frontLeftWheelCollider;
    public WheelCollider frontRightWheelCollider;
    public WheelCollider backLeftCollider;
    public WheelCollider backRightCollider;

    [Header("Wheels transform")]
    public Transform frontLeftWheelTransform;
    public Transform frontRightWheelTransform;
    public Transform backLeftWheelTransform;
    public Transform backRightWheelTransform;

    [Header("Car Engine")]
    public float accelerationforce = 3000f;
    public float breakingForce = 3000f;
    public float presentBreak=0;
    private float presentAcceleration= 0;
    
    
    [Header("Car steering")]
    public float wheelsTorque  = 35f;
    private float presentTurnAngle =0f;



    private void Update(){
        
        MoveCar();
        CarSteering();
    }
    
    private void MoveCar(){

        frontLeftWheelCollider.motorTorque = presentAcceleration;
        frontRightWheelCollider.motorTorque = presentAcceleration;

        presentAcceleration = accelerationforce * Input.GetAxis("Vertical");
        }
        

private void CarSteering(){
    
    presentTurnAngle = wheelsTorque * Input.GetAxis("Horizontal");
    frontLeftWheelCollider.steerAngle = presentTurnAngle;
    frontRightWheelCollider.steerAngle = presentTurnAngle;
}
    



}
