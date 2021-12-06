using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameSession : MonoBehaviour
{
    public static GameSession instance;
    [SerializeField] GameObject livesHolder;

    [SerializeField] int playerLives = 3;
    [SerializeField] int score = 0;

    
    [SerializeField] Text scoreText;

    

    private void Awake()
    {

        if (instance = null)
        {
            instance = this;
        }

        int numberGameSession = FindObjectsOfType<GameSession>().Length;
        if (numberGameSession > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
        CoinSpawner.instance.SpawnCoins();
    }
    // Start is called before the first frame update
    void Start()
    {
        
        scoreText.text = score.ToString();
    }
    public void AddToScore(int pointsAdd)
    {
        score += pointsAdd;
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
            ResetGameSession();
        }
    }

    private void TakeLife()
    {

        playerLives--;
        livesHolder.transform.GetChild(playerLives).gameObject.SetActive(false);
        if(playerLives == 0)
        {
            //playerLives = 3;
        }
        var currentScenceIndex = SceneManager.GetActiveScene().buildIndex;
        
        SceneManager.LoadScene(currentScenceIndex);
        
        

    }

    private void ResetGameSession()
    {
        SceneManager.LoadScene(0);
        
        
        Destroy(gameObject);
    }
}
