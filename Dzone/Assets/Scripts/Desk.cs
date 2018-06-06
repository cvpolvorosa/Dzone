using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desk : MonoBehaviour {
	
	public bool open = false;
	public int openAngleX = 0;
	public int openAngleY = 0;
	public int openAngleZ = 125;
	public int closeAngleX = 0;
	public int closeAngleY = 0;
	public int closeAngleZ = 0;
	public float smooth = 0.75f; //speed of rotation
	public float smoothClose = 8f;



	public AudioSource audioSource;
	public AudioClip openingSound;
	public AudioClip closingSound;

	void Start () {
		audioSource = GetComponent<AudioSource> ();
	}
		
	public void ChangeDoorState(){
		open = !open;

		if (audioSource != null) {
			if (open == true) {
				audioSource.PlayOneShot (openingSound);
			}else {
				audioSource.PlayOneShot (closingSound);
			}
		}

	}

	void Update () {
		if (open == true) {
			Quaternion targetRotationOpen = Quaternion.Euler (openAngleX, openAngleY, openAngleZ);
			transform.localRotation = Quaternion.Slerp (transform.localRotation, targetRotationOpen, smooth * Time.deltaTime);
		} else {
			Quaternion targetRotationClosed = Quaternion.Euler (closeAngleX, closeAngleY, closeAngleZ);
			transform.localRotation = Quaternion.Slerp (transform.localRotation, targetRotationClosed, smoothClose * Time.deltaTime);
		}
	}
}
