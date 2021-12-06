using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    [SerializeField] int pointsOfCoin = 1;
    [SerializeField] AudioClip coinSFX;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        FindObjectOfType<GameSession>().AddToScore(pointsOfCoin);
        AudioSource.PlayClipAtPoint(coinSFX,transform.position,10f);
        
        Destroy(gameObject);
    }
}
