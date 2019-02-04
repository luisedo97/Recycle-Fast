using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {

	private bool pauseIsVisible = false;
	public GameObject pauseObject;


	void Awake(){
		pauseObject = GameObject.Find ("PauseUI");
		pauseObject.SetActive (pauseIsVisible);
	}
	
	public void pauseClick(){
		pauseIsVisible = !pauseIsVisible;
		pauseObject.SetActive (pauseIsVisible);
		this.gameObject.SetActive (!pauseIsVisible);
	}

}
