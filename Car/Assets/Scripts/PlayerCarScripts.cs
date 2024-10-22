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
    public float accelerationforce = 300f;
    public float breakingForce = 3000f;
    public float presentBreak=0;
    private float presentAcceleration= 0;
    
    
    [Header("Car steering")]
    public float wheelsTorque  = 35f;
    private float presentTurnAngle = 0f;



    private void Update(){
        
        MoveCar();
        CarSteering();
        ApplyBreak();
    }
    
    private void MoveCar(){

        frontLeftWheelCollider.motorTorque = presentAcceleration;
        frontRightWheelCollider.motorTorque = presentAcceleration;
        backLeftCollider.motorTorque = presentAcceleration;
        backRightCollider.motorTorque = presentAcceleration;

        

        presentAcceleration = accelerationforce * 15 * Input.GetAxis("Vertical");
        }
        

private void CarSteering(){
    
    presentTurnAngle = wheelsTorque * Input.GetAxis("Horizontal");
    frontLeftWheelCollider.steerAngle = presentTurnAngle;
    frontRightWheelCollider.steerAngle = presentTurnAngle;

    SteeringWheels(frontLeftWheelCollider,frontLeftWheelTransform);
    SteeringWheels(frontRightWheelCollider,frontRightWheelTransform);
    SteeringWheels(backLeftCollider,backLeftWheelTransform);
    SteeringWheels(backRightCollider,backRightWheelTransform);
    
}

void SteeringWheels(WheelCollider wheelcol, Transform wheeltrans){
    Vector3 position;
    Quaternion rotation;

    wheelcol.GetWorldPose(out position, out rotation);
     rotation = rotation * Quaternion.Euler(new Vector3(0, 90, 0));

    wheeltrans.position = position;
    wheeltrans.rotation = rotation;

}
public void ApplyBreak(){
    if (Input.GetKey(KeyCode.Space))
    presentBreak= breakingForce*15 ;
     else
     presentBreak = 0f;

        frontLeftWheelCollider.brakeTorque =presentBreak ;
        frontRightWheelCollider.brakeTorque =presentBreak;
        backLeftCollider.brakeTorque =presentBreak ;
        backRightCollider.brakeTorque = presentBreak;

    
}
    



}
