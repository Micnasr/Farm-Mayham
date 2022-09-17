using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
   
    public Text text;

    float minutes = 3f;
    float seconds = 59f;

    public GameObject gameend;
    public GameObject EndScreen;
    void Start()
    {
        
    }

   
    void Update()
    {
        seconds = seconds - 1 * Time.deltaTime;

        float second = Mathf.Ceil(seconds);

        if (gameend.transform.tag != "gameend")
        {
            if (seconds <= 9)
            {
                text.text = minutes + ":0" + second.ToString();
            }
            else
            {
                text.text = minutes + ":" + second.ToString();
            }

            if (seconds <= -1)
            {
                minutes--;
                seconds = 59f;


            }

        }

        if (minutes == 0 && second == 0)
        {
            gameend.transform.tag = "gameend";
            text.text = "0:00";
            EndScreen.SetActive(true);

            
        }
    }
}
