using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lanzamiento : MonoBehaviour {

	private Creador creador;
	public GameObject ObjetoALanzar;
	public GameObject ObjetoLanzado;
	public Transform PosicionPrincipal;

	public float Velocidad_Lanzamiento = 1f;
	public float Velocidad_General = 2f;
	private bool enPosicion = false;

	void Awake(){
		creador = GameObject.Find ("Creacion").GetComponent<Creador>();
	}

	void Inicio(){
		ObjetoALanzar = creador.ObjetoCreado;
		ObjetoALanzar.transform.parent = GameObject.Find ("Principal").transform;
		ObjetoALanzar.AddComponent <Bola_Animaciones> ();
		StartCoroutine (MovimientoGeneral (ObjetoALanzar,Velocidad_General));
		//creador.SendMessage ("Inicio");
	}

	void Fin(){
		if (ObjetoALanzar != null) {
			Destroy (ObjetoALanzar);
			ObjetoALanzar = null; 
		}
	}


	public void Lanzar(Vector3 LugarALanzar){//Funcion llamada desde el cubo, utiliza el cubo a lanzar.
		if (enPosicion) {
			ObjetoLanzado = ObjetoALanzar;
			StartCoroutine (MovimientoLanzador (ObjetoLanzado, LugarALanzar, Velocidad_Lanzamiento));
			ObjetoALanzar = creador.ObjetoCreado;
			ObjetoALanzar.transform.parent = GameObject.Find ("Principal").transform;
			ObjetoALanzar.AddComponent <Bola_Animaciones> ();
			StartCoroutine (MovimientoGeneral (ObjetoALanzar, Velocidad_General));

		}
	}

	IEnumerator MovimientoLanzador (GameObject ObjetoAMover,Vector3 Destino,float Velocidad){
		ObjetoAMover.GetComponent <BoxCollider>().isTrigger = false;//La bola se vuelve dura;
		while (ObjetoAMover.transform.position != Destino) {
			ObjetoAMover.transform.position = Vector3.MoveTowards(ObjetoAMover.transform.position, Destino, Time.deltaTime * Velocidad);
			yield return null;
		}
		DestroyObject (ObjetoAMover);
		ObjetoAMover = null;

	}

	IEnumerator MovimientoGeneral(GameObject ObjetoAMover,float Velocidad){
		enPosicion = false;
		while (ObjetoAMover.transform.localPosition != Vector3.zero) {
			ObjetoAMover.transform.localPosition = Vector3.MoveTowards (ObjetoAMover.transform.localPosition, Vector3.zero, Time.deltaTime * Velocidad);
			yield return null;
		}
		enPosicion = true;
	}

}
