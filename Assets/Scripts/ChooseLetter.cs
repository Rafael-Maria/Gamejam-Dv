using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChooseLetter : MonoBehaviour
{
    string st = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    string[] code={".-","-...","-.-.","-..",".","..-.","--.","....","..",".---","-.-",".-..","--","-.","---",".--.","--.-",".-.","...","-","..-","...-",".--","-..-","-.--","--.."};
    char letter; // letter to compare
    int random; //random position in array
    int position; //position of the morse, of the actual letter
    [SerializeField] Text letterText; // letter that will be visible
    [SerializeField] Text answerText; //anser that will be visible
    string answer; //answer used to compare
    float startTime; //Time used in keys
    [SerializeField] AudioClip dotSound; //sound used in dots of morse
    [SerializeField] AudioClip dashSound; // sound used in dashes of morse code
    [SerializeField] AudioSource audioSource; //Source of the audio
    Queue<AudioClip> clipQueue; //A queue with the clips to play
    // Start is called before the first frame update
    bool checker;
    void Start()
    {
        position = 0;
        audioSource = GetComponent<AudioSource>();
        checker=true;
        answer="";
        answerText.text="";
        random =Random.Range(0,st.Length);
        letter = st[random];
        letterText.text=letter.ToString();
        string[] characters = new string[code[random].Length];
        for (int i = 0; i < code[random].Length; i++)
        {
             characters[i] = System.Convert.ToString(code[random][i]);
        }
        for(int i = 0; i < characters.Length; i++)
        {
            //Debug.Log(characters[i]);
            if(characters[i].Equals("-")){
                clipQueue.Enqueue(dashSound);
            }
            if(characters[i].Equals(".")){
                clipQueue.Enqueue(dotSound);
            }
        }
        //Choose one letter from the alfabet
        //get the correspond morse from that letters
    }

    public void stopScriptButton(){
        checker=false;
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
                if(string.CompareOrdinal(System.Convert.ToString(code[random][position-1]),".") != 0){
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
                if(string.CompareOrdinal(System.Convert.ToString(code[random][position-1]),"-") != 0){
                    position=0;
                    answer="";
                    answerText.text="";
                }
            }
            if (audioSource.isPlaying == false && clipQueue.Count > 0) {
                audioSource.clip = clipQueue.Dequeue();
                audioSource.Play();
                //need a phatom sound to break the repeat 2 options or put a clip with no sound or some math trick using %
                clipQueue.Enqueue(dotSound);
            }

            if (string.CompareOrdinal(answer, code[random]) == 0){
                //got it rigth
                stopScriptButton();
            }
        }else{
            if (clipQueue.Count > 0) {
                clipQueue.Clear();
            }
            if (audioSource.isPlaying == true) {
                audioSource.Stop();
            }
            //if time runs out compare the answer with the result
            if (string.CompareOrdinal(answer, code[random]) == 0){
                //got it rigth
                Debug.Log("Congrats");
            }else{
                //got it wrong
                Debug.Log("Loser");
            }
        }
    }
}
