using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstwroidController : MonoBehaviour
{
    public float speed_min;
    public float speed_max; 
    Rigidbody2D rb;
    public AstecovidManager manager;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Vector2 direccion = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        direccion = direccion * Random.Range(speed_min, speed_max);
        Debug.Log(Random.Range(-1f, 1f));
        rb.AddForce(direccion);
        manager.astecovids += 1;

    }

    
    void Update()
    {
      
    }

    public void Muerte()
    {

        if (transform.localScale.x > 0.25f)

        {
            GameObject temp1 = Instantiate(manager.astecovid, transform.position, transform.rotation);
            temp1.GetComponent<AstwroidController>().manager = manager;
            temp1.transform.localScale = transform.localScale * 0.5f;
            GameObject temp2 = Instantiate(manager.astecovid, transform.position, transform.rotation);
            temp2.GetComponent<AstwroidController>().manager = manager;
            temp2.transform.localScale = transform.localScale * 0.5f;
             
        }
        GameManager.instance.puntuacion += 100;
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



