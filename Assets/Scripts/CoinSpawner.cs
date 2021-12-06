using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public static CoinSpawner instance;


    [SerializeField] GameObject pos1;
    [SerializeField] GameObject pos2;
    [SerializeField] GameObject pos3;
    [SerializeField] GameObject pos4;
    //[SerializeField] GameObject pos5;
    [SerializeField] GameObject coin;
    // Start is called before the first frame update
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawnCoins()
    {
        Instantiate(coin, pos1.transform.position, Quaternion.identity);
        Instantiate(coin, pos2.transform.position, Quaternion.identity);
        Instantiate(coin, pos3.transform.position, Quaternion.identity);
        Instantiate(coin, pos4.transform.position, Quaternion.identity);
       // Instantiate(coin, pos5.transform.position, Quaternion.identity);

    }
    public void DeleteCoins()
    {
        GameObject[] coins = GameObject.FindGameObjectsWithTag("Collectable");
        foreach (GameObject target in coins)
        {
            GameObject.Destroy(target);
        }
    }
}
