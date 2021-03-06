﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**Timer script that counts time for obstacles to trigger themselves
    Starts a coroutine that increments a variable by 1 each interval
    Subscribe all obstacles to the ObsTimer event so there is only one timer for all obstacles
 **/
public class ObstacleTimer : MonoBehaviour
{
    private int time;                                   //time variable
    const int maxTime = 1000;                           //max value timer reaches before going back to 0
    const float timerInterval = 0.01f;                  //time interval between coroutine loops 

    public delegate void ObsTimer(int eventTimer);
    public static event ObsTimer ObsTimerEvent;


    // Use this for initialization
    void Start()
    {
        time = 0;
    }

    //Start timer
    public void StartTimer()
    {
        StartCoroutine("TimerRoutine");
    }

    //Stop timer
    public void StopTimer()
    {
        StopAllCoroutines();
    }

    //Reset Timer
    public void ResetTimer()
    {
        time = 0;
    }

    //Timer Coroutine
    IEnumerator TimerRoutine()
    {
        //Continuous loop
        while (true)
        {
            //Wait for one millisecond
            yield return new WaitForSeconds(timerInterval);

            //Increment our timer by 1.
            time += 1;

            //reset time if we've reached maxtime
            if (time > maxTime)
            {
                ResetTimer();
            }
            //Call our delegate to trigger any assigned events, if any
            if (ObsTimerEvent != null)
                ObsTimerEvent(time);
        }
    }

    void OnDisable()
    {
        StopTimer();
    }
}
