using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {
	public Button[] levelButtons;

	void Awake(){
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;

	}

	void Start(){
		int levelReached = PlayerPrefs.GetInt("levelReached", 1);
		for (int i = 0; i < levelButtons.Length; i++) {
			if (i + 1 > levelReached) {
				levelButtons [i].interactable = false;
			}
		}
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

	public void NextLevel(string currentLevel){
		if (currentLevel == "level1") {
			SceneManager.LoadScene ("CS_ELEC3B_4CSC_PROJECT_LEVEL2_POLVOROSA");
		}

	}

	void Update(){
		Debug.Log(PlayerPrefs.GetInt("levelReached",1));

	}

	public void Quit(){
		PlayerPrefs.DeleteAll ();
		Application.Quit ();
	}
}
