using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarraVida : MonoBehaviour {

	private RectTransform vida;
	private GameObject controlador;
	public float tiempoDegradacion = 10f;

	void Awake(){
		controlador = GameObject.Find ("Controlador");
		vida = GameObject.Find ("Vida").GetComponent<RectTransform> ();
	}

	void Start(){
		StartCoroutine (degradacionTiempo ());
	}

	public void aumentoTiempo(int tiempo){
		vida.sizeDelta = new Vector2 (vida.sizeDelta.x + tiempo, vida.sizeDelta.y);
		if (vida.sizeDelta.x > 400) {
			vida.sizeDelta = new Vector2(400,vida.sizeDelta.y);
		}
	}

	public void reduccionTiempo(int tiempo){
		vida.sizeDelta = new Vector2 (vida.sizeDelta.x - tiempo, vida.sizeDelta.y);
		if (vida.sizeDelta.x < 0) {
			vida.sizeDelta = new Vector2(0,vida.sizeDelta.y);
		}
	}

	IEnumerator degradacionTiempo(){
		while (vida.sizeDelta.x > 0){
			vida.sizeDelta = new Vector2 (vida.sizeDelta.x - tiempoDegradacion, vida.sizeDelta.y);
			yield return new WaitForSeconds(0.5f);
		}
		controlador.SendMessage ("finPartida");
	}

}
