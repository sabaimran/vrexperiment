using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Questions : MonoBehaviour {

    // TODO: add at least 10 questions and make some schema for detecting the answers
    // Read input from joysticks
    // Duplicate this room and add "distractions"

    public Text board;

    string[] testQuestions = { "Aaron is staying at a hotel that charges $99.95 per night plus tax for a room. A tax of 8% is applied to the room rate, and an additional onetime untaxed fee of $5.00 is charged by the hotel. Which of the following represents Aaron's total charge, in dollars, for staying x nights?\nA) (99.5 + 0.08x) + 5\nB)1.08(99.95x) + 5\nY)1.08(99.95x + 5)\nX)1.08(99.95 + 5)x" };

	// Use this for initialization
	void Start () {
        board.text = testQuestions[0];
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("joystick button 0")) {
            Debug.Log("pressed A");
        }
        else if (Input.GetKeyDown("joystick button 1"))
        {
            Debug.Log("pressed B");
        }
        else if (Input.GetKeyDown("joystick button 2"))
        {
            Debug.Log("pressed X");
        }
        else if (Input.GetKeyDown("joystick button 3"))
        {
            Debug.Log("pressed Y");
        }
    }
}
