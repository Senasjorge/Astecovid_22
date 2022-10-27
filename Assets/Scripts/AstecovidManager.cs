using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstecovidManager : MonoBehaviour
{
    public int astecovids_min = 1;
    public int astecovids_max = 3; 
    public int astecovids;   
    public float limitX = 10;
    public float limitY = 6;
    public GameObject astecovid;
    
    void Start()
    {
        CrearAstecovids();   
    }
    void Update()
    {
        if (astecovids <= 0)
        {
            astecovids_min += 2;
            astecovids_max += 2;
            CrearAstecovids();           
        }        
    }
    // Instanciando Asteroides
    void CrearAstecovids()
    {
        {
            int astecovids = Random.Range(astecovids_min, astecovids_max);
            
            for (int i = 0; i < astecovids; i++)
            {                
                Vector3 posicion = new Vector3(Random.Range(-limitX, limitX), Random.Range(-limitX, limitX));

                while (Vector3.Distance(posicion,new Vector3(0,0)) < 2)
                    {
                    posicion = new Vector3(Random.Range(-limitX, limitX), Random.Range(-limitX, limitX));
                }
                Vector3 rotacion = new Vector3(0, 0, Random.Range(0f, 360f));
                GameObject temp = Instantiate(astecovid, posicion, Quaternion.Euler(rotacion));
                temp.GetComponent<AstwroidController>().manager = this;
            }
            
        }
    }
   
    
 }



    




