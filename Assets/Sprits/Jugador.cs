using System.Security.Cryptography;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    // Start is called before the first frame update
    public float fuerzaSalto;
    private Rigidbody2D rigidbody2D;
    private Animator animator;
    public GameManager gameManager;
    public bool saltando = true;
    private float Horizontal;
    public float Speed;
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && saltando == true){
            animator.SetBool("estaSaltando", true);
            rigidbody2D.AddForce(new Vector2(0, fuerzaSalto));
            saltando = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Suelo") 
        {
            animator.SetBool("estaSaltando", false);
            saltando = true;
        }
    }

    private void FixedUpdate(){
        rigidbody2D.velocity = new Vector2(Horizontal * Speed, rigidbody2D.velocity.y);
    }
}
