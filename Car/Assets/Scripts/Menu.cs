using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [Header("Menu UI var")]
    public GameObject menuUI;

    public void Update(){
 if (Input.GetKeyDown(KeyCode.Escape))
        {
            menuUI.SetActive(true);
        }
        
            
        
    }
   
}
