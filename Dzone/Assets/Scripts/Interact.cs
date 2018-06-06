using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interact : MonoBehaviour {

	public string interactButton;
	public float interactDistance = 2f;
	public LayerMask interactLayer; 

	public Image interactIcon; //maglalabas ng icon pag pwedeng maginteract
	public bool isInteracting;

	public Camera camera;

	void Start(){
		if (interactIcon != null) {
			interactIcon.enabled = false;
		}
	}

	void Update () {
		
		//Ray ray = new Ray (transform.position, transform.forward);
		RaycastHit hit;
		Ray ray = camera.ScreenPointToRay(Input.mousePosition);
		//Vector3 fwd = transform.TransformDirection (Vector3.forward) * 2;

		Debug.DrawRay (transform.position, transform.forward * interactDistance, Color.green);

		//if (Physics.Raycast (transform.position, (fwd), out hit, interactLayer)) {
		//shoots a ray para mag check
		if (Physics.Raycast (ray, out hit, interactDistance, interactLayer)) {

			//checks if player is interacting
			if (isInteracting == false) {
				if (interactIcon != null) {
					if (hit.collider.CompareTag ("Monster")) {
						hit.collider.GetComponent<Scare> ().DestroyObject ();
					} else {
						interactIcon.enabled = true;
					}
				}


				//if interact button is pressed
				if (Input.GetButtonDown (interactButton)) {
					//pintuan ba pinindot mo?
					if (hit.collider.CompareTag ("Door")) {
						hit.collider.GetComponent<Door> ().ChangeDoorState ();
					}
					else if (hit.collider.CompareTag ("LastDoor")) {
						hit.collider.GetComponent<LastDoor>().ChangeDoorState();
					}
					//susi ba pinindot mo?
					else if (hit.collider.CompareTag ("Key")) {
						hit.collider.GetComponent<Key>().UnlockDoor();
					}
					//safe ba?
					else if (hit.collider.CompareTag ("Safe")) {
						hit.collider.GetComponent<Safe>().ShowSafeCanvas();
					}
					else if (hit.collider.CompareTag ("Safe2")) {
						hit.collider.GetComponent<Safe2>().ShowSafeCanvas();
					}
					else if (hit.collider.CompareTag ("Safe3")) {
						hit.collider.GetComponent<Safe3>().ShowSafeCanvas();
					}
					//desk ba???
					else if (hit.collider.CompareTag ("Desk")) {
						hit.collider.GetComponent<Desk> ().ChangeDoorState ();
					}
					else if (hit.collider.CompareTag ("Note")) {
						hit.collider.GetComponent<Note> ().ShowNoteImage ();
					}
					else if (hit.collider.CompareTag ("Compass")) {
						hit.collider.GetComponent<Compass> ().ShowCompassImage ();
					}
					else if (hit.collider.CompareTag ("Painting")) {
						hit.collider.GetComponent<Compass> ().ShowCompassImage ();
					}

				}
			}
		} else {
			interactIcon.enabled = false;
		}


	}

}
