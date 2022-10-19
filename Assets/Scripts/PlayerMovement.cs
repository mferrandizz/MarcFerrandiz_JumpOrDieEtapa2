using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.5f;
    public float jumpForce = 2f;
    private float horizontal;
    private Transform playerTransform;
    private Rigidbody2D rb;
    public Animator  anim;
    public bool isGrounded;


    public PlayableDirector director;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        
         if (horizontal == 1)
        {   
            transform.rotation = Quaternion.Euler(0, 0, 0);
            anim.SetBool("Correr", true);
        }      
            else if (horizontal == -1)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            anim.SetBool("Correr", true);
        }else 
        {
            anim.SetBool("Correr", false);
        }

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            anim.SetBool("Jump", true);
        }

        

    }
    void FixedUpdate() {

        rb.velocity = new Vector2 (horizontal * speed, rb.velocity.y);
            
    }

    void OnTriggerEnter2D(Collider2D other) 
    {

        if(other.gameObject.tag == "Cinematica")
        {
            director.Play();
        }
        

    }


}
