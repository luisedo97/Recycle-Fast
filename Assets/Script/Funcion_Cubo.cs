using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Funcion_Cubo : MonoBehaviour {

	public GameObject lanzamiento;
	public GameObject puntuacion;
	public GameObject barraVida;
	public GameObject Aviso;
	public int puntuacionAIncrementar;
	public int tiempoAIncrementar;
	public int tiempoADecrecer;

	void Awake(){
		lanzamiento = GameObject.Find ("Principal");
	}

	void Start(){
		puntuacion = GameObject.Find ("Puntuacion");
		barraVida = GameObject.Find ("Barra Vida"); 
	}

	public void setConfig(int puntuacion,int tiempoMas,int tiempoMen){
		this.puntuacionAIncrementar = puntuacion;
		this.tiempoAIncrementar = tiempoMas;
		this.tiempoADecrecer = tiempoMen;
	}
		
	void OnMouseDown(){//Manda al cubo que se lanzara.
		lanzamiento.SendMessage ("Lanzar",transform.position);
	}

	void OnTriggerEnter(Collider ObjetoQueChoco){//Cuando algo impacta con el cubo
		
		if (ObjetoQueChoco.gameObject.tag == tag) {//Si es correcto
			puntuacion.SendMessage ("AumentoPuntuacion",puntuacionAIncrementar);
			barraVida.SendMessage ("aumentoTiempo", tiempoAIncrementar);
		} else {								  //Si no es correcto
			//puntuacion.SendMessage ("ResetearPuntuacion");
			barraVida.SendMessage ("reduccionTiempo", tiempoADecrecer);
		}
	
	}


}
