using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerClamp : MonoBehaviour
{
    [SerializeField] Text resetTimer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    
    void Update()
    {
        
        Vector3 timerPos = Camera.main.WorldToScreenPoint(this.transform.position);
        resetTimer.transform.position = timerPos;
    }
}
