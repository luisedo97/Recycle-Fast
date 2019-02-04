using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class botonReinicio : MonoBehaviour {

	void OnMouseDown(){//Manda la orden
		GameObject.Find("Controlador").SendMessage ("reinicioDelJuego");
	}
}
