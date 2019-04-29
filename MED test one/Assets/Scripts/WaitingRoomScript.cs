using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaitingRoomScript : MonoBehaviour
{
    public bool forest;
    public float timeInSeconds;
    public float timeInMinutes;
    public float waitTimeInSeconds;
    private float startTime;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        timeInSeconds = Time.time - startTime;
        timeInMinutes = timeInSeconds / 60;

        if(Time.time - startTime > waitTimeInSeconds)
        {
            if (forest)
            {
                SceneManager.LoadScene(1);
            }
            else
            {
                SceneManager.LoadScene(2);
            }
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (forest)
            {
                SceneManager.LoadScene(1);
            }
            else
            {
                SceneManager.LoadScene(2);
            }
        }
    }
}
