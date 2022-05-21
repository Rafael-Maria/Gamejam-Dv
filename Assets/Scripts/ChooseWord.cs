using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ChooseWord : MonoBehaviour
{
    string st = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    string[] words;
    string[] code={".-","-...","-.-.","-..",".","..-.","--.","....","..",".---","-.-",".-..","--","-.","---",".--.","--.-",".-.","...","-","..-","...-",".--","-..-","-.--","--.."};
    char letter; // letter to compare
    int random; //random position in array
    int position; //position of the morse, of the actual letter
    int positionWord; //character of the word we are working
    int points; //points that we get
    [SerializeField] Text pointsText; //Text to show the points
    [SerializeField] Text wordText; //Text to try discover the word
    [SerializeField] Text letterText; // letter that will be visible
    [SerializeField] Text answerText; //answer that will be visible
    string answer; //answer used to compare
    float startTime; //Time used in keys
    [SerializeField] TextAsset dataFile;//File with the optional words
    [SerializeField] AudioClip dotSound; //sound used in dots of morse
    [SerializeField] AudioClip dashSound; // sound used in dashes of morse code
    [SerializeField] AudioSource audioSource; //Source of the audio
    Queue<AudioClip> clipQueue = new Queue<AudioClip>(); //A queue with the clips to play
    // Start is called before the first frame update
    List<String> wordList = new List<String>();//list with every word getted
    bool checker; // checker if the code is done correctly
    bool timer; //if we use a decrese timer
    int index ; //position in the alphabet - used to get the morse from one specific letter
    string[] characters = new string[5];
    void Start()
    {
        points=0;
        if(pointsText){
                    pointsText.text="Points: " +points.ToString();
        }
        timer = true;
        position = 0;
        positionWord=0;
        audioSource = GetComponent<AudioSource>();
        checker=true;
        answer="";
        answerText.text="";
        words = dataFile.text.ToUpper().Split('\n');//
        //Miss import txt File
        random =UnityEngine.Random.Range(0,words.Length);
        //words[random]="AMOR";
        letter = words[random][positionWord];
        letterText.text=letter.ToString();
        wordText.text="";
        index = st.IndexOf(letter);
        Array.Clear(characters,0,characters.Length);
        for (int i = 0; i < code[index].Length; i++)
        {
             characters[i] = System.Convert.ToString(code[index][i]);
        }

        //prepare the sonds of that letter
        for(int i = 0; i < characters.Length; i++)
        {
            //Debug.Log(characters[i]);
            if(string.CompareOrdinal(characters[i], "-") == 0){
                clipQueue.Enqueue(dashSound);
            }
            if(string.CompareOrdinal(characters[i], ".") == 0){
                clipQueue.Enqueue(dotSound);
            }
        }
        //Choose one letter from the alfabet
        //get the correspond morse from that letters
    }

    void init(){
        checker=true;
        answer="";
        answerText.text="";
        random =UnityEngine.Random.Range(0,words.Length);
        position = 0;
        positionWord=0;
        letter = words[random][positionWord];//System.Convert.ToString(words[random][positionWord]);
        letterText.text=letter.ToString();
        wordList.Add(wordText.text);
        wordText.text="";
        index = st.IndexOf(letter);
        Array.Clear(characters,0,characters.Length);
        for (int i = 0; i < code[index].Length; i++)
        {
             characters[i] = System.Convert.ToString(code[index][i]);
        }
        for(int i = 0; i < characters.Length; i++)
        {
            //Debug.Log(characters[i]);
            if(string.CompareOrdinal(characters[i], "-") == 0){
                clipQueue.Enqueue(dashSound);
            }
            if(string.CompareOrdinal(characters[i], ".") == 0){
                clipQueue.Enqueue(dotSound);
            }
        }
    }
    public void stopScriptButton(){
        checker=false;
        timer = false;
    }

    // Update is called once per frame
    void Update()
    {
        //
        //Add the space bar time if one click ".", 1 > sec "-"
        //write the answer
        if(checker){
            if (Input.GetKeyDown("space"))
            {
                startTime = Time.time;
            }
            if (Input.GetKeyUp("space") && Time.time - startTime < 0.2f)
            {
                position++;
                answer+=".";
                answerText.text+=". ";
                //Debug.Log((Time.time - startTime).ToString("00:00.00"));~
                if(string.CompareOrdinal(System.Convert.ToString(code[index][position-1]),".") != 0){
                    position=0;
                    answer="";
                    answerText.text="";
                }
            }

            if (Input.GetKeyUp("space") && Time.time - startTime >= 0.2f)
            {
                position++;
                answer+="-";
                answerText.text+="- ";
                //Debug.Log((Time.time - startTime).ToString("00:00.00"));
                if(string.CompareOrdinal(System.Convert.ToString(code[index][position-1]),"-") != 0){
                    position=0;
                    answer="";
                    answerText.text="";
                }
            }
            if (string.CompareOrdinal(answer, code[index]) == 0){
                //got it rigth
                if(pointsText){
                    points++;
                    pointsText.text="Points: " + points.ToString();
                }
                checker=false;
                wordText.text+=letter;
                Debug.Log("Congrats");
            }
            if (audioSource.isPlaying == false && clipQueue.Count > 0) {
                audioSource.clip = clipQueue.Dequeue();
                audioSource.Play();
                //need a phatom sound to break the repeat 2 options or put a clip with no sound or some math trick using %
                clipQueue.Enqueue(audioSource.clip);
            }
        }else{
            if (clipQueue.Count > 0) {
                clipQueue.Clear();
            }
            if (audioSource.isPlaying == true) {
                audioSource.Stop();
            }
            if(((positionWord + 2) != words[random].Length) && timer){
                positionWord++;
                position = 0;
                checker=true;
                answer="";
                answerText.text="";
                letter = words[random][positionWord];
                letterText.text=letter.ToString();
                index = st.IndexOf(letter);
                Array.Clear(characters,0,characters.Length);
                for (int i = 0; i < code[index].Length; i++)
                {
                    characters[i] = System.Convert.ToString(code[index][i]);
                }
                for(int i = 0; i < characters.Length; i++)
                {
                    //Debug.Log(characters[i]);
                    if(string.CompareOrdinal(characters[i], "-") == 0){
                        clipQueue.Enqueue(dashSound);
                    }
                    if(string.CompareOrdinal(characters[i], ".") == 0){
                        clipQueue.Enqueue(dotSound);
                    }
                }
            }else{
                //if time runs out compare the answer with the result
                if (string.CompareOrdinal(answer, code[index]) == 0){
                    //got it rigth
                    if(GameObject.Find("Timer").GetComponent<Timer>() != null){
                        if(GameObject.Find("Timer").GetComponent<Timer>()){
                            GameObject.Find("Timer").GetComponent<Timer>().incrementTimer();
                        }
                        init();
                    }else{
                        if(GameObject.Find("Timer").GetComponent<TimerIncrease>()){
                            GameObject.Find("Timer").GetComponent<TimerIncrease>().getWord();
                        }
                        answerText.text="Press Esc to retry";
                        letterText.text="Congrats";
                        if (Input.GetKey(KeyCode.Escape))
                        {
                            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                        }
                    }
                }else{
                    //got it wrong
                    Debug.Log("Loser");
                    answerText.text="Press Esc to retry";
                    letterText.text="You lose";
                    if (Input.GetKey(KeyCode.Escape))
                    {
                        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                    }
                }
            }
        }
    }
}
