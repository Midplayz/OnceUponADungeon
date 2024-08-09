using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    int i;
    double j;
    public GameObject platformnormal;
    public GameObject bouncyplatform;
    public GameOverScreen GameOverScreen;
    int scores;
    int finalscore;
    public TextMeshProUGUI scoretext;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        scores = 0;
        i = 0;
        j = 0;
    }

    // Update is called once per frame
    void Update()
    {
        spawnplatform();
        Score();
        scoretext.text="Score: " + scores;

    }
    public void GameOver()
    {
            Debug.Log("GameOverTrigger");
            GameOverScreen.Setup(finalscore);
    }
    void Score()
    {
        if (Time.timeSinceLevelLoad > j && player != null)
        {
            scores += 1;
            j += 1.5;
        }
        if(scores!=0)
        {
            finalscore = scores;
        }
    }
        void spawnplatform()
    {
        
        if (Time.timeSinceLevelLoad > i && player!=null)
        {
            int y = Random.Range(0, 50);
            float xpos = Random.Range(-2.08f, 2.08f);
            i += 2;
            if (y >= 0 && y < 10 || y >= 30 && y <= 50)
            {
                GameObject pf = Instantiate(platformnormal, new Vector3(xpos, -5.3f, 0.0f), Quaternion.identity);
                Destroy(pf, 8.0f);
            }
            else if (y>=10&&y<30)
            {
                GameObject pfb = Instantiate(bouncyplatform, new Vector3(xpos, -5.3f, 0.0f), Quaternion.identity);
                Destroy(pfb, 8.0f);
            }
        }

    }
}
