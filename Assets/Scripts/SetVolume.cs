using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;

public class SetVolume : MonoBehaviour
{
    //Which volumes will we be touching?
    public AudioMixer musicMixer;
    public AudioMixer effectMixer;
    public void SetMusicLevel(float musicSliderValue)
    {
        //Wherever the slider is, change the volume of said mixer
        musicMixer.SetFloat("MusicVolume", Mathf.Log10(musicSliderValue) * 20);
    }
    public void SetSFXLevel(float effectSliderValue)
    {
        //Wherever the slider is, change the volume of said mixer
        effectMixer.SetFloat("SFXVolume", Mathf.Log10(effectSliderValue) * 20);
    }
}
