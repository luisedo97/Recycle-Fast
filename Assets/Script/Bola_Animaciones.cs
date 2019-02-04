using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bola_Animaciones : MonoBehaviour {

	public float VelocidadGiro = 0.2f;

	void Start () {
		StartCoroutine (RotacionRandom ());
	}

	IEnumerator RotacionRandom(){
		Vector3 VectorRandom = new Vector3 (Random.Range (-180, 180), Random.Range (-180, 180), Random.Range (-180, 180));
		while (GetComponent <BoxCollider>().isTrigger){//Abra rotacion random hasta que el objeto sea duro(lanzado)
			transform.Rotate (VectorRandom * Time.fixedDeltaTime * VelocidadGiro);
			yield return null;
		}
	}

}
