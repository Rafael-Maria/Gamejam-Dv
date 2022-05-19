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
    void Start()
    {
        currentTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += 1 * Time.deltaTime;
        countdownText.text = "Time: " + currentTime.ToString("0");
    }
}