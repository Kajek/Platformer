using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSession : MonoBehaviour
{
    public static GameSession instance = null;

    [SerializeField] int playerLives;
    [SerializeField] int numOfHearts;
    [SerializeField] Image[] hearts;
    [SerializeField] Sprite fullHeart;
    [SerializeField] Sprite emptyHeart;
    [SerializeField] int score;        
    [SerializeField] Text scoreText;
    [SerializeField] float delayInSeconds;

    private void Awake()
    {

        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
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
        if (playerLives > numOfHearts)
        {
            playerLives = numOfHearts;
        }
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < playerLives)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }

    public void AddToScore(int pointsToAdd)
    {
        score += pointsToAdd;
        scoreText.text = score.ToString();
    }

    public void ProcessPlayerDeath()
    {
        if(playerLives > 1)
        {
            TakeLife();
        }
        else
        {
            LoadGameOver();
        }
    }

    private void TakeLife()
    {
        playerLives --;
        StartCoroutine(WaitBeforeReset()); 
    }
    IEnumerator WaitBeforeReset()
    {
        yield return new WaitForSeconds(delayInSeconds);
        //Destroy(GameMaster.Player);        
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        //Instantiate(PlayerPrefab);//(GameMaster.Player);
    }

    public void LoadGameOver()
    {
        StartCoroutine(WaitAndLoad());
    }

    IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(delayInSeconds);
        SceneManager.LoadScene("Game Over");
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
