using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameOverScreen : MonoBehaviour
{ 
    public Text points;
    public void Setup(int Score)
    {
        gameObject.SetActive(true);
        points.text = "FINAL SCORE: " + Score;
        Debug.Log(Score);
    }
}
