using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuntuacionScript : MonoBehaviour {

	public int Puntuacion; 

	void Awake () {
		GetComponent <Text>().text = "" + Puntuacion;
	}

	public void AumentoPuntuacion(int Aumento){
		Puntuacion += Aumento;
		GetComponent <Text>().text = "" + Puntuacion;	
	}

	public void ResetearPuntuacion(){
		Puntuacion = 0; 
		GetComponent <Text>().text = "" + Puntuacion;
	}

}
