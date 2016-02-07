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



	}

	void generateRowOfDudes(int totalDudes, float dudeSpacing,  float rowPosition, float zPosition) { 
		for (int i = 0; i < totalDudes; i++) {
			//Clone from random template
			Vector3 position = new Vector3(dudeSpacing*i, rowPosition, zPosition); 
			currentDude = (Transform)Instantiate (templates[Random.Range(0,5)], position, Quaternion.identity);
			dudes.Add (currentDude); 

			//Add a random animation
			Animation anim = currentDude.GetComponentsInChildren<Animation>()[0];
			string thisAnimation = positions[Random.Range(0,5)];
			anim.wrapMode = WrapMode.Loop;
			anim.CrossFade (thisAnimation);
			anim[thisAnimation].time = Random.Range(0f,10f);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
