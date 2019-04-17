using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using VRTK;
using UnityEngine.SceneManagement;


public class MathProgram : MonoBehaviour
{
    public Text text;
    public Text feedbackText;
    public int state = 0;
    public int testDuration = 5*60;
    public bool forest;
    public Button but1;
    public Button but2;
    public Button but3;
    public Button but4;
    public Button but5;
    public Button but6;
    public Button but7;
    public Button but8;
    public Button but9;
    public Button but0;
    public avgTime avgTimer = new avgTime();
    public Slider timer;
    public Slider perfArrow;
    public Slider perfBar;
    public float sessioLeft;
    public VRTK_ControllerEvents rightCont;
    public VRTK_ControllerEvents leftCont;
    public string fileTextName;
    private string filePath;
    private string[] operations = new string[4];
    private string ops1;
    private string ops2;
    private string ops3;
    public string session;
    private bool interactableQuest = false;
    private int butSelect = 1;
    private int int1;
    private int int2;
    private int int3;
    private int int4;
    private int largeInt1;
    private int largeInt2;
    private int largeInt3;
    private int largeInt4;
    private int result;
    private int questAns;
    private int questRight = 0;
    private int questWrong = 0;
    private int questFailed = 0;
    private int curQuestRight = 0;
    private int curQuestWrong = 0;
    private int previous;
    private float sessionStart;
    private float sessionState;
    private float lastQuestAns;
    private float questionAnswerTime;
    private List<string> dif5Quest = new List<string>();
    private List<int> dif5Ans = new List<int>();
    private List<float> timeList = new List<float>();
    public float[] averageTime = new float[5];

    // Start is called before the first frame update
    void Start()
    {
        operations[0] = " + ";
        operations[1] = " - ";
        operations[2] = " * ";
        operations[3] = " / ";

        filePath = Application.dataPath + "/" + fileTextName + ".txt";

        dif5Quest.InsertRange(dif5Quest.Count, new string[] {   "0 + 41 * 12 / 82 ",    "26 - 33 / 33 * 19 ",   "6 + 0 / 79 * 26 ",     "52 / 26 + 0 * 66 ",    "5 - 0 / 68 * 63 ",

                                                                "49 * 85 / 85 - 48 ",   "85 - 68 / 68 * 78 ",   "5 - 0 / 20 * 64 ",     "0 + 43 / 86 * 18 ",     "84 * 99 / 84 - 94 ",

                                                                "74 - 74 * 84 / 84 ",   "66 * 46 / 66 - 45 ",   "87 * 0 / 74 + 8 ",     "4 - 69 / 63 * 0 ",     "3 + 0 / 91 * 12 ",

                                                                "3 + 80 / 80 * 0 ",     "69 / 46 * 18 - 20 ",   "0 / 76 - 0 * 76 ",     "7 * 20 / 14 - 6 ",     "42 - 19 * 20 / 10 ",

                                                                "75 * 79 / 75 - 74 ",   "48 - 43 * 87 / 87 ",   "42 - 62 * 19 / 31 ",   "33 / 33 * 11 - 3 ",    "84 * 90 / 72 - 96 ",

                                                                "26 - 18 * 33 / 33" ,   "92 - 88 / 25 * 25" ,   "98 - 98 / 72 * 72" ,   "8 + 0 / 39 * 42" ,     "3 + 9 * 32 / 72" ,

                                                                "8 + 0 / 3 * 30" ,      "1 - 0 * 48 / 85" ,     "98 * 78 / 84 - 89" ,   "38 - 22 * 90 / 55" ,   "9 + 0 * 52 / 39" ,

                                                                "28 * 0 + 39 / 39" ,    "0 / 16 * 92 + 1" ,     "8 + 0 * 24 / 60" ,     "30 * 25 / 75 - 4" ,    "54 / 27 * 38 - 72" ,

                                                                "11 / 22 * 84 - 40" ,   "4 * 35 / 20 - 0" ,     "8 - 15 * 0 / 51" ,     "5 - 73 * 0 / 19" ,     "4 - 21 / 69 * 0" ,

                                                                "7 + 66 / 10 * 0" ,     "7 + 90 * 0 / 30" ,     "0 * 65 + 84 / 21" ,    "27 - 25 / 21 * 21" ,   "55 - 56 / 56 * 54" ,

                                                                "20 * 4 / 40 + 6" ,     "0 * 43 + 7 / 1" ,      "21 - 72 / 72 * 13" ,   "72 * 18 / 48 - 19" ,   "3 + 0 / 58 * 87" ,

                                                                "38 * 25 / 50 - 12" ,   "2 + 34 * 0 / 1" ,      "0 + 95 * 0 / 22" ,     "51 * 28 / 51 - 22" ,   "1 + 12 * 60 / 90" ,

                                                                "88 / 82 * 82 - 79" ,   "3 / 3 - 34 * 0" ,      "31 / 62 * 50 - 23" ,   "91 * 6 / 91 + 2" ,     "48 - 96 / 66 * 33" ,

                                                                "4 + 0 * 13 / 36" ,     "16 - 39 * 19 / 57" ,   "84 / 44 * 22 - 41" ,   "2 + 9 * 23 / 69" ,     "38 / 62 * 62 - 37"});


        dif5Ans.InsertRange(dif5Ans.Count, new int[]        {   6,                      7,                      6,                      2,                      5,

                                                                1,                      7,                      5,                      9,                      5,

                                                                0,                      1,                      8,                      4,                      3,

                                                                3,                      7,                      0,                      4,                      4,

                                                                5,                      5,                      4,                      8,                      9,

                                                                8,                      4,                      0,                      8,                      7,

                                                                8,                      1,                      2,                      2,                      9,

                                                                1,                      1,                      8,                      6,                      4,

                                                                2,                      7,                      8,                      5,                      4,

                                                                7,                      7,                      4,                      2,                      1,

                                                                8,                      7,                      8,                      8,                      3,

                                                                7,                      2,                      0,                      6,                      9,

                                                                9,                      1,                      2,                      8,                      0,

                                                                4,                      3,                      1,                      5,                      1
        });

        SetupEvents();

        //GenerateMathProblem();

        ChangeSelectedBut();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.R))
        {
            butSelect = result;
            ChangeSelectedBut();
            answerQuestion2();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            butSelect = result + 1;
            answerQuestion2();
        }*/

        if (session == "start")
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (!File.Exists(filePath))
                {
                    File.Create(filePath);
                }
                else
                {
                    File.Copy(filePath, Application.dataPath + "/SafeCopyAsThisWasNotMoved" + System.DateTime.Now.Day + "-" + System.DateTime.Now.Month + " " + System.DateTime.Now.Hour + "." + System.DateTime.Now.Minute + ".txt");
                    File.Delete(filePath);
                    File.Create(filePath);
                }

                if(!File.Exists(Application.dataPath + "/Data.txt"))
                {
                    File.Create(Application.dataPath + "/Data.txt");
                }

                session = "train";
                sessionStart = Time.time;
                sessionState = sessionStart;
                Debug.Log("Starting the Training session");
                interactableQuest = true;
                GenerateMathProblem();
            }
        }

        else if (session == "train")
        {
            if (Time.time - sessionStart < testDuration)
            {
                sessioLeft = testDuration - (Time.time - sessionStart);

                //Check what state should be used
                if (Time.time - sessionState > testDuration / 5)
                {
                    float tempI = 0;
                    for (int i = 0; i < timeList.Count; i++)
                    {
                        tempI += timeList[i];
                    }
                    averageTime[state] = tempI / timeList.Count;
                    state++;
                    sessionState = Time.time;
                    timeList = new List<float>();
                }
            }
            else
            {
                float tempI = 0;
                for (int i = 0; i < timeList.Count; i++)
                {
                    tempI += timeList[i];
                }
                averageTime[state] = tempI / timeList.Count;
                timeList = new List<float>();

                

                session = "break1";
                GenerateMathProblem();
                state = 0;

                text.text = "Time for a break";

                Debug.Log("Training session has ended");
                interactableQuest = false;

                File.AppendAllText(Application.dataPath + "/Data.txt",  "Training Session " +
                                                                    "\nQuestion answered right: " + questRight + 
                                                                    "\nQuestion answered wrong: " + questWrong + 
                                                                    "\nAverage Times: " + averageTime[0] + ", " + averageTime[1] + ", " + averageTime[2] + ", " + averageTime[3] + ", " + averageTime[4] + 
                                                                    "\r\n\r\n\r\n");
            }

            //Testing purposes only
            if (Input.GetKeyDown(KeyCode.Space))
            {
                session = "break1";
                sessionStart = Time.time;
                sessionState = sessionStart;
                Debug.Log("Starting the Break session");
                GenerateMathProblem();
            }
        }

        else if (session == "break1")
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                interactableQuest = false;

                if (float.IsNaN(averageTime[0]))
                {
                    averageTime[0] = 4.0f;
                }
                
                if (float.IsNaN(averageTime[1]))
                {
                    averageTime[1] = 5.0f;
                }
                
                if (float.IsNaN(averageTime[2]))
                {
                    averageTime[2] = 6.0f;
                }
                
                if (float.IsNaN(averageTime[3]))
                {
                    averageTime[3] = 7.0f;
                }
                
                if (float.IsNaN(averageTime[4]))
                {
                    averageTime[4] = 8.0f;
                }

                avgTimer.avgTime0 = averageTime[0];
                avgTimer.avgTime1 = averageTime[1];
                avgTimer.avgTime2 = averageTime[2];
                avgTimer.avgTime3 = averageTime[3];
                avgTimer.avgTime4 = averageTime[4];
                

                if (questAns != 0)
                    avgTimer.avgComp = questRight / questAns;
                else
                {
                    Debug.Log("HOW DID YOU MANAGE TO NOT GET A SINGLE THING CORRECT");
                    avgTimer.avgComp = 0.8f;
                }
                    

                Debug.Log(averageTime[0] + ", " + averageTime[1] + ", " + averageTime[2] + ", " + averageTime[3] + ", " + averageTime[4]);

                string json = JsonUtility.ToJson(avgTimer);
                Debug.Log(json);

                using (StreamWriter streamWriter = File.CreateText(filePath))
                {
                    streamWriter.Write(json);
                }
                

                SceneManager.LoadScene(3);
            }
            if (Input.GetKeyDown(KeyCode.Return))
            {
                if (float.IsNaN(averageTime[0]))
                {
                    averageTime[0] = 4.0f;
                }

                if (float.IsNaN(averageTime[1]))
                {
                    averageTime[1] = 5.0f;
                }

                if (float.IsNaN(averageTime[2]))
                {
                    averageTime[2] = 6.0f;
                }

                if (float.IsNaN(averageTime[3]))
                {
                    averageTime[3] = 7.0f;
                }

                if (float.IsNaN(averageTime[4]))
                {
                    averageTime[4] = 8.0f;
                }

                avgTimer.avgTime0 = averageTime[0];
                avgTimer.avgTime1 = averageTime[1];
                avgTimer.avgTime2 = averageTime[2];
                avgTimer.avgTime3 = averageTime[3];
                avgTimer.avgTime4 = averageTime[4];

                interactableQuest = false;

                if (questAns != 0)
                    avgTimer.avgComp = questRight / questAns;
                else
                {
                    Debug.Log("HOW DID YOU MANAGE TO NOT GET A SINGLE THING CORRECT");
                    avgTimer.avgComp = 0.8f;
                }

                string json = JsonUtility.ToJson(avgTimer);

                using (StreamWriter streamWriter = File.CreateText(filePath))
                {
                    streamWriter.Write(json);
                }

                SceneManager.LoadScene(4);
            }
        }

        else if (session == "break")
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (File.Exists(filePath))
                {
                    using (StreamReader streamReader = File.OpenText(filePath))
                    {
                        string jsonString = streamReader.ReadToEnd();

                        avgTimer = JsonUtility.FromJson<avgTime>(jsonString);
                    }
                    if (avgTimer.avgTime0 == 0 || float.IsNaN(avgTimer.avgTime4))
                    {
                        averageTime[0] = 4;
                    }
                    else
                    {
                        averageTime[0] = avgTimer.avgTime0;
                    }

                    if (avgTimer.avgTime1 == 0 || float.IsNaN(avgTimer.avgTime4))
                    {
                        averageTime[1] = 6;
                    }
                    else
                    {
                        averageTime[1] = avgTimer.avgTime1;
                    }

                    if (avgTimer.avgTime2 == 0 || float.IsNaN(avgTimer.avgTime4))
                    {
                        averageTime[2] = 8;
                    }
                    else
                    {
                        averageTime[2] = avgTimer.avgTime2;
                    }

                    if (avgTimer.avgTime3 == 0 || float.IsNaN(avgTimer.avgTime4))
                    {
                        averageTime[3] = 9;
                    }
                    else
                    {
                        averageTime[3] = avgTimer.avgTime3;
                    }

                    if (avgTimer.avgTime4 == 0 || float.IsNaN(avgTimer.avgTime4))
                    {
                        averageTime[4] = 10;
                    }
                    else
                    {
                        averageTime[4] = avgTimer.avgTime4;
                    }

                    if(avgTimer.avgComp == 0)
                    {
                        perfBar.value = 0.85f;
                    }
                    else
                    {
                        perfBar.value = avgTimer.avgComp;
                    }
                }
                else
                {
                    averageTime[0] = 4;
                    averageTime[1] = 6;
                    averageTime[2] = 8;
                    averageTime[3] = 9;
                    averageTime[4] = 10;
                }
                

                session = "imaging";
                interactableQuest = true;
                sessionStart = Time.time;
                sessionState = sessionStart;
                Debug.Log("Imaging session has begun");
                GenerateMathProblem();
            }
        }

        else if (session == "imaging")
        {
            if (Time.time - sessionStart < testDuration)
            {
                sessioLeft = testDuration - (Time.time - sessionStart);

                if (Time.time - lastQuestAns > averageTime[state])
                {
                    GenerateMathProblem();
                    feedbackText.text = "Timeout!";
                    curQuestWrong++;
                    questFailed++;
                    questAns++;
                    if (curQuestWrong > 3)
                    {
                        averageTime[state] += averageTime[state] / 100 * 10;
                        curQuestWrong = 0;
                    }
                    perfArrow.value = (questRight + 0.0f) / (questAns + 0.0f);

                    lastQuestAns = Time.time;
                }
                else
                {
                    timer.value = (averageTime[state] - (Time.time - lastQuestAns)) / averageTime[state];
                }

                //Check what state should be used
                if (Time.time - sessionState > testDuration / 5)
                {
                    state++;
                    sessionState = Time.time;
                }
            }


            if (Time.time - sessionStart < testDuration)
            {
                sessioLeft = testDuration - (Time.time - sessionStart);

                //Check what state should be used
                if (Time.time - sessionState > testDuration / 5)
                {
                    float tempI = 0;
                    for (int i = 0; i < timeList.Count; i++)
                    {
                        tempI += timeList[i];
                    }
                    averageTime[state] = tempI / timeList.Count;
                    state++;
                    sessionState = Time.time;
                    timeList = new List<float>();
                }
            }
            else
            {
                float tempI = 0;
                for (int i = 0; i < timeList.Count; i++)
                {
                    tempI += timeList[i];
                }
                averageTime[state] = tempI / timeList.Count;
                timeList = new List<float>();

                text.text = "Time for a break";

                session = "break2";
                state = 0;
                Debug.Log("Imaging session has ended");
                interactableQuest = false;

                avgTimer.avgTime0 = averageTime[0];
                avgTimer.avgTime1 = averageTime[1];
                avgTimer.avgTime2 = averageTime[2];
                avgTimer.avgTime3 = averageTime[3];
                avgTimer.avgTime4 = averageTime[4];

                string json = JsonUtility.ToJson(avgTimer);

                using (StreamWriter streamWriter = File.CreateText(filePath))
                {
                    streamWriter.Write(json);
                }

                File.AppendAllText(Application.dataPath + "/Data.txt",  "Imaging Session " +
                                                                    "\nForest Scene: " + forest +
                                                                    "\nQuestions answered right: " + questRight +
                                                                    "\nQuestions answered wrong: " + questWrong +
                                                                    "\nQuestions not answered:   " + questFailed +
                                                                    "\nAverage Times: " + averageTime[0] + ", " + averageTime[1] + ", " + averageTime[2] + ", " + averageTime[3] + ", " + averageTime[4] +
                                                                    "\r\n\r\n\r\n");
            }
        }

        else if(session == "break2")
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (forest)
                {
                    SceneManager.LoadScene(4);
                }
                else
                {
                    SceneManager.LoadScene(3);
                }
            }
        }
    }

    void SetupEvents()
    {
        rightCont.TouchpadPressed += new ControllerInteractionEventHandler(rTouchPressed);
        leftCont.TouchpadPressed += new ControllerInteractionEventHandler(lTouchPressed);

        rightCont.TriggerClicked += new ControllerInteractionEventHandler(answerQuestion);
        leftCont.TriggerClicked += new ControllerInteractionEventHandler(answerQuestion);
    }

    public void rTouchPressed(object sender, ControllerInteractionEventArgs e)
    {
        //Debug.Log(rightCont.GetTouchpadAxisAngle() + "   |   " + rightCont.GetTouchpadAxis().x);
        if(rightCont.GetTouchpadAxisAngle() == 90)
        {
            if(previous == 0)
            {
                previous = 1;
                if (butSelect < 9)
                {
                    butSelect++;
                }
                else
                {
                    butSelect = 0;
                }
            }
            else
            {
                previous = 0;
                if (butSelect > 0)
                {
                    butSelect--;
                }
                else
                {
                    butSelect = 9;
                }
            }
        }

        else if (rightCont.GetTouchpadAxisAngle() < 180f)
            {
            //Debug.Log("TESTER");
            previous = 1;
                if (butSelect < 9)
                {
                    butSelect++;
                }
                else
                {
                    butSelect = 0;
                }
            }
        else
        {

            previous = 0;
            if (butSelect > 0)
            {
                butSelect--;
            }
            else
            {
                butSelect = 9;
            }
        }
        ChangeSelectedBut();
    }

    public void lTouchPressed(object sender, ControllerInteractionEventArgs e)
    {
        if (rightCont.GetTouchpadAxisAngle() == 90)
        {
            if (previous == 0)
            {
                previous = 1;
                if (butSelect < 9)
                {
                    butSelect++;
                }
                else
                {
                    butSelect = 0;
                }
            }
            else
            {
                previous = 0;
                if (butSelect > 0)
                {
                    butSelect--;
                }
                else
                {
                    butSelect = 9;
                }
            }
        }

        else if (leftCont.GetTouchpadAxisAngle() < 180f)
        {
            previous = 1;
            if (butSelect < 9)
            {
                butSelect++;
            }
            else
            {
                butSelect = 0;
            }
        }
        else
        {
            previous = 0;
            if (butSelect > 0)
            {
                butSelect--;
            }
            else
            {
                butSelect = 9;
            }
        }
        ChangeSelectedBut();
    }

    public void ChangeSelectedBut()
    {
        //Debug.Log("Start");
        switch (butSelect)
        {
            case 0:
                but0.Select();
                break;
            case 1:
                but1.Select();
                break;
            case 2:
                but2.Select();
                break;
            case 3:
                but3.Select();
                break;
            case 4:
                but4.Select();
                break;
            case 5:
                but5.Select();
                break;
            case 6:
                but6.Select();
                break;
            case 7:
                but7.Select();
                break;
            case 8:
                but8.Select();
                break;
            case 9:
                but9.Select();
                break;
        }
        //Debug.Log("End" + butSelect);
    }

    public void ChangeState(int tempState)
    {
        state = tempState;
    }

    public void answerQuestion(object sender, ControllerInteractionEventArgs e)
    {
        if (interactableQuest)
        {
            questionAnswerTime = Time.time - lastQuestAns;
            timeList.Add(questionAnswerTime);

            if (butSelect == result)
            {
                //You are correct
                questRight++;
                curQuestRight++;
                curQuestWrong = 0;
                questAns++;

                feedbackText.text = "Correct!";

                //Debug.Log("You are Right");
            }
            else
            {
                //You are wrong
                questWrong++;
                curQuestWrong++;
                curQuestRight = 0;
                questAns++;

                feedbackText.text = "False!";

                //Debug.Log("You are Wrong");
            }

            if (curQuestRight > 3)
            {
                averageTime[state] -= averageTime[state] / 100 * 10;
                curQuestRight = 0;
            }
            if (curQuestWrong > 3)
            {
                averageTime[state] += averageTime[state] / 100 * 10;
                curQuestWrong = 0;
            }

            GenerateMathProblem();

            if(session == "imaging")
            {
                perfArrow.value = (questRight + 0.0f) / (questAns + 0.0f);
            }
        }
    }

    public void GenerateMathProblem()
    {
        lastQuestAns = Time.time;

        if (state == 0)
        {
            result = Random.Range(0, 9);
            if(Random.value > 0.5f)     //addition
            {
                ops1 = " + ";
                int1 = Random.Range(0, result);
                int2 = result - int1;
            }
            else                        // subtraction
            {
                ops1 = " - ";
                int1 = Random.Range(result, 9);
                int2 = int1 - result;
            }

            text.text = int1 + ops1 + int2 + " = ?";
        }

        if (state == 1)
        {
            result = Random.Range(0, 9);
            if(Random.value > 0.5f)
            {
                ops1 = " + ";
                ops2 = " - ";
                result = Random.Range(0, 9);
                int1 = Random.Range(0, 9);

                if (result > int1)
                {
                    int2 = Random.Range((result - int1), 9);        // 
                }
                else
                {
                    int2 = Random.Range(0, (result + 9) - int1);
                }

                int3 = int1 + int2 - result;
            }
            else
            {
                ops1 = " - ";
                ops2 = " + ";
                result = Random.Range(0, 9);
                int1 = Random.Range(0, 9);

                if(result < int1)
                {
                    int2 = Random.Range((int1 - result), 9);
                }
                else
                {
                    int2 = Random.Range(0, (9 - result));
                }
                
                int3 = result + int2 - int1;      // int1 - int2 + int3 = result          int1 + int3 = result + int2       int3 = result + int2 - int1
            }

            text.text = int1 + ops1 + int2 + ops2 + int3 + " = ?" ;
        }

        if (state == 2)
        {
            ops1 = null;
            ops2 = null;
            ops3 = null;
            largeInt1 = 0;
            largeInt2 = 0;
            largeInt3 = 0;
            largeInt4 = 0;

            result = Random.Range(0, 9);

            //Randomize operations 
            ops1 = operations[Random.Range(0, 3)];
            ops2 = operations[Random.Range(0, 3)];

            while (ops2 == ops1)
            {
                ops2 = operations[Random.Range(0, 3)];
                Debug.Log("Test");
            }

            if (ops1 != " + " && ops2 != " + ")
            {
                ops3 = " + ";
            }
            else if (ops1 != " - " && ops2 != " - ")
            {
                ops3 = " - ";
            }
            else if (ops1 != " * " && ops2 != " * ")
            {
                ops3 = " * ";
            }

            //Two integers between 0-99
            if (Random.value > 0.5)          //two integers are between 0-99
            {
                float i = Random.value;

                if(i < 0.33)
                {
                    int1 = Random.Range(10, 99);
                    int2 = Random.Range(10, 99);
                    int3 = Random.Range(0, 9);
                    largeInt1 = 99;
                    largeInt2 = 99;
                }
                else if (i > 0.66)
                {
                    int1 = Random.Range(10, 99);
                    int2 = Random.Range(0, 9);
                    int3 = Random.Range(10, 99);
                    largeInt1 = 99;
                    largeInt3 = 99;
                }
                else
                {
                    int1 = Random.Range(0, 9);
                    int2 = Random.Range(10, 99);
                    int3 = Random.Range(10, 99);
                    largeInt2 = 99;
                    largeInt3 = 99;
                }
            }

            //One integer between 0-99
            else                            //only one
            {
                float i = Random.value;

                if (i < 0.33)
                {
                    int1 = Random.Range(10, 99);
                    int2 = Random.Range(0, 9);
                    int3 = Random.Range(0, 9);
                    largeInt1 = 99;
                }
                else if (i > 0.66)
                {
                    int1 = Random.Range(0, 9);
                    int2 = Random.Range(10, 99);
                    int3 = Random.Range(0, 9);
                    largeInt2 = 99;
                }
                else
                {
                    int1 = Random.Range(0, 9);
                    int2 = Random.Range(0, 9);
                    int3 = Random.Range(10, 99);
                    largeInt3 = 99;
                }
            }

            if(ops1 == " * ")
            {
                if(int1 * int2 < result + 99)
                {
                    int3 = (result - (int1 * int2));
                    if(int3 < 0)
                    {
                        int3 *= -1;
                        ops2 = " - ";
                    }
                    else
                    {
                        ops2 = " + ";
                    }
                }
                else
                {
                    GenerateMathProblem();
                }
            }
            else if(ops2 == " * ")
            {
                if (int2 * int3 < result + 99)
                {
                    if (ops1 == " + ")
                        int1 = result - (int2 * int3);
                    else
                        int1 = result + (int2 * int3);




                    /*int1 = (result - (int2 * int3));
                    if (int3 < 0)
                    {
                        int3 *= -1;
                        ops1 = " - ";
                    }*/
                }
                else
                {
                    GenerateMathProblem();
                }
            }
            else
            {
                if(ops1 == " + ")
                {
                    if(int1 + int2 > result + 99)
                    {
                        int3 = (result - (int1 + int2)) *-1; 
                    }
                    else
                    {
                        GenerateMathProblem();
                    }
                }
                else
                {
                    if(int1 - int2 < result - 99)
                    {
                        int3 = result + (int1 - int2);
                    }
                    else
                    {
                        GenerateMathProblem();
                    }
                }
            }
            


            text.text = int1 + ops1 + int2 + ops2 + int3 + " = ?";

        }

        if (state == 3)
        {
            ops1 = null;
            ops2 = null;
            ops3 = null;

            result = Random.Range(0, 9);

            //Randomize operations 
            ops1 = operations[Random.Range(0, 3)];

            ops2 = operations[Random.Range(0, 3)];

            while (ops2 == ops1)
            {
                ops2 = operations[Random.Range(0, 3)];
            }

            if (ops1 != " + " && ops2 != " + ")
            {
                ops3 = " + ";
            }
            else if (ops1 != " - " && ops2 != " - ")
            {
                ops3 = " - ";
            }
            else if (ops1 != " * " && ops2 != " * ")
            {
                ops3 = " * ";
            }

            //Two integers between 0-99
            if (Random.value > 0.5)          //two integers are between 0-99
            {
                float i = Random.value;
                float x = Random.value;

                if (i < 0.33)
                {
                    if(x > 0.5f)
                    {
                        int1 = Random.Range(0, 100);
                        int2 = Random.Range(0, 100);
                        int3 = Random.Range(0, 10);
                        int4 = Random.Range(0, 10);
                        largeInt1 = 99;
                        largeInt2 = 99;
                        largeInt3 = 9;
                        largeInt4 = 9;
                    }
                    else
                    {
                        int1 = Random.Range(0, 100);
                        int2 = Random.Range(0, 10);
                        int3 = Random.Range(0, 100);
                        int4 = Random.Range(0, 10);
                        largeInt1 = 99;
                        largeInt2 = 9;
                        largeInt3 = 99;
                        largeInt4 = 9;
                    }
                    
                }
                else if (i > 0.66)
                {
                    if(x > 0.5f)
                    {
                        int1 = Random.Range(0, 100);
                        int2 = Random.Range(0, 10);
                        int3 = Random.Range(0, 10);
                        int4 = Random.Range(0, 100);
                        largeInt1 = 99;
                        largeInt2 = 9;
                        largeInt3 = 9;
                        largeInt4 = 99;
                    }
                    else
                    {
                        int1 = Random.Range(0, 10);
                        int2 = Random.Range(0, 100);
                        int3 = Random.Range(0, 100);
                        int4 = Random.Range(0, 10);
                        largeInt1 = 9;
                        largeInt2 = 99;
                        largeInt3 = 99;
                        largeInt4 = 9;
                    }
                }
                else
                {
                    if (x > 0.5f)
                    {
                        int1 = Random.Range(0, 10);
                        int2 = Random.Range(0, 100);
                        int3 = Random.Range(0, 10);
                        int4 = Random.Range(0, 100);
                        largeInt1 = 9;
                        largeInt2 = 99;
                        largeInt3 = 9;
                        largeInt4 = 99;
                    }
                    else
                    {
                        int1 = Random.Range(0, 10);
                        int2 = Random.Range(0, 10);
                        int3 = Random.Range(0, 100);
                        int4 = Random.Range(0, 100);
                        largeInt1 = 9;
                        largeInt2 = 9;
                        largeInt3 = 99;
                        largeInt4 = 99;
                    }
                }
            }

            //One integer between 0-99
            else                            //only one
            {
                float i = Random.value;

                if (i < 0.25)
                {
                    int1 = Random.Range(0, 100);
                    int2 = Random.Range(0, 10);
                    int3 = Random.Range(0, 10);
                    int4 = Random.Range(0, 10);
                    largeInt1 = 99;
                    largeInt2 = 9;
                    largeInt3 = 9;
                    largeInt4 = 9;
                }
                else if (i < 0.50)
                {
                    int1 = Random.Range(0, 10);
                    int2 = Random.Range(0, 100);
                    int3 = Random.Range(0, 10);
                    int4 = Random.Range(0, 10);
                    largeInt1 = 9;
                    largeInt2 = 99;
                    largeInt3 = 9;
                    largeInt4 = 9;
                }
                else if (i  < 0.75)
                {
                    int1 = Random.Range(0, 10);
                    int2 = Random.Range(0, 10);
                    int3 = Random.Range(0, 100);
                    int4 = Random.Range(0, 10);
                    largeInt1 = 9;
                    largeInt2 = 9;
                    largeInt3 = 99;
                    largeInt4 = 9;
                }
                else
                {
                    int1 = Random.Range(0, 10);
                    int2 = Random.Range(0, 10);
                    int3 = Random.Range(0, 10);
                    int4 = Random.Range(0, 100);
                    largeInt1 = 9;
                    largeInt2 = 9;
                    largeInt3 = 9;
                    largeInt4 = 99;
                }
            }

            if (ops1 == " * ")   // a * b + c - d    ||      a * b - c + d
            {
                if(ops2 == " + ")
                {
                    if (int1 * int2 < result + largeInt3) //int1 * int2 MAX= result + 99
                    {
                        //int3 = Random.Range(result, result + largeInt3);

                        int3 = Random.Range(0, (result + largeInt3) - (int1 * int2)); //a*b+c = result + largeInt3       

                        int4 = int1 * int2 + int3 - result;        //int1 * int2 + int3 - int4 = results
                    }
                    else
                    {
                        GenerateMathProblem();
                    }
                }
                else
                {


                    if (int1 * int2 - largeInt3 < result)    // a * b max=                  a * b - c + d = result  a * b + c = result    | result - a *b
                    {
                        int3 = Random.Range((result - int1 * int2), (result - int1 * int2) + largeInt4);

                        int4 = result - (int1 * int2 - int3);  // a * b - c + d = result
                    }
                    else
                    {
                        GenerateMathProblem();
                    }
                }
            }

            else if (ops2 == " * ")  // a + b * c - d   || a - b * c + d
            {
                if (ops1 == " + ")
                {
                    if (int2 * int3 < result + largeInt1) //int1 + int2 * int3 MAX= result + 99
                    {
                        int1 = Random.Range(0, (result + largeInt1) - (int2 * int3)); //a + b*c = result + largeInt1       

                        int4 = int1 + int2 * int3 - result;        //int1 + int2 * int3 - int4 = results
                    }
                    else
                    {
                        GenerateMathProblem();
                    }
                }
                else
                {
                    if (int2 * int3 - largeInt1 < result)    // a * b max=                  a * b - c + d = result  a * b + c = result    | result - a *b
                    {
                        int1 = Random.Range((result - int2 * int3), (result - int2 * int3) + largeInt1);

                        int4 = result - (int1 - int2 * int3);  // a - b * c + d = result
                    }
                    else
                    {
                        GenerateMathProblem();
                    }
                }
            }

            else if (ops3 == " * ") // a + b - c * d   || a - b + c * d
            {
                if (ops1 == " + ")
                {
                    if (int3 * int4 < result + largeInt1) //
                    {
                        int1 = Random.Range(0, (result + largeInt1) - (int3 * int4)); //  

                        int2 = result - int3 * int4 - int1;        //a + b - c * d = result
                    }
                    else
                    {
                        GenerateMathProblem();
                    }
                }
                else
                {
                    if (int3 * int4 - largeInt1 < result)    // 
                    {
                        int1 = Random.Range((result - int3 * int4), (result - int3 * int4) + largeInt1);

                        int2 = int1 - result + int3 * int4;  // a - b + c * d = result
                    }
                    else
                    {
                        GenerateMathProblem();
                    }
                }
            }

            if(int1 < 0 || int2 < 0 || int3 < 0 || int4 < 0)
            {
                GenerateMathProblem();
            }

            text.text = int1 + ops1 + int2 + ops2 + int3 + ops3 + int4 + " = ?";
            

        }

        if (state == 4)
        {
            int i = Random.Range(0, dif5Quest.Count);

            if(dif5Quest.Count > 0)
            {
                result = dif5Ans[i];
                text.text = dif5Quest[i] + " = ?";

                dif5Ans.RemoveAt(i);
                dif5Quest.RemoveAt(i);

                Debug.Log(dif5Quest.Count);
            }
            else
            {

                //Debug.Log(dif5Quest[dif5Quest.Count]);
                Debug.Log("No more questions");

                dif5Quest.InsertRange(dif5Quest.Count, new string[] {   "0 + 41 * 12 / 82 ",    "26 - 33 / 33 * 19 ",   "6 + 0 / 79 * 26 ",     "52 / 26 + 0 * 66 ",    "5 - 0 / 68 * 63 ",

                                                                "49 * 85 / 85 - 48 ",   "85 - 68 / 68 * 78 ",   "5 - 0 / 20 * 64 ",     "0 + 43 / 86 * 18 ",     "84 * 99 / 84 - 94 ",

                                                                "74 - 74 * 84 / 84 ",   "66 * 46 / 66 - 45 ",   "87 * 0 / 74 + 8 ",     "4 - 69 / 63 * 0 ",     "3 + 0 / 91 * 12 ",

                                                                "3 + 80 / 80 * 0 ",     "69 / 46 * 18 - 20 ",   "0 / 76 - 0 * 76 ",     "7 * 20 / 14 - 6 ",     "42 - 19 * 20 / 10 ",

                                                                "75 * 79 / 75 - 74 ",   "48 - 43 * 87 / 87 ",   "42 - 62 * 19 / 31 ",   "33 / 33 * 11 - 3 ",    "84 * 90 / 72 - 96 ",

                                                                "26 - 18 * 33 / 33" ,   "92 - 88 / 25 * 25" ,   "98 - 98 / 72 * 72" ,   "8 + 0 / 39 * 42" ,     "3 + 9 * 32 / 72" ,

                                                                "8 + 0 / 3 * 30" ,      "1 - 0 * 48 / 85" ,     "98 * 78 / 84 - 89" ,   "38 - 22 * 90 / 55" ,   "9 + 0 * 52 / 39" ,

                                                                "28 * 0 + 39 / 39" ,    "0 / 16 * 92 + 1" ,     "8 + 0 * 24 / 60" ,     "30 * 25 / 75 - 4" ,    "54 / 27 * 38 - 72" ,

                                                                "11 / 22 * 84 - 40" ,   "4 * 35 / 20 - 0" ,     "8 - 15 * 0 / 51" ,     "5 - 73 * 0 / 19" ,     "4 - 21 / 69 * 0" ,

                                                                "7 + 66 / 10 * 0" ,     "7 + 90 * 0 / 30" ,     "0 * 65 + 84 / 21" ,    "27 - 25 / 21 * 21" ,   "55 - 56 / 56 * 54" ,

                                                                "20 * 4 / 40 + 6" ,     "0 * 43 + 7 / 1" ,      "21 - 72 / 72 * 13" ,   "72 * 18 / 48 - 19" ,   "3 + 0 / 58 * 87" ,

                                                                "38 * 25 / 50 - 12" ,   "2 + 34 * 0 / 1" ,      "0 + 95 * 0 / 22" ,     "51 * 28 / 51 - 22" ,   "1 + 12 * 60 / 90" ,

                                                                "88 / 82 * 82 - 79" ,   "3 / 3 - 34 * 0" ,      "31 / 62 * 50 - 23" ,   "91 * 6 / 91 + 2" ,     "48 - 96 / 66 * 33" ,

                                                                "4 + 0 * 13 / 36" ,     "16 - 39 * 19 / 57" ,   "84 / 44 * 22 - 41" ,   "2 + 9 * 23 / 69" ,     "38 / 62 * 62 - 37"});


                dif5Ans.InsertRange(dif5Ans.Count, new int[]{   6,                      7,                      6,                      2,                      5,

                                                                1,                      7,                      5,                      9,                      5,

                                                                0,                      1,                      8,                      4,                      3,

                                                                3,                      7,                      0,                      4,                      4,

                                                                5,                      5,                      4,                      8,                      9,

                                                                8,                      4,                      0,                      8,                      7,

                                                                8,                      1,                      2,                      2,                      9,

                                                                1,                      1,                      8,                      6,                      4,

                                                                2,                      7,                      8,                      5,                      4,

                                                                7,                      7,                      4,                      2,                      1,

                                                                8,                      7,                      8,                      8,                      3,

                                                                7,                      2,                      0,                      6,                      9,

                                                                9,                      1,                      2,                      8,                      0,

                                                                4,                      3,                      1,                      5,                      1
        });

                GenerateMathProblem();
            }
        }
    }

    [System.Serializable]
    public class avgTime
    {
        public float avgTime0;
        public float avgTime1;
        public float avgTime2;
        public float avgTime3;
        public float avgTime4;
        public float avgComp;
    }



    public void answerQuestion2()
    {
        if (interactableQuest)
        {
            questionAnswerTime = Time.time - lastQuestAns;
            timeList.Add(questionAnswerTime);

            if (butSelect == result)
            {
                //You are correct
                questRight++;
                curQuestRight++;
                curQuestWrong = 0;
                questAns++;

                feedbackText.text = "Correct!";

                //Debug.Log("You are Right");
            }
            else
            {
                //You are wrong
                questWrong++;
                curQuestWrong++;
                curQuestRight = 0;
                questAns++;

                feedbackText.text = "False!";

                //Debug.Log("You are Wrong");
            }

            if (curQuestRight > 3)
            {
                averageTime[state] -= averageTime[state] / 100 * 10;
                curQuestRight = 0;
            }
            if (curQuestWrong > 3)
            {
                averageTime[state] += averageTime[state] / 100 * 10;
                curQuestWrong = 0;
            }

            GenerateMathProblem();

            if (session == "imaging")
            {
                perfArrow.value = (questRight + 0.0f) / (questAns + 0.0f);
            }
        }
    }
}


