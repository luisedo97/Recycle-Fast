using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPerdida_Puntaje : MonoBehaviour {
	//Asignar Puntaje y puntaje maximo.
	//Buscar sus hijos, modificar la variable sprite del componente Image.

	public GameObject[] puntajeActual;
	public GameObject[] puntajeMaximo;
	public Sprite[] numeros;
	public int puntuacionActual;
	public int puntuacionRecord;

	void Awake(){
		GameObject puntajeActualPadre = GameObject.Find ("Puntaje Actual");
		GameObject puntajeRecordPadre = GameObject.Find ("Puntaje Max");
		puntajeActual = new GameObject[puntajeActualPadre.transform.childCount];
		puntajeMaximo = new GameObject[puntajeRecordPadre.transform.childCount];
		for (int i = 0; i < puntajeMaximo.Length; i++) {
			puntajeActual [i] = puntajeActualPadre.transform.GetChild (i).gameObject;
			puntajeMaximo [i] = puntajeRecordPadre.transform.GetChild (i).gameObject;
		}
	}

	public void setPuntuacionActual(int puntuacionActual){
		this.puntuacionActual = puntuacionActual;
	}

	public void setPuntuacionRecord(int puntuacionRecord){
		this.puntuacionRecord = puntuacionRecord;
	}

	public void setPuntuacionPantalla (){
		int[] actualSeparado = new int[3];
		int[] recordSeparado = new int[3];
		actualSeparado = separadorNumero (puntuacionActual);
		recordSeparado = separadorNumero (puntuacionRecord);
		for (int i = 0; i < 3; i++) {
			//Debug.Log (puntajeActual.Length);
			puntajeActual[i].GetComponent<SpriteRenderer>().sprite = numeros [actualSeparado[i]];
			puntajeMaximo[i].GetComponent<SpriteRenderer>().sprite = numeros [recordSeparado[i]];
		}

	}

	private int[] separadorNumero (int numero){
		string numeroTexto = numero.ToString ();
		int[] numeroSeparado = new int[3];
		while(numeroTexto.Length<3){
			numeroTexto = "0" + numeroTexto;
		}
		for (int i = 0; i < 3; i++) {
			numeroSeparado [i] = int.Parse (numeroTexto[i]+"");
		}
		return numeroSeparado;
	}


}
