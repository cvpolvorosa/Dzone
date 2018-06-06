using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Safe3 : MonoBehaviour {

	public Canvas safeCanvas;
	public GameObject playerObject;
	public GameObject cameraObject;

	public float safeNumber01 = 0;
	public float safeNumber02 = 0;
	public float safeNumber03 = 0;
	//public float safeNumber04 = 0;

	public AudioSource audioSource;
	public AudioClip openingSound;

	public static string correctCode = "015";
	public string playerCode = "000";

	public Text safeText01;
	public Text safeText02;
	public Text safeText03;
	//public Text safeText04;

	public bool isSafeOpened = false;
	public bool isSubmitted = false;

	public int angleX = 0;
	public int angleY = 0;
	public int angleZ = 160;

	public float smooth = 2f; //speed of rotation
	private int x = 0; //debug purposes


	void Start(){
		safeCanvas.enabled = false;
		safeText01.text = "0";

	}

	public void ShowSafeCanvas () {
		safeCanvas.enabled = true;
		playerObject.GetComponent<CharacterController> ().enabled = false;
		cameraObject.GetComponent<CameraController> ().enabled = false;

		//unlocks mouse cursor and makes it visible
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;

	}

	public void Submit(){

		isSubmitted = true;
		/*
		if (playerCode == correctCode) {
			//used to play sound only once
			x++;
			PlaySound (x);

			//unlocks player
			playerObject.GetComponent<CharacterController> ().enabled = true;
			cameraObject.GetComponent<CameraController> ().enabled = true;
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
			safeCanvas.enabled = false;


			Debug.Log ("WOW ANG GALING GALING");
			//SceneManager.LoadScene ("Win");
			isSafeOpened = true;

			//UnlockSafe ();
			//gameObject.layer = 0;
		} else {
			SceneManager.LoadScene ("Win");
		}*/
	}

	void Update () {
		if (isSafeOpened == false) {
			playerCode = safeText01.text + safeText02.text + safeText03.text; // + safeText04.text; 
		}

		Debug.Log (playerCode);
		if(safeCanvas.enabled == true){
			if (Input.GetButtonDown ("Cancel") || Input.GetButtonDown ("Fire2")) {
				playerObject.GetComponent<CharacterController> ().enabled = true;
				cameraObject.GetComponent<CameraController> ().enabled = true;
				Cursor.lockState = CursorLockMode.Locked;
				Cursor.visible = false;
				safeCanvas.enabled = false;
			}
		}


		if (isSubmitted == true) {
			if (playerCode == correctCode) {
				//used to play sound only once
				x++;
				PlaySound (x);

				//unlocks player
				playerObject.GetComponent<CharacterController> ().enabled = true;
				cameraObject.GetComponent<CameraController> ().enabled = true;
				Cursor.lockState = CursorLockMode.Locked;
				Cursor.visible = false;
				safeCanvas.enabled = false;


				Debug.Log ("WOW ANG GALING GALING");
				//SceneManager.LoadScene ("Win");
				isSafeOpened = true;

				UnlockSafe ();
				gameObject.layer = 0;
				Destroy (this, 2);
			} else {
				SceneManager.LoadScene ("Lose");
			}
		}

	}

	void UnlockSafe(){
		Quaternion targetRotationOpen = Quaternion.Euler (angleX, angleY, angleZ);
		transform.localRotation = Quaternion.Slerp (transform.localRotation, targetRotationOpen, smooth * Time.deltaTime);

	}

	void PlaySound(int i){
		if (i == 1) {
			if (audioSource != null) {
				audioSource.PlayOneShot (openingSound);
			}
		}
	}


	public void IncreaseNumber(int num){
		switch (num) {
		case 1:
			safeNumber01++;
			safeNumber01 %= 10;
			safeText01.text = safeNumber01.ToString ();
			break;
		case 2:
			safeNumber02++;
			safeNumber02 %= 10;
			safeText02.text = safeNumber02.ToString ();
			break;
		case 3:
			safeNumber03++;
			safeNumber03 %= 10;
			safeText03.text = safeNumber03.ToString ();
			break;
			/*case 4:
			safeNumber04++;
			safeNumber04 %= 10;
			safeText04.text = safeNumber04.ToString ();
			break;*/
		}
	}

	public void DecreaseNumber(int num){
		switch (num) {
		case 1:
			safeNumber01--;
			safeNumber01 = mod(safeNumber01,10);
			safeText01.text = safeNumber01.ToString ();
			break;
		case 2:
			safeNumber02--;
			safeNumber02 = mod(safeNumber02,10);
			safeText02.text = safeNumber02.ToString ();
			break;
		case 3:
			safeNumber03--;
			safeNumber03 = mod(safeNumber03,10);
			safeText03.text = safeNumber03.ToString ();
			break;
			/*case 4:
			safeNumber04--;
			safeNumber04 = mod(safeNumber04,10);
			safeText04.text = Mathf.Abs(safeNumber04).ToString ();
			break;*/
		}
	}


	//tunay na modulo
	float mod(float a, float b){
		return a - b * Mathf.Floor(a / b);
	}
}
