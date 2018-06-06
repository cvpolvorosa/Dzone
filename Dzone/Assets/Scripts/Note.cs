using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Note : MonoBehaviour {

	public Image noteImage;
	public AudioSource audioSource;
	public AudioClip pickupSound;
	public AudioClip putAwaySound;
	public GameObject playerObject;
	public GameObject cameraObject;


	void Start () {
		noteImage.enabled = false;
		audioSource = GetComponent<AudioSource> ();
	}


	public void ShowNoteImage(){
		
		noteImage.enabled = true;
		audioSource.PlayOneShot (pickupSound);

		playerObject.GetComponent<CharacterController> ().enabled = false;
		cameraObject.GetComponent<CameraController> ().enabled = false;
	}
		

	void Update(){
		if (noteImage.enabled == true) {
			if (Input.GetButtonDown ("Cancel") || Input.GetButtonDown ("Fire2")) {
				playerObject.GetComponent<CharacterController> ().enabled = true;
				cameraObject.GetComponent<CameraController> ().enabled = true;
				Cursor.lockState = CursorLockMode.Locked;
				Cursor.visible = false;
				noteImage.enabled = false;
				audioSource.PlayOneShot (putAwaySound);
			}
		}
	}

}
