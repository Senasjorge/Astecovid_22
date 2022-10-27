using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI Tiempo;
    public TextMeshProUGUI Puntuacion;
    public TextMeshProUGUI Vidas;            
    public GameObject GameOver;
    public GameObject MusicaFondo;
        
    void Start()
    {
        
    }

    
    void Update()
    {
        Tiempo.text =Time.time.ToString("00.00");
        Puntuacion.text = GameManager.instance.puntuacion.ToString();
        Vidas.text = GameManager.instance.vidas.ToString();
        
        if(GameManager.instance.vidas <= 0)
        {
            GameOver.SetActive(true);
            MusicaFondo.SetActive(false);
            
        }
            
    }

}
