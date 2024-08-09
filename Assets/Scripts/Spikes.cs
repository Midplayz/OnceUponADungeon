using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    public ParticleSystem blood;
    public AudioClip Explosion1;
    public AudioClip Explosion2;
    public AudioClip Explosion3;
    AudioSource aus;
    // Start is called before the first frame update
    private void Start()
    {
        aus= GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            int i;
            i = Random.Range(0, 15);
            if (i >= 0 && i < 5)
                aus.PlayOneShot(Explosion1);
            else if (i >= 5 && i < 10)
                aus.PlayOneShot(Explosion2);
            else if (i >= 10 && i <= 15)
                aus.PlayOneShot(Explosion3);
            blood.Play();
        }
    }
}