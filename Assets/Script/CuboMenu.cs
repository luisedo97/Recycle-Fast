using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuboMenu : MonoBehaviour {

	public GameObject mensaje;
	public Vector3 posicionMensaje;
	public string funcion;
	private GameObject controlador;

	void Awake(){
		controlador = GameObject.Find ("Controlador");
		if(mensaje != null)
			mensaje = Instantiate (mensaje, this.transform.position + posicionMensaje, Quaternion.identity, this.transform);
	}

	void OnMouseDown(){
		switch (funcion) {
			case "Juego":
				controlador.SendMessage ("iniciarJuego");
				break;
			case "Opciones":
				break;
			case "Salir":
				break;
			}
	}

}
