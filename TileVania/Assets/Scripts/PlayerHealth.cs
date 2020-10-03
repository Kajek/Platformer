﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    private static PlayerHealth _instance;
    public static PlayerHealth Instance => _instance;

    //public static PlayerHealth instance = null;

    [SerializeField] int playerLives;
    [SerializeField] int numOfHearts;
    [SerializeField] Image[] hearts;
    [SerializeField] Sprite fullHeart;
    [SerializeField] Sprite emptyHeart;

    [SerializeField] float delayInSeconds;
    // Start is called before the first frame update
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
    }

        // Update is called once per frame
        void Update()
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

    public void ProcessPlayerDeath()
    {
        if (playerLives > 1)
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
        playerLives--;
        StartCoroutine(WaitBeforeReset());
    }
    IEnumerator WaitBeforeReset()
    {
        yield return new WaitForSeconds(delayInSeconds);
        //Destroy(GameMaster.Player);        
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        //GameMaster.Player.ResetPlayer();
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
    public void ResetPlayerHealth()
    {
        Destroy(gameObject);
    }
}
