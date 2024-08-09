using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platforms : MonoBehaviour
{
    Rigidbody2D rb;
    public float minspeed;
    public float maxspeed = 7;
    float i;
    // Start is called before the first frame update
    void Start()
    {
        minspeed = 1;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeSinceLevelLoad > i)
        {
            if(minspeed<maxspeed)
            {
                minspeed += 0.1f;
            }
            i += 1.5f;
        }
        rb.velocity = new Vector2(0, minspeed);
    }
}
