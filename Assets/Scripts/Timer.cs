using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Text countdownText;
    float currentTime;
    public float startingTime = 10f;
    public float incrementTime = 5f;
    void Start()
    {
        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        countdownText.text = "Time: " + currentTime.ToString("0");

        if (currentTime <= 0)
        {
            //block write more
            GameObject.Find("Letter").GetComponent<ChooseWord>().stopScriptButton();
            currentTime = 0;
        }
    }

    public void incrementTimer(){
           currentTime+=incrementTime;
    }
}