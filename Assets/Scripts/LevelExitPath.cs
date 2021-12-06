using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelExitPath : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 2f;
    [SerializeField] float levelExitSlowmo = 0.2f;
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
        StartCoroutine(LoadNextScence());
    }

    IEnumerator LoadNextScence()
    {
        Time.timeScale = levelExitSlowmo;
        yield return new WaitForSecondsRealtime(levelLoadDelay);
        Time.timeScale = 1f;

        var currentScenceIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScenceIndex + 1);
    }
}
