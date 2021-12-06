using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ScencePersist : MonoBehaviour
{
    int startingScenceIndex;
    private void Awake()
    {
        int numberScencePersist = FindObjectsOfType<ScencePersist>().Length;
        if(numberScencePersist > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        startingScenceIndex = SceneManager.GetActiveScene().buildIndex;

    }

    // Update is called once per frame
    void Update()
    {
        int currentScenceIndex = SceneManager.GetActiveScene().buildIndex;
        if(currentScenceIndex != startingScenceIndex)
        {
            Destroy(gameObject);
        }
    }
}
