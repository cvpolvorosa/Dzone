using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour {
	public Door myDoor;
	public AudioSource audioSource;
	public AudioClip keySound;


	void Start(){
		audioSource = GetComponent<AudioSource> ();
	}
	public void UnlockDoor(){
		myDoor.isLocked = false;
		Debug.Log (myDoor.isLocked);
		if (audioSource != null) {
			audioSource.PlayOneShot (keySound);
		}

		StartCoroutine ("WaitForSelfDestruct");
	}

	IEnumerator WaitForSelfDestruct(){
		yield return new WaitForSeconds (keySound.length);
		Destroy (gameObject);
	}
}
