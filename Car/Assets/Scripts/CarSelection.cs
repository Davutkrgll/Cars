using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class CarSelection : MonoBehaviour
{
    [Header("Buttons")]
    public Button nextButton;
    public Button previousButton;
    
    private int currentCar;
    private GameObject[]  carList;
    private void Awake(){
        chooseCar(0);
    }
    
    private void Start(){
        currentCar = PlayerPrefs.GetInt("CarSelected");



        carList = new GameObject[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
             carList[i] = transform.GetChild(i).gameObject;

            foreach (GameObject gameob in carList)
                 gameob.SetActive(false);
                
            if (carList[currentCar])
                carList[currentCar].SetActive(true);
                
            
        
            }

    private void chooseCar(int index){
        
        previousButton.interactable = (currentCar != 0);
        nextButton.interactable =(currentCar != transform.childCount -1);

        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(i == index);
            
        }
    }
    public void switchCar(int switchCar){
        currentCar += switchCar;
        chooseCar(currentCar);

    }
    public void PlayGame(){
        PlayerPrefs.SetInt("CarSelected", currentCar);
        SceneManager.LoadScene("SampleScene");
    }
    
}
