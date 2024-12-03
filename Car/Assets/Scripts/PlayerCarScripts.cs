using System;
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
    public float presentAcceleration= 0;
    public bool test; 
    
    
    [Header("Car steering")]
    public float wheelsTorque  = 35f;
    private float presentTurnAngle = 0f;


    [Header("Car Sounds")]
    public AudioSource audioSource;
    public AudioClip accelerationSound;
    public AudioClip slowAccelerationSound;
    public AudioClip stopSound;




    private void Update(){
        
        MoveCar();
        CarSteering();
        
        
    }
    
    private void MoveCar(){

        frontLeftWheelCollider.motorTorque = presentAcceleration;
        frontRightWheelCollider.motorTorque = presentAcceleration;
        backLeftCollider.motorTorque = presentAcceleration;
        backRightCollider.motorTorque = presentAcceleration;

        

        presentAcceleration = accelerationforce * 15 * SimpleInput.GetAxis("Vertical");
        if (presentAcceleration >0)
        
            audioSource.PlayOneShot(accelerationSound,0.2f);
        
        else if (presentAcceleration < 0)
           
            audioSource.PlayOneShot(slowAccelerationSound, 0.2f);

        else if(presentAcceleration == 0)
             
             audioSource.PlayOneShot(stopSound, 0.1f);
        }
         

private void CarSteering(){
    
    presentTurnAngle = wheelsTorque * SimpleInput.GetAxis("Horizontal");
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
// public void ApplyBreak(){
// StartCoroutine(carBreaks());
  
// }
// IEnumerator carBreaks(){

//     presentBreak = breakingForce;
   
        
//         backLeftCollider.brakeTorque =presentBreak ;
//         backRightCollider.brakeTorque = presentBreak;

//         yield return new WaitForSeconds(2f);
//         presentBreak =0f;
        
//         backLeftCollider.brakeTorque =presentBreak ;
//         backRightCollider.brakeTorque = presentBreak;


// }


public void Breaks(){
    StartCoroutine(Break());
}
    IEnumerator Break(){
        if (Input.GetKey(KeyCode.Space))
        {
            print("oldu");
            presentBreak = breakingForce;
            backLeftCollider.brakeTorque =presentBreak ;
            backRightCollider.brakeTorque = presentBreak;

            yield return new WaitForSeconds(2f);
            presentBreak =0f;
            
        }
    }



}
