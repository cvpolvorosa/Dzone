using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Compass : MonoBehaviour {
	
	public Image cmpImage;
	public GameObject playerObject;
	public GameObject cameraObject;

	public AudioSource audioSource;
	public AudioClip pickupSound;
	public AudioClip putAwaySound;
	void Start () {
		cmpImage.enabled = false;
		audioSource = GetComponent<AudioSource> ();
	}
	
	public void ShowCompassImage(){

		cmpImage.enabled = true;
		audioSource.PlayOneShot (pickupSound);
		playerObject.GetComponent<CharacterController> ().enabled = false;
		cameraObject.GetComponent<CameraController> ().enabled = false;
	}

	void Update () {
		if (cmpImage.enabled == true) {
			if (Input.GetButtonDown ("Cancel") || Input.GetButtonDown ("Fire2")) {
				playerObject.GetComponent<CharacterController> ().enabled = true;
				cameraObject.GetComponent<CameraController> ().enabled = true;
				Cursor.lockState = CursorLockMode.Locked;
				Cursor.visible = false;
				cmpImage.enabled = false;
				audioSource.PlayOneShot (putAwaySound);
			}
		}
	}
}
