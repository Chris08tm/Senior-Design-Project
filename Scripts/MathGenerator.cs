using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MathGenerator : MonoBehaviour
{
    public Text mathProblem;
    public Text choice1;
    public Text choice2;
    public Text choice3;

    public ChoiceTrigger choice1Object;
    public ChoiceTrigger choice2Object;
    public ChoiceTrigger choice3Object;

    private int firstOperand;
    private int secondOperand;
    private string sign;
    private int result;
    private string[] operators = {"+", "-", "*", "/" };
    

    // Start is called before the first frame update
    void Start()
    {
        firstOperand = Random.Range(1, 10);
        secondOperand = Random.Range(1, 10);
        sign = operators[Random.Range(0, operators.Length)];
        generateExpression();
        paintPanel();
    }


    private void generateExpression()
    {
        switch(sign)
        {
            case "+":
                result = firstOperand + secondOperand;
                break;
            case "-":
                result = firstOperand - secondOperand;
                break;
            case "*":
                result = firstOperand * secondOperand;
                break;
            case "/":
                if(firstOperand % secondOperand != 0)
                {
                    firstOperand = secondOperand * Random.Range(2,10);
                    result = firstOperand / secondOperand;
                }
                result = firstOperand / secondOperand;
                break;
        }   
    }

    private void paintPanel()
    {
        mathProblem.text = firstOperand.ToString() + " " + sign + " " + secondOperand.ToString();
        
        int resultSlot = Random.Range(1,3);
        switch(resultSlot)
        {
            case 1:
                choice1.text = result.ToString();
                choice1Object.setChosen(true);
                choice2.text = Random.Range(result + 1, 10).ToString();
                choice3.text = Random.Range(result - 11, 10).ToString();
                break;
            case 2:
                choice2.text = result.ToString();
                choice2Object.setChosen(true);
                choice1.text = Random.Range(result + 1, 10).ToString();
                choice3.text = Random.Range(result - 11, 10).ToString();
                break;
            case 3:
                choice3.text = result.ToString();
                choice3Object.setChosen(true);
                choice2.text = Random.Range(result + 1, 10).ToString();
                choice1.text = Random.Range(result - 11, 10).ToString();
                break;
        }
    }
}
