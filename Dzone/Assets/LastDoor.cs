using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastDoor : MonoBehaviour {

	public bool open = true;
	public float doorOpenAngle = -90f;
	public float doorClosedAngle = 0f;
	public float doorAngleX = -90f;
	public float doorAngleZ = 0f;


	public float smooth = 15f; //speed of rotation
	public bool isLocked = false;

	public AudioSource audioSource;
	public AudioClip openingSound;
	public AudioClip lockedSound;

	void Start(){
		audioSource = GetComponent<AudioSource> ();
		open = true;
	}
	public void ChangeDoorState(){
		if (isLocked != true) {
			open = !open;
			if (audioSource != null) {
				audioSource.PlayOneShot (openingSound);
			}
		} else {
			audioSource.PlayOneShot (lockedSound);
		}
	}

	void Update () {
		if (open == true) {
			Quaternion targetRotationOpen = Quaternion.Euler (doorAngleX, doorOpenAngle, doorAngleZ);
			transform.localRotation = Quaternion.Slerp (transform.localRotation, targetRotationOpen, smooth * Time.deltaTime);
		} else {
			Quaternion targetRotationClosed = Quaternion.Euler (doorAngleX, doorClosedAngle, doorAngleZ);
			transform.localRotation = Quaternion.Slerp (transform.localRotation, targetRotationClosed, smooth * Time.deltaTime);
		}
	}
}
