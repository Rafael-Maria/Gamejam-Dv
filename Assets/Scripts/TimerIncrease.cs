using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class TimerIncrease : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Text countdownText;
    float currentTime;
    bool active;
    void Start()
    {
        active = true;
        currentTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(active){
            currentTime += 1 * Time.deltaTime;
            countdownText.text = "Time: " + currentTime.ToString("0");
        }
    }
    public void getWord(){
        active=false;
    }
    public void reset(){
        currentTime = 0f;
        active=true;
    }
}