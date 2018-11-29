using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistractionQuestions : MonoBehaviour {

    // TODO: add at least 10 questions and make some schema for detecting the answers
    // Read input from joysticks
    // Duplicate this room and add "distractions"
    // reference for buttons: http://wiki.unity3d.com/index.php?title=Xbox360Controller

    // Questions from: https://collegereadiness.collegeboard.org/sample-questions/math/calculator-permitted/

    public Text board;
    public Text response;
    public int currentQuestion;
    public int total;
    public GameObject ball;
    public AudioClip sheepSounds;
    private AudioSource audioSource;
    private bool goLeft;

    public bool submitted;

    string[] testQuestions = {
        "If (x-1)/3 = k and k = 3, what is the value of x?\nA) 2\nB) 4\nX) 9\nY) 10",
        "On Saturday afternoon, Armand sent m text messages each hour for 5 hours, and Tyrone sent p text messages each hour for 4 hours. Which of the following represents the total number of messages sent by Armand and Tyrone on Saturday afternoon?\nA) 9mp\nB) 20mp\nX) 5m + 4p\nY) 4m + 5p",
        "h = 3a + 30\nA pediatrician uses the model above to estimate the height h of a boy, in inches, in terms of the boy's age a, in years, between the ages of 2 and 5. Based on the model, what is the estimated increase, in inches, of a boy's height each year?\nA) 3 \nB) 5.7\nX) 9.5 \nY) 10",
        "If (a/b)=2, what is the value of (4b/a)?\nA) 0 \nB) 1 \nX) 2\nY) 4",
        "A line in the xy-plane passes through the origin and has a slope of (1/7). Which of the following points lies on the line?\nA) (0,7) \nB) (1,7)\nX) (7,7)\nY) (14,2)"
    };
    string[] answers = {"joystick button 3", "joystick button 2", "joystick button 0", "joystick button 2", "joystick button 1"};
    string[] responses = new string[5];

    private void Awake()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = sheepSounds;
        audioSource.volume = 0.5f;
        audioSource.loop = true;
        audioSource.Play();
    }

    // Use this for initialization
    void Start () {
        board.text = testQuestions[0];
        Debug.Log(responses[0] == null);
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Mathf.Abs(ball.transform.position.z) < 10)
        {
            if (goLeft)
            {
                ball.transform.position = ball.transform.position - new Vector3(0, 0, 0.09f);
            }
            else
            {
                ball.transform.position = ball.transform.position + new Vector3(0, 0, 0.09f);
            }
        }
        else {
            goLeft = !goLeft;
            if (ball.transform.position.z >= 10)
            {
                ball.transform.position = new Vector3(ball.transform.position.x, ball.transform.position.y, 9.9f);
            }
            else
            {
                ball.transform.position = new Vector3(ball.transform.position.x, ball.transform.position.y, -9.9f);
            }
        }
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
                    if (currentQuestion < 5)
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
    }
}
