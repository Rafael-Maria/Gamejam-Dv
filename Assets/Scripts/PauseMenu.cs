using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public new GameObject camera;
    public GameObject pauseMenuUI;
    public GameObject InitialCanvas;
    [SerializeField] AudioSource audioSource;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(GameIsPaused){
                Resume();
            } else {
                Pause();
            }
        }
    }

    public void BackToMainMenu(){
        Debug.Log("Quitting game...");
        SceneManager.LoadScene(0);
    }

    public void Resume(){
        pauseMenuUI.SetActive(false);
        InitialCanvas.SetActive(true);
        Time.timeScale = 1f;
        camera.GetComponent<AudioListener> ().enabled  =  true;
        audioSource.Play();
        GameIsPaused = false;
    }

    public void Pause(){
        pauseMenuUI.SetActive(true);
        InitialCanvas.SetActive(false);
        Time.timeScale = 0f;
        camera.GetComponent<AudioListener> ().enabled  =  false;
        GameIsPaused = true;
    }

    public void LoadOptions(){
        Debug.Log("Loading options...");
    }
}
