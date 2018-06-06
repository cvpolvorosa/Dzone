using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scare : MonoBehaviour {
	public GameObject gameObj;

	public void DestroyObject(){
		Destroy (gameObj);
	}
}
