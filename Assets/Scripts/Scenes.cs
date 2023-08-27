using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Scenes : MonoBehaviour
{
   [SerializeField] private GameObject settingsButton;
   [SerializeField] private GameObject settings;
   [SerializeField] private GameObject loadimage;
   public void LoadScene(string nameScene){
      loadimage.SetActive(true);
      SceneManager.LoadScene(nameScene);
      Time.timeScale = 1f;
   }
   public void EnterSettings(){
      settingsButton.SetActive(false);
      settings.SetActive(true);
   }
   public void ExitSettings(){
      settingsButton.SetActive(true);
      settings.SetActive(false);
   }
}
