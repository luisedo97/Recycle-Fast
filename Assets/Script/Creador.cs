using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creador : MonoBehaviour {

	public GameObject[] Objeto;
	//public static GameObject ObjetoCreado;
	public GameObject ObjetoCreado;

	void Awake (){
		ObjetoCreado = Instantiate (Objeto[Random.Range (0,Objeto.Length)],transform.position,transform.rotation,transform);
	}

	void OnTriggerExit (){
		ObjetoCreado = Instantiate (Objeto[Random.Range (0,Objeto.Length)],transform.position,transform.rotation,transform);
	}
		

}