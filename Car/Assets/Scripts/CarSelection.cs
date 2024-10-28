using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CarSelection : MonoBehaviour
{
    [Header("Buttons")]
    public Button nextButton;
    public Button previousButton;
    
    private int currentCar;

    private void chooseCar(int index){
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(i==index);
            
        }
    }
    public void switchCar(int switchCar){
        currentCar+=switchCar;
        chooseCar(currentCar);

    }
    
    
}
