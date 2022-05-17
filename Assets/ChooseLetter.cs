using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChooseLetter : MonoBehaviour
{
    string st = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    string[] code={".-","-...","-.-.","-..",".","..-.","--.","....","..",".---","-.-",".-..","--","-.","---",".--.","--.-",".-.","...","-","..-","...-",".--","-..-","-.--","--.."};
    char letter;
    int random;
    // Start is called before the first frame update
    void Start()
    {
        //test
        random =Random.Range(st.Length);
        letter = st[random];
        //Choose one letter from the alfabet
        //get the correspond morse from that letters
    }

    // Update is called once per frame
    void Update()
    {
        //Add the space bar time if one click ".", 1 > sec "-"
        //write the answer
        //if time runs out compare the answer with the result
    }
}
