using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MathProgram : MonoBehaviour
{
    public Text text;
    public int state = 0;
    public int testDuration = 5*60;
    private string[] operations = new string[4];
    private string ops1;
    private string ops2;
    private string ops3;
    private int int1;
    private int int2;
    private int int3;
    private int int4;
    private bool largeInt1;
    private bool largeInt2;
    private bool largeInt3;
    private bool largeInt4;
    private int result;

    // Start is called before the first frame update
    void Start()
    {
        operations[0] = " + ";
        operations[1] = " - ";
        operations[2] = " * ";
        operations[3] = " / ";


        GenerateMathProblem();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            if(result == 0)
            {
                Debug.Log("YOU ARE RIGHT");
            }
            else
            {
                Debug.Log("YOU ARE WRONG!!!");
            }
            GenerateMathProblem();
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (result == 1)
            {
                Debug.Log("YOU ARE RIGHT");
            }
            else
            {
                Debug.Log("YOU ARE WRONG!!!");
            }
            GenerateMathProblem();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (result == 2)
            {
                Debug.Log("YOU ARE RIGHT");
            }
            else
            {
                Debug.Log("YOU ARE WRONG!!!");
            }
            GenerateMathProblem();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (result == 3)
            {
                Debug.Log("YOU ARE RIGHT");
            }
            else
            {
                Debug.Log("YOU ARE WRONG!!!");
            }
            GenerateMathProblem();
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (result == 4)
            {
                Debug.Log("YOU ARE RIGHT");
            }
            else
            {
                Debug.Log("YOU ARE WRONG!!!");
            }
            GenerateMathProblem();
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            if (result == 5)
            {
                Debug.Log("YOU ARE RIGHT");
            }
            else
            {
                Debug.Log("YOU ARE WRONG!!!");
            }
            GenerateMathProblem();
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            if (result == 6)
            {
                Debug.Log("YOU ARE RIGHT");
            }
            else
            {
                Debug.Log("YOU ARE WRONG!!!");
            }
            GenerateMathProblem();
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            if (result == 7)
            {
                Debug.Log("YOU ARE RIGHT");
            }
            else
            {
                Debug.Log("YOU ARE WRONG!!!");
            }
            GenerateMathProblem();
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            if (result == 8)
            {
                Debug.Log("YOU ARE RIGHT");
            }
            else
            {
                Debug.Log("YOU ARE WRONG!!!");
            }
            GenerateMathProblem();
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            if (result == 9)
            {
                Debug.Log("YOU ARE RIGHT");
            }
            else
            {
                Debug.Log("YOU ARE WRONG!!!");
            }
            GenerateMathProblem();
        }
    }

    public void GenerateMathProblem()
    {
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

            text.text = int1 + ops1 + int2 + "              ///" + result;
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

            text.text = int1 + ops1 + int2 + ops2 + int3 + "              ///" + result;
        }

        if (state == 2)
        {
            ops1 = null;
            ops2 = null;
            ops3 = null;
            largeInt1 = false;
            largeInt2 = false;
            largeInt3 = false;
            largeInt4 = false;

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
                    largeInt1 = true;
                    largeInt2 = true;
                }
                else if (i > 0.66)
                {
                    int1 = Random.Range(10, 99);
                    int2 = Random.Range(0, 9);
                    int3 = Random.Range(10, 99);
                    largeInt1 = true;
                    largeInt3 = true;
                }
                else
                {
                    int1 = Random.Range(0, 9);
                    int2 = Random.Range(10, 99);
                    int3 = Random.Range(10, 99);
                    largeInt2 = true;
                    largeInt3 = true;
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
                    largeInt1 = true;
                }
                else if (i > 0.66)
                {
                    int1 = Random.Range(0, 9);
                    int2 = Random.Range(10, 99);
                    int3 = Random.Range(0, 9);
                    largeInt2 = true;
                }
                else
                {
                    int1 = Random.Range(0, 9);
                    int2 = Random.Range(0, 9);
                    int3 = Random.Range(10, 99);
                    largeInt3 = true;
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
                    if (ops2 == " + ")
                        int1 = result - (int2 * int2);
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
            


            text.text = int1 + ops1 + int2 + ops2 + int3 + " =                    /// " + result;

        }

        if (state == 3)
        {
            ops1 = null;
            ops2 = null;
            ops3 = null;

            result = Random.Range(0, 9);

            int1 = Random.Range(0, 99);

            //Randomize operations 
            ops1 = operations[Random.Range(0, 2)];
            while (ops2 != ops1)
            {
                ops2 = operations[Random.Range(0, 2)];
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

                if (i < 0.33)
                {
                    int1 = Random.Range(0, 99);
                    int2 = Random.Range(0, 99);
                    int3 = Random.Range(0, 9);
                }
                else if (i > 0.66)
                {
                    int1 = Random.Range(0, 99);
                    int2 = Random.Range(0, 9);
                    int3 = Random.Range(0, 99);
                }
                else
                {
                    int1 = Random.Range(0, 9);
                    int2 = Random.Range(0, 99);
                    int3 = Random.Range(0, 99);
                }
            }

            //One integer between 0-99
            else                            //only one
            {
                float i = Random.value;

                if (i < 0.33)
                {
                    int1 = Random.Range(0, 99);
                    int2 = Random.Range(0, 9);
                    int3 = Random.Range(0, 9);
                }
                else if (i > 0.66)
                {
                    int1 = Random.Range(0, 9);
                    int2 = Random.Range(0, 99);
                    int3 = Random.Range(0, 9);
                }
                else
                {
                    int1 = Random.Range(0, 9);
                    int2 = Random.Range(0, 9);
                    int3 = Random.Range(0, 99);
                }
            }

        }

        if (state == 4)
        {

        }
    }
}
