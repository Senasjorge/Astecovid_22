using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour

{
    public static GameManager instance;
    public int vidas = 3;
    public int puntuacion;
    public int PuntosFinales;
    
    

    private void Awake()
    {
        instance = this; 
    }
    private void Update()
    {
        PlayerPrefs.SetFloat(tag, puntuacion);
        PuntosFinales = PlayerPrefs.GetInt(tag, puntuacion);
    }
}

