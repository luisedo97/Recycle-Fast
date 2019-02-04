using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerGame : MonoBehaviour {

	public int highScore;
	//public GameObject scoreComponent;

	void Awake(){
		highScore = PlayerPrefs.GetInt ("High Score", 0);
	}
		
}
