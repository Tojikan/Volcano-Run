﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Class that handles the autoscroll feature of the game
//Add all BG sections as a child of this game object. This scrolls any children object
public class AutoScroll : MonoBehaviour
{
    public float scrollSpeed = 5.0f;                    //Set the speed at which the map scrolls up
    public bool scrollEnabled;                          //simple bool check to control movement
    public PlayerController player;                     //drag a reference to our player object

    private void Start()
    {
        //initialize to true
        scrollEnabled = true;
    }


    // Update is called once per frame
    void Update ()
    {
        //if we're allowed to scroll, scroll
        if (scrollEnabled)
        {
            MoveSections();
        }
	}

    //iterate over all sections to scroll up
    void MoveSections()
    {
        foreach (Transform mapSection in transform)
        {
            mapSection.Translate(Vector3.up * Time.deltaTime * scrollSpeed);
        }
    }

    //disable scroll
    public void StopScroll()
    {
        scrollEnabled = false;
    }

    //enable scroll
    public void StartScroll()
    {
        scrollEnabled = true;
    }
}