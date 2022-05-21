using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class TimerIncrease : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Text countdownText2;
    float currentTime2;
    bool active;
    void Start()
    {
        active = true;
        currentTime2 = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(active){
            currentTime2 += 1 * Time.deltaTime;
            countdownText2.text = "Time: " + currentTime2.ToString("0");
        }
    }
    public void getWord(){
        active=false;
    }
    public void reset(){
        currentTime2 = 0f;
        active=true;
    }
}