using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed = 100;
    Rigidbody2D rb;   
   
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * speed);
    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Astecovid")
        {
            collision.gameObject.GetComponent<AstwroidController>().Muerte();
            Destroy(gameObject);
        }
    }
}
        
       
        
        
      