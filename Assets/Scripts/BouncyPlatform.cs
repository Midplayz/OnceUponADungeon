using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyPlatform : MonoBehaviour
{
    public float bounciness;
    public int bounces;
    AudioSource aus;
    public AudioClip bouncesfx;
    // Start is called before the first frame update
    void Start()
    {
        bounces = 1;
        aus = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        
        if (bounces > 0)
        {
            other.rigidbody.AddForce(Vector2.up * bounciness, ForceMode2D.Impulse);
            aus.PlayOneShot(bouncesfx);
            bounces -= 1; 
        }
        else if(bounces==0)
        {
            other.rigidbody.AddForce(Vector2.up * 8, ForceMode2D.Impulse);
            aus.PlayOneShot(bouncesfx);
        }
    }
}
