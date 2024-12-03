using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RoadController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {    

    }
    private void OnTriggerEnter(Collider collider){
        transform.position += new Vector3(transform.GetComponent<Renderer>().bounds.size.x * -2, 0, 0);
        Debug.Log("oldu");}
    
}
