using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    public float speed = 10;
    public float rotationspeed = 10;
    public GameObject bala;
    public GameObject boquilla;
    public AudioSource shot;
    public AudioClip shotsound;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        if (vertical > 0)
        {
            rb.AddForce(transform.up * speed * Time.deltaTime);
            anim.SetBool("Impulsing", true);
        }
        else
        {
            anim.SetBool("Impulsing", false);
        }

        float horizontal = Input.GetAxis("Horizontal");
        transform.eulerAngles = transform.eulerAngles - new Vector3(0, 0, horizontal * rotationspeed * Time.deltaTime);

        if (Input.GetButtonDown("Jump"))
        {
            GameObject temp = Instantiate(bala, boquilla.transform.position, transform.rotation);
            Destroy(temp, 2);
            shot.PlayOneShot(shotsound);

        }

    }
    public void Muerte()
    {

        GameManager.instance.vidas -= 1;
        transform.position = new Vector3(0, 0, 0);
        rb.velocity = new Vector2(0, 0);
        if (GameManager.instance.vidas <= 0)
        {
            Destroy(gameObject);
            Time.timeScale = 0;
           
            
        }
    }    
    public void Muerte3()
    {
        
        GameManager.instance.vidas -= 1;
        transform.position = new Vector3(0, 0, 0);
        rb.velocity = new Vector2 (0, 0);
        if (GameManager.instance.vidas <= 0)
        {
            Destroy(gameObject);
            Time.timeScale = 0;
           

        }
               
    }
}
