using UnityEngine;
using System.Collections;

public class person : MonoBehaviour {
	private Rigidbody rb;
	public Transform prefab; 


	private string[] names = {"idle","applause","applause2","celebration","celebration2","celebration3"};
	// Use this for initialization
	void Start () {
		Debug.Log ("Duplicator.cs running"); 
//		Animation[] AudienceMembers = gameObject.GetComponentsInChildren<Animation>();
//		foreach(Animation anim in AudienceMembers){
//			string thisAnimation = names[Random.Range(0,5)];
//
//			anim.wrapMode = WrapMode.Loop;
//			GetComponent<Animation> ().CrossFade (thisAnimation);
//			anim[thisAnimation].time = Random.Range(0f,3f);
//		}


	
	}
	
	// Update is called once per frame

	void Update () {
		if (Input.GetMouseButtonDown (0)) { 
			Debug.Log ("Click"); 

		}
	}
}
