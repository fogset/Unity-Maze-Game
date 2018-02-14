using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberWizard : MonoBehaviour {
    int max, min, guess;
    public int maxguess = 10;
    // Use this for initialization

    public Text text;

    void Start () {
        StarGame();
    }

    void StarGame()
    {
        max = 1000;
        min = 1;
        NextGuess();
    }
    
	void NextGuess()
    {
        guess = Random.Range(min, max + 1);
        text.text = "Is "+ guess.ToString() +" your number?";
        maxguess--;
        print(maxguess);
        if(maxguess <= 0)
        {
            Application.LoadLevel("Win");
        }
    }
	
    public void GuessHigher()
    {
        min = guess;
        NextGuess();
    }
    public void GuessLower()
    {
        max = guess;
        NextGuess();
    }
}
