using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ControllerScene : MonoBehaviour {

	//Json information

	void Awake(){
		Time.timeScale = 1 ;
	}

	public void pauseScene(){
		Time.timeScale = 0;
	}

	public void resumeScene(){
		Time.timeScale = 1;
	}

	public void requestChangeScene(string nameScene){
		PlayerPrefs.SetInt ("High Score", 0);
		SceneManager.LoadScene (nameScene);
	}

	public void requestChangeScene(int numberScene){
		SceneManager.LoadScene (numberScene);
	}
		
}
