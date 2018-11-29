using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Questions : MonoBehaviour {

    // TODO: add at least 10 questions and make some schema for detecting the answers
    // Read input from joysticks
    // Duplicate this room and add "distractions"
    // reference for buttons: http://wiki.unity3d.com/index.php?title=Xbox360Controller

    // Questions from: https://collegereadiness.collegeboard.org/sample-questions/math/calculator-permitted/

    public Text board;
    public Text response;
    public int currentQuestion;
    public int total;

    public bool submitted;

    string[] testQuestions = {
        "Aaron is staying at a hotel that charges $99.95 per night plus tax for a room. A tax of 8% is applied to the room rate, and an additional onetime untaxed fee of $5.00 is charged by the hotel. Which of the following represents Aaron's total charge, in dollars, for staying x nights?\nA) (99.5 + 0.08x) + 5\nB)1.08(99.95x) + 5\nX)1.08(99.95x + 5)\nY)1.08(99.95 + 5)x",
        "A company’s manager estimated that the cost C, in dollars, of producing n items is C equals 7 n plus 350. The company sells each item for $12. The company makes a profit when total income from selling a quantity of items is greater than the total cost of producing that quantity of items. Which of the following inequalities gives all possible values of n for which the manager estimates that the company will make a profit?\nA)n < 70\nB)n < 84\nX)n > 70\tY)n > 84",
        "At a primate reserve, the mean age of all the male primates is 15 years, and the mean age of all female primates is 19 years. Which of the following must be true about the mean age m of the combined group of male and female primates at the primate reserve?\nA) m = 17 \nB) m > 17\nX) m < 17 \nY) 15 < m < 19",
        "A biology class at Central High School predicted that a local population of animals will double in size every 12 years. The population at the beginning of 2014 was estimated to be 50 animals. If P represents the population n years after 2014, then which of the following equations represents the class’s model of the population over time?\nA) P = 12 + 50n\nB) P = 50 + 12n\nX) 50*(2)^(12n) \nY) 50*2^(n/12)",
        "Solve for x.\n33x + 70 = 136\nA) x = 1 \nB) x = 1.5\nX) x = 2\nY) x=0.5"
    };
    string[] answers = {"joystick button 1", "joystick button 2", "joystick button 3", "joystick button 3", "joystick button 2"};
    string[] responses = new string[5];

	// Use this for initialization
	void Start () {
        board.text = testQuestions[0];
        Debug.Log(responses[0] == null);
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!submitted)
        {
            if (Input.GetKeyDown("joystick button 7"))
            {
                submitted = true;
                for (int x = 0; x < 5; x++)
                {
                    if (responses[x] != null && responses[x].Equals(answers[x]))
                    {
                        total++;
                    }
                }
                board.text = "You're done! Your score was " + total;
                response.text = "Good job, kid";
            }
            else
            {
                if (Input.GetKeyDown("joystick button 5"))
                {
                    if (currentQuestion < 4)
                    {
                        Debug.Log("right trigger");
                        currentQuestion++;
                        board.text = testQuestions[currentQuestion];

                        if (responses[currentQuestion] == null)
                        {
                            response.text = "";
                        }
                        else if (responses[currentQuestion].Equals("joystick button 0"))
                        {
                            response.text = "A";
                        }
                        else if (responses[currentQuestion].Equals("joystick button 1"))
                        {
                            response.text = "B";
                        }
                        else if (responses[currentQuestion].Equals("joystick button 2"))
                        {
                            response.text = "X";
                        }
                        else if (responses[currentQuestion].Equals("joystick button 3"))
                        {
                            response.text = "Y";
                        }
                    }
                }
                else if (Input.GetKeyDown("joystick button 4"))
                {
                    if (currentQuestion > 0)
                    {
                        Debug.Log("left trigger");
                        currentQuestion--;
                        board.text = testQuestions[currentQuestion];
                        if (responses[currentQuestion] == null)
                        {
                            response.text = "";
                        }
                        else if (responses[currentQuestion].Equals("joystick button 0"))
                        {
                            response.text = "A";
                        }
                        else if (responses[currentQuestion].Equals("joystick button 1"))
                        {
                            response.text = "B";
                        }
                        else if (responses[currentQuestion].Equals("joystick button 2"))
                        {
                            response.text = "X";
                        }
                        else if (responses[currentQuestion].Equals("joystick button 3"))
                        {
                            response.text = "Y";
                        }
                    }
                }

                if (Input.GetKeyDown("joystick button 0"))
                {
                    responses[currentQuestion] = "joystick button 0";
                    response.text = "A";
                }
                else if (Input.GetKeyDown("joystick button 1"))
                {
                    responses[currentQuestion] = "joystick button 1";
                    response.text = "B";
                }
                else if (Input.GetKeyDown("joystick button 2"))
                {
                    responses[currentQuestion] = "joystick button 2";
                    response.text = "X";
                }
                else if (Input.GetKeyDown("joystick button 3"))
                {
                    responses[currentQuestion] = "joystick button 3";
                    response.text = "Y";
                }
            }
        }
        else
        {
            if (Input.GetKeyDown("joystick button 0"))
            {
                SceneManager.LoadScene("DistractionRoom");
            }
        } // else if pressed a, load distraction room.
    }
}
