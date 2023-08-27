using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class OptionsController : MonoBehaviour
{
    public Slider slider;
    public float sliderValue;
    public Image imagenMute;

    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("Sound", 0.5f);
        AudioListener.volume = slider.value;
        IsMuted();
    }

    // Update is called once per frame
    public void ChangeSlider(float valor)
    {
        sliderValue = valor;
        PlayerPrefs.SetFloat("Sound", sliderValue);
        AudioListener.volume = slider.value;
        IsMuted();
    }
    public void IsMuted(){
        if (sliderValue == 0) imagenMute.enabled= true;
        else imagenMute.enabled=false;
    }
}
