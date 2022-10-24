using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Teleporter : MonoBehaviour
{
    public float limiteX = 10;
    public float limiteY = 6;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > limiteY)
        {
            transform.position = new Vector3(transform.position.x, - limiteY, 0);                 
        }
        if(transform.position.y < -limiteY)
        { 
            transform.position = new Vector3(transform.position.x,  limiteY, 0);
            
        }

        if (transform.position.x > limiteX)
        {
            transform.position = new Vector3(-limiteX,transform.position.y, 0);
            
        }
        if (transform.position.x < -limiteX)
        {
            transform.position = new Vector3(limiteX,transform.position.y, 0);
 
        }
    }

}
