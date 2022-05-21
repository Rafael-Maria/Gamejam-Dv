using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void PlayPractice(){
        SceneManager.LoadScene(1);
    }

    public void PlayAdvanced(){
        SceneManager.LoadScene(2);
    }

    public void QuitGame(){
        Debug.Log("QUIT!");
        Application.Quit();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
