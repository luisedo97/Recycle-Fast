using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controlador : MonoBehaviour {
	//Agregado desde el editor
	public GameObject barraVida;
	public GameObject puntuacion;
	public GameObject menuPerdida;
	public GameObject canvas;
	public GameObject[] cubos = new GameObject[3];
	public GameObject lanzador;
	public int puntuacionAIncrementar;
	public int tiempoAIncrementar;
	public int tiempoADecrecer;
	/*private int highscore;

	void Awake(){
		PlayerPrefs.GetInt ("High Score", 0);
	}*/
	public void iniciarMenu(){
		
	}

	public void iniciarJuego(){
		//Instanciar la parte grafica
		Instantiate (puntuacion, canvas.transform).name = "Puntuacion";
		Instantiate (barraVida, canvas.transform).name = "Barra Vida";
		//Añadir el componente que acciona los cubos y elimino los componentes del menu.
		foreach (GameObject cubo in cubos) {
			cubo.AddComponent <Funcion_Cubo> ();
			cubo.GetComponent<Funcion_Cubo> ().setConfig (puntuacionAIncrementar, tiempoAIncrementar, tiempoADecrecer);
			if(cubo.GetComponent<CuboMenu>() != null){
				Destroy (cubo.GetComponent<CuboMenu> ().mensaje);
				Destroy (cubo.GetComponent<CuboMenu> ());
			}
		}
		lanzador.SendMessage ("Inicio");
	}

	public void finPartida(){
		int puntuacionActual = GameObject.Find ("Puntuacion").GetComponent<PuntuacionScript>().Puntuacion;
		int puntuacionRecord = PlayerPrefs.GetInt ("High Score", 0);
		//Almaceno si hay un nuevo high score
		if (PlayerPrefs.GetInt ("High Score", 0) < puntuacionActual) {
			PlayerPrefs.SetInt ("High Score", puntuacionActual);
			puntuacionRecord = puntuacionActual;
		}

		//Destruyo el componente cubo para que no se siga jugando
		foreach (GameObject cubo in cubos) {
			Destroy (cubo.GetComponent<Funcion_Cubo> ());
		}
		//Destruyo toda la interfaz
		lanzador.SendMessage("Fin");
		Destroy (GameObject.Find("Puntuacion"));
		Destroy (GameObject.Find("Barra Vida"));
		//Instancio la pantalla de perdida.
		//Seria interesante que ahora mismo yo instanciara el objeto mas arriba.
		//Luego creara el movimiento decreciente.
		GameObject menu = Instantiate(menuPerdida);
		menu.name = "menuPerdida";
		menu.SendMessage("setPuntuacionActual",puntuacionActual);
		menu.SendMessage("setPuntuacionRecord",puntuacionRecord);
		menu.SendMessage ("setPuntuacionPantalla");
	}


	public void reinicioDelJuego(){
		Destroy (GameObject.Find("menuPerdida"));
		iniciarJuego();
	}

}
