using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicio : MonoBehaviour
{
    public void Play()
    {
        //Cambio de escena de menu inicio a Juego
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Exit()
    {
        // Mensaje de Salir en consola al pulsar boton salir
        Debug.Log("Salir");       
    
    }
}

