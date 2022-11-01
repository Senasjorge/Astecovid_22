using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstwroidController : MonoBehaviour
{
    public float speed_min;
    public float speed_max;
    public int puntosAstecovid;
    Rigidbody2D rb;
    public AstecovidManager manager;
   
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Vector2 direccion = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        direccion = direccion * Random.Range(speed_min, speed_max);
        rb.AddForce(direccion);
        manager.astecovids += 1;
    }

    public void Muerte()
    {

        if (transform.localScale.x > 0.3f)

        {
            GameObject temp1 = Instantiate(manager.astecovid, transform.position, transform.rotation);
            temp1.GetComponent<AstwroidController>().manager = manager;
            temp1.transform.localScale = transform.localScale * 0.5f;
            GameObject temp2 = Instantiate(manager.astecovid, transform.position, transform.rotation);
            temp2.GetComponent<AstwroidController>().manager = manager;
            temp2.transform.localScale = transform.localScale * 0.5f;
             
        }
        
        GameManager.instance.puntuacion += puntosAstecovid;
        manager.astecovids -= 1;
        Destroy(gameObject);
               
    }  
    
                        
     private void OnTriggerEnter2D(Collider2D collision)
     {
        if (collision.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerMovement>().Muerte();
                             
        }
               
    }
            
    
}



