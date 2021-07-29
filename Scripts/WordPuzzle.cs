using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordPuzzle : MonoBehaviour
{
    public Text wordPuzzle;
    public Text choice1;
    public Text choice2;
    public Text choice3;
    public ChoiceTrigger choice1Object;
    public ChoiceTrigger choice2Object;
    public ChoiceTrigger choice3Object;
    private string[] words = {"Game","School","Fun"};
    private string[] letters = {"ZYXUO", "TNMXZ", "OELVK"};
    

    // Start is called before the first frame update
    void Start()
    {
        int randomWord = Random.Range(0, words.Length);                   // Pick a word from the list
        int randomLetter = Random.Range(0, words[randomWord].Length - 1); // Pick a letter from the selected word
        generatePanel(randomWord, randomLetter);
    }

    private void generatePanel(int randomWordIndex, int randomLetterIndex)
    {
        char[] wordArr = words[randomWordIndex].ToCharArray();
        wordArr[randomLetterIndex] = '_';
        wordPuzzle.text = new string(wordArr);
        int num1, num2;
        int? previous = null;

        int rightChoice = Random.Range(0, 2);
        switch(rightChoice)
        {
            case 0:
                num1 = GenerateDifferentNumber(0, 4, previous);
                num2 = GenerateDifferentNumber(0, 4, num1);
                choice1.text = words[randomWordIndex][randomLetterIndex].ToString().ToUpper();
                choice2.text = letters[randomWordIndex][num1].ToString().ToUpper();
                choice3.text = letters[randomWordIndex][num2].ToString().ToUpper();
                choice1Object.setChosen(true);
                break;
            case 1:
                num1 = GenerateDifferentNumber(0, 4, previous);
                num2 = GenerateDifferentNumber(0, 4, num1);
                choice2.text = words[randomWordIndex][randomLetterIndex].ToString().ToUpper();
                choice1.text = letters[randomWordIndex][num1].ToString().ToUpper();
                choice3.text = letters[randomWordIndex][num2].ToString().ToUpper();
                choice2Object.setChosen(true);
                break;
            case 2:
                num1 = GenerateDifferentNumber(0, 4, previous);
                num2 = GenerateDifferentNumber(0, 4, num1);
                choice3.text = words[randomWordIndex][randomLetterIndex].ToString().ToUpper();
                choice2.text = letters[randomWordIndex][num1].ToString().ToUpper();
                choice1.text = letters[randomWordIndex][num2].ToString().ToUpper();
                choice3Object.setChosen(true);
                break;
        }
       
    }

    private int GenerateDifferentNumber(int start, int end, int? previousNumber)
    {
        int number; 
        if(previousNumber == null)
            number = Random.Range(start, end);
        else
        {
            do
            {
                number = Random.Range(start, end);
            }while(number==previousNumber);
        }

        return number;
    }
}
