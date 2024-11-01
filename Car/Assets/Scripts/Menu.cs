using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [Header("All Menu")]
    public GameObject pauseMenuUI;
    public static bool GameIsStopped;
    
        public void Resume(){
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsStopped = false;
         }

         public void Pause(){
            pauseMenuUI.SetActive(true);
            Time.timeScale = 0f;
            GameIsStopped = true;
         }
         

         public void Restart(){
            SceneManager.LoadScene("SampleScene");
            Time.timeScale = 1f;
         }
         public void LoadMenu(){
            SceneManager.LoadScene("GarageScene");
            Time.timeScale = 1f;
         }
         public void QuitMenu(){
            Debug.Log("quitting now");
            Application.Quit();
         }
    
}
