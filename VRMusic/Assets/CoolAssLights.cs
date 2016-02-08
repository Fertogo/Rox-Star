using UnityEngine;
using System.Collections;

public class CoolAssLights : MonoBehaviour {
	Light redlight2;
	Light redlight1;


	Light greenlight1;
	Light greenlight2;
	Light greenlight3;
	Light greenlight4;

	Light bluelight5;


	float accTime;
	// Use this for initialization
	void Start () {
		redlight2 = (Light) GameObject.Find("spotlightRed2").GetComponent<UnityEngine.Light>();
		redlight1 = (Light) GameObject.Find("spotlightRed1").GetComponent<UnityEngine.Light>();

		greenlight1 = (Light) GameObject.Find("spotlightGreen1").GetComponent<UnityEngine.Light>();
		greenlight2 = (Light) GameObject.Find("spotlightGreen2").GetComponent<UnityEngine.Light>();
		greenlight3 = (Light) GameObject.Find("spotlightGreen3").GetComponent<UnityEngine.Light>();
		greenlight4 = (Light) GameObject.Find("spotlightGreen4").GetComponent<UnityEngine.Light>();

		bluelight5 = (Light) GameObject.Find("spotlightBlue1").GetComponent<UnityEngine.Light>();

		greenlight1.enabled = !greenlight1.enabled;
		greenlight2.enabled = !greenlight2.enabled;
		greenlight3.enabled = !greenlight3.enabled;
		greenlight4.enabled = !greenlight4.enabled;

		accTime = 0;

	}
	
	// Update is called once per frame
	void Update () {
		accTime += Time.deltaTime;

		if (accTime > 0.23) {
			redlight2.enabled = !redlight2.enabled;
			redlight1.enabled = !redlight1.enabled;

			greenlight1.enabled = !greenlight1.enabled;
			greenlight2.enabled = !greenlight2.enabled;
			greenlight3.enabled = !greenlight3.enabled;
			greenlight4.enabled = !greenlight4.enabled;



			accTime = 0;
		} 
		
	}


}
