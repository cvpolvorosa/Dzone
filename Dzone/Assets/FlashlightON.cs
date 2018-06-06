using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightON : MonoBehaviour {

	public GameObject flashlight;
	public GameObject lamp;

	void OnTriggerEnter(Collider other){
		if (other.CompareTag ("Player")) {
			flashlight.SetActive (true);
			Destroy (lamp);
			Destroy (GetComponent<BoxCollider>());
		}
	}
}
