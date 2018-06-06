using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinMenu : MonoBehaviour {

	void Awake(){
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;

	}

	public void LoadLevel(string levelName){
		/*
		Scene scene = SceneManager.GetActiveScene ();
		if (bgMusic != null) {
			if (scene.name == "Win") {
				Destroy (bgMusic);
			}
		}*/
		SceneManager.LoadScene (levelName);
	}

	public void Quit(){
		Application.Quit ();
	}
}
