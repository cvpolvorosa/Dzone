using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCondition : MonoBehaviour {

	public string levelName;
		
	void OnTriggerEnter(Collider other){
		Scene scene = SceneManager.GetActiveScene();
		if (other.CompareTag ("Player")) {
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
			if (scene.name == "CS_ELEC3B_4CSC_PROJECT_LEVEL1_POLVOROSA") {
				PlayerPrefs.SetInt ("levelReached", 2);
			} else if (scene.name == "CS_ELEC3B_4CSC_PROJECT_LEVEL2_POLVOROSA") {
				PlayerPrefs.SetInt ("levelReached", 3);
			}
			SceneManager.LoadScene (levelName);
		}
	}
}
