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
    [SerializeField] Text letterText; // letter that will be visible
    [SerializeField] Text answerText; //anser that will be visible
    string answer; //answer used to compare

    float startTime; //Time used in keys
    // Start is called before the first frame update
    bool checker;
    void Start()
    {
        checker=true;
        answer="";
        answerText.text="";
        random =Random.Range(0,st.Length);
        letter = st[random];
        letterText.text=letter.ToString();
        //Choose one letter from the alfabet
        //get the correspond morse from that letters
    }

    void stopScriptButton(){
        checker=false;
    }

    // Update is called once per frame
    void Update()
    {
        //Add the space bar time if one click ".", 1 > sec "-"
        //write the answer
        if(checker){
            if (Input.GetKeyDown("space"))
            {
                startTime = Time.time;
            }
            if (Input.GetKeyUp("space") && Time.time - startTime < 0.5f)
            {
                answer+=".";
                answerText.text+=". ";
                //Debug.Log((Time.time - startTime).ToString("00:00.00"));
            }

            if (Input.GetKeyUp("space") && Time.time - startTime >= 0.5f)
            {
                answer+="-";
                answerText.text+="- ";
                //Debug.Log((Time.time - startTime).ToString("00:00.00"));
            }
        }else{
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
