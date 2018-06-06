using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door1 : MonoBehaviour {

	public GameObject lampLight;
	public GameObject lampLight2;
	public GameObject scare;
	//public GameObject flashlight;
	public GameObject door;
	public LastDoor doorScript;

	void Awake(){
		doorScript = door.GetComponent<LastDoor> ();


	}
	void OnTriggerEnter(Collider other){
		if (other.CompareTag ("Player")) {
			doorScript.isLocked = true;
			doorScript.open = false;
			lampLight.SetActive (true);
			lampLight2.SetActive (true);
			scare.SetActive (true);
			//flashlight.SetActive (true);
			RenderSettings.skybox = null;
			RenderSettings.ambientLight = Color.black;
			Destroy (GetComponent<BoxCollider>());

		}
	}
}
