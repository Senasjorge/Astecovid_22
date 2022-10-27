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
    new CircleCollider2D collider;
    SpriteRenderer sprite;
    public float speed = 10;
    public float rotationspeed = 10;
    public GameObject bala;
    public GameObject boquilla;
    public GameObject particulasmuerte;
    public AudioSource MuertePlayer;
    public AudioClip muerte;
    private float nextActionTime = 1;
    public float resetplayer = 60;




    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        collider = GetComponent<CircleCollider2D>();
        sprite = GetComponent<SpriteRenderer>();

    }

    void Update()
    {
        //Movimiento Personaje

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
        if(GameManager.instance.puntuacion >=100)

        {
            rb.AddForce(transform.up * 4.5f * Time.deltaTime );
            anim.SetBool("Impulsing", true);
        }
        float horizontal = Input.GetAxis("Horizontal");
        transform.eulerAngles = transform.eulerAngles - new Vector3(0, 0, horizontal * rotationspeed * Time.deltaTime);

        if (Input.GetButtonDown("Jump"))
        {
            GameObject temp = Instantiate(bala, boquilla.transform.position, transform.rotation);
            Destroy(temp, 2);
        }
        restartplayer();

    }
    public void Muerte()
    {
        MuertePlayer.PlayOneShot(muerte);
        GameObject temp = Instantiate(particulasmuerte, transform.position, transform.rotation);
        Destroy (temp, 2);
        StartCoroutine(Respawn_Coroutine());

    }   
        IEnumerator Respawn_Coroutine()
        {
            collider.enabled = false;
            sprite.enabled = false;
            yield return new WaitForSeconds(2);
            collider.enabled = true;
            sprite.enabled = true;
            
            GameManager.instance.vidas -= 1;
            transform.position = new Vector3(0, 0, 0);
            rb.velocity = new Vector2(0, 0);
            
        // collider desactivado al reaparecer
           
            collider.enabled = false;           
            yield return new WaitForSeconds(5);
            collider.enabled = true;
            

            if (GameManager.instance.vidas <= 0)
            {
                Destroy(gameObject);
                Time.timeScale = 0;

            }
        }
    private void restartplayer()
        //Restablecer Nave cada cierto tiempo. Configurable en  menu script PlayerMovement(EXTRA RESTABLECER CADA 60 SEGUNDOS)
    {
        if (Time.time > nextActionTime)
        {
            
            nextActionTime += resetplayer;
            transform.position = new Vector3(0, 0, 0);
            rb.velocity = new Vector2(0, 0);

        }
    }

}

