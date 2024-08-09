using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameManager gm;
    private Animator anim;
    Rigidbody2D rgbd2D;
    public float speed = 2f;
    public ParticleSystem dust;
    private bool isgrounded;
    public Transform groundcheck;
    public float checkradius;
    public LayerMask whatisground;
    public int howmanyjumps;
    AudioSource audiosource;
    public AudioClip Land1;
    public AudioClip Land2;
    public AudioClip Land3;
    public AudioClip Land4;
    private void Start()
    {
        anim = GetComponent<Animator>();
        rgbd2D = GetComponent<Rigidbody2D>();
        audiosource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        isgrounded = Physics2D.OverlapCircle(groundcheck.position,checkradius,whatisground);
        if (Input.GetKey("space") && isgrounded == true || Input.GetKey(KeyCode.UpArrow) && isgrounded==true)
        {
            anim.SetTrigger("TakeOff");
            rgbd2D.velocity = new Vector3(0, 5, 0);
           
        }
        if (isgrounded == true)
        {
            howmanyjumps = 1;
            anim.SetBool("IsFalling", false);
            anim.SetBool("IsJumpingg", false);
        }    
        else
        {
            if(Input.GetKey("space") && howmanyjumps > 0 || Input.GetKey(KeyCode.UpArrow) && howmanyjumps > 0)
            {
                anim.SetTrigger("TakeOff");
                rgbd2D.velocity = new Vector3(0, 5, 0);
                howmanyjumps -= 1;
            }
            anim.SetBool("IsFalling", true);
            anim.SetBool("IsJumpingg", true);
        }    

        float moveinput = Input.GetAxisRaw("Horizontal");
        rgbd2D.velocity = new Vector2(moveinput * speed, rgbd2D.velocity.y);
        if(moveinput==0)
        {
            anim.SetBool("IsRunning", false);
        }    
        else if(moveinput<0)
        {
            anim.SetBool("IsRunning", true);
            transform.eulerAngles = new Vector3(0, 180, 0);
            

        }    
        else if(moveinput>0)
        {           
            anim.SetBool("IsRunning", true);
            transform.eulerAngles = new Vector3(0, 0, 0);
            
        }    
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        int i;
        i = Random.Range(0, 20);
        if (i >= 0 && i < 5)
            audiosource.PlayOneShot(Land1);
        else if(i>=5&&i<10)
            audiosource.PlayOneShot(Land2);
        else if (i >= 10 && i < 15)
            audiosource.PlayOneShot(Land3);
        else if (i >= 15 && i <=20)
            audiosource.PlayOneShot(Land4);
        dust.Play();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "spike")
        {
            Destroy(gameObject);
            gm.GameOver();
           
        }
    }
}
