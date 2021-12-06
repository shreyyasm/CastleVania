using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class RestTimer : MonoBehaviour
{
    public static RestTimer instance;
    [SerializeField] float timeValue = 90;
    [SerializeField] GameObject player;
    
  
    [SerializeField] GameObject spawnPoint;
    bool spawned = false;
    public Text timeText;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    private void Update()
    {
       
            if (timeValue > 0)
            {
                timeValue -= Time.deltaTime;
            }
            else
            {
                timeValue = 0;


            }
            DisplayTime(timeValue);
            if (timeValue == 0)
            {
                CoinSpawner.instance.DeleteCoins();
                CoinSpawner.instance.SpawnCoins();
                
                Player.instance.RewindSound();
                player.transform.position = spawnPoint.transform.position;
                timeValue += 15;

            }


        

    }
   
    void DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    public void AddTime()
    {
        timeValue += 10;
    }
    
}
