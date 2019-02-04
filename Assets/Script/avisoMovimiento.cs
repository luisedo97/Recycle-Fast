using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class avisoMovimiento : MonoBehaviour {

	public float Desplazamiento = 0.5f;
	public float Velocidad = 5;

	void Start () {
		StartCoroutine (movimiento());
	}	

	IEnumerator movimiento(){
		Vector3 destino = transform.position + new Vector3(0,Desplazamiento,0);
		Vector3 posicionInicial = transform.position;
		while(true){
			while (transform.position != destino){
				transform.position = Vector3.MoveTowards(transform.position, destino, Time.deltaTime * Velocidad);
				yield return null;
			}
			while (transform.position != posicionInicial){
				transform.position = Vector3.MoveTowards (transform.position, posicionInicial, Time.deltaTime * Velocidad);
				yield return null;
			}
		}
	}
}
