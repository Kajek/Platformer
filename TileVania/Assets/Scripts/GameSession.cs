using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSession : MonoBehaviour
{
    //public static GameSession instance = null;
    private static GameSession _instance;
    public static GameSession Instance => _instance;


    [SerializeField] int score;        
    [SerializeField] Text scoreText;
    

    private void Awake()
    {
        _instance = this;

        DontDestroyOnLoad(this);
        //if (instance == null)
        //{
        //    instance = this;
        //}
        //else if (instance != this)
        //{
        //    Destroy(gameObject);
        //}

        //DontDestroyOnLoad(gameObject);
        //int numGameSessions = FindObjectsOfType<GameSession>().Length;
        //if (numGameSessions > 1)
        //{
        //    Destroy(gameObject);
        //}
        //else
        //{
        //    DontDestroyOnLoad(gameObject);
        //}
    }



    // Start is called before the first frame update
    void Start()
    {        
        scoreText.text = score.ToString();
    }

    private void Update()
    {
        
    }

    public void AddToScore(int pointsToAdd)
    {
        score += pointsToAdd;
        scoreText.text = score.ToString();
    }


    public void ResetGame()
    {
        Destroy(gameObject);
    }
    public int GetScore()
    {
        return score;
    }


}
