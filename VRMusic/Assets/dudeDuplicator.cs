using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class dudeDuplicator : MonoBehaviour {
	public int TOTAL_DUDES; 
	public Transform dude1; 
	public Transform dude2; 
	public Transform dude3; 
	public Transform dude4; 
	public Transform dude5; 
	public Transform dude6; 

	public AudioSource crowd;
	private float timeSinceCheer = 0.0f; 


	private List<Transform> templates = new List<Transform> ();
	private List<Transform> dudes = new List<Transform>();
	private Transform currentDude; 
	private string[] positions = {"idle","applause","applause2","celebration","celebration2","celebration3"};


	// Use this for initialization
	void Start () {
		templates.Add (dude1); templates.Add (dude2);templates.Add (dude3); templates.Add (dude4); templates.Add (dude5); templates.Add (dude6); 
		for (int i = 0; i < 10; i++) { 
			float spacing = Random.Range (-100, -50) / 100.0f; 
			float rowSpacing = i * Random.Range (10, 30) / 100.0f; 
			generateRowOfDudes (TOTAL_DUDES, spacing,  rowSpacing, -1.0f*i);
		}


		crowd.Play (); 
		exiteAudience ();

	}
		
	void generateRowOfDudes(int totalDudes, float dudeSpacing,  float rowPosition, float zPosition) { 
		for (int i = 0; i < totalDudes; i++) {
			//Clone from random template
			Vector3 position = new Vector3(dudeSpacing*i, rowPosition, zPosition); 
			currentDude = (Transform)Instantiate (templates[Random.Range(0,5)], position, Quaternion.identity);
			dudes.Add (currentDude); 
			randomAnimation (currentDude); 

		}
		//Right side dudes
		for (int i = 1; i < totalDudes+3; i++) {
			Debug.Log ("Right side"); 
			Debug.Log (zPosition); 
			if (zPosition < -3.0f) {
				break; 
			}
			Vector3 position = new Vector3((dudeSpacing*totalDudes)+dudeSpacing*i, rowPosition, zPosition+ 1.0f+(i*+0.3f) ); 
			currentDude = (Transform)Instantiate (templates[Random.Range(0,5)], position, Quaternion.identity);
			currentDude.Rotate (new Vector3 (0.0f, 70.0f, 0.0f));
			dudes.Add (currentDude); 
			randomAnimation (currentDude); 

		}
		//Left side dudes
		for (int i = 0; i < totalDudes+3; i++) {
			if (zPosition < -3.0f) {
				break; 
			}
			Vector3 position = new Vector3(-(dudeSpacing*totalDudes)+dudeSpacing*i+3.5f, rowPosition, zPosition- 1.0f-(i*+0.4f)+5.0f ); 
			currentDude = (Transform)Instantiate (templates[Random.Range(0,5)], position, Quaternion.identity);
			currentDude.Rotate (new Vector3 (0.0f, -70.0f, 0.0f));
			dudes.Add (currentDude); 
			randomAnimation (currentDude); 
		}

	}

	void randomAnimation(Transform currentDude) {
		//Add a random animation
		Animation anim = currentDude.GetComponentsInChildren<Animation>()[0];
		string thisAnimation = positions[Random.Range(0,5)];
		//      string thisAnimation = "celebration3";

		anim.wrapMode = WrapMode.Loop;
		anim.CrossFade (thisAnimation);
		anim[thisAnimation].time = Random.Range(0f,10f);
	} 

	public void exiteAudience() {
		Debug.Log ("EXCITE AUDIENCE"); 
		foreach (Transform dude in dudes) {
			//          Debug.Log ("Exciting Dude"); 
			Animation anim = dude.GetComponentsInChildren<Animation>()[0];
			string thisAnimation = "celebration";
			anim.wrapMode = WrapMode.Loop;
			anim.CrossFade (thisAnimation);
			anim[thisAnimation].time = Random.Range(0f,10f);
		}
		//      crowdAudio.volume = 0.0f; 
		//      AudioSource.PlayClipAtPoint(crowdAudio, transform.position, 0.0f); 
		crowd.volume = 1.0f; 
		timeSinceCheer = 0.0f;
		crowd.time = 0.0f; 

	}
	
	// Update is called once per frame
	void Update () {

		timeSinceCheer += Time.deltaTime;

		if (timeSinceCheer > 10) { //10 = Time till not excited
			if (crowd.volume > 0.2f) {
				crowd.volume = crowd.volume - Time.deltaTime/10.0f;
			}
					
		}


		//Randomly change animation of each dude
		foreach (Transform dude in dudes) {
			int random = Random.Range (0, 1000); 
			if (random == 1) { 
				//              Debug.Log ("RRRAAAANDOM"); 
				randomAnimation (dude); 
			}

		}

		if (Input.GetMouseButtonDown (0)) { 
			Debug.Log ("Click"); 
			exiteAudience (); 

		}

	}
}
