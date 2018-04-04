using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeSliders : MonoBehaviour {

    public Slider volSlider;
    public AudioMixer mixer;
    //private float value;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        mixer.SetFloat("Volume", volSlider.value);
        //mixer.GetFloat("Volume", out value);
        //print(value);
	}
}
