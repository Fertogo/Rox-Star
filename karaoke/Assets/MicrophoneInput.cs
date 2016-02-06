using UnityEngine;
using System.Collections;
[RequireComponent(typeof(AudioSource))]
public class MicrophoneInput : MonoBehaviour {

	public float sensitivity = 100;
	public float loudness = 0;

	void Start() {
		//GetComponent<AudioSource>().clip = Microphone.Start(null, true, 10, 44100);
		//GetComponent<AudioSource>().loop = false; // Set the AudioClip to loop
		//GetComponent<AudioSource>().mute = false; 
		//while (!(Microphone.GetPosition(AudioInputDevice) > 0)){} // Wait until the recording has started
		//GetComponent<AudioSource>().Play(); // Play the audio source!

		AudioSource aud = GetComponent<AudioSource>();
		aud.clip = Microphone.Start("jam", true, 1, 44100);
		aud.loop = true;
		aud.mute = false;
		while (!(Microphone.GetPosition("jam") > 0)){}
		aud.Play();
	}
}

//	void Update(){
//		loudness = GetAveragedVolume() * sensitivity;
//	}
//
//	float GetAveragedVolume()
//	{ 
//		float[] data = new float[256];
//		float a = 0;
//		GetComponent<AudioSource>().GetOutputData(data,0);
//		foreach(float s in data)
//		{
//			a += Mathf.Abs(s);
//		}
//		return a/256;
//	}
