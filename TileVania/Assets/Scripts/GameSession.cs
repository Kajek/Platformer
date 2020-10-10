using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSession : MonoBehaviour
{
    
    private static GameSession _instance;
    public static GameSession Instance => _instance;


    [SerializeField] int score;        
    [SerializeField] Text scoreText;
    

    private void Awake()
    {
        _instance = this;
        DontDestroyOnLoad(this);      
    }



    // Start is called before the first frame update
    void Start()
    {        
        scoreText.text = score.ToString();
    }


    public void AddToScore(int pointsToAdd)
    {
        score += pointsToAdd;
        scoreText.text = score.ToString();
    }


    public void ResetGameSession()
    {
        Destroy(gameObject);
    }
    public int GetScore()
    {
        return score;
    }


}
