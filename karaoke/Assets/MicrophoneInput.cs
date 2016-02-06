using UnityEngine;
using System.Collections;
[RequireComponent(typeof(AudioSource))]
public class MicrophoneInput : MonoBehaviour {

	void Start() {

		AudioSource aud = GetComponent<AudioSource>();
		aud.clip = Microphone.Start("jam", true, 1, 44100);
		aud.loop = true;
		aud.mute = false;
		while (!(Microphone.GetPosition("jam") > 0)){}
		aud.Play();
	}
}