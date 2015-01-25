﻿using UnityEngine;
using System.Collections;

public class Hunger : MonoBehaviour {

    /// <summary>
    /// The time (in seconds) for the hunger count to increase.
    /// </summary>
    public float interval;
    
    /// <summary>
    /// The amount by which hunger increases per auto-increment interval.
    /// </summary>
    public float increasePerInterval;

    /// <summary>
    /// The current world hunger level.
    /// </summary>
    public float hunger = 0;
    public string failState;
    public bool fading;


    // Time until the next auto-increment
    private float timeToIncrease = 0;

	// Use this for initialization
	void Start () {
        fading = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (!fading)
        {
			timeToIncrease += Time.deltaTime;
			if (timeToIncrease >= interval)
			{
				hunger += increasePerInterval;
				timeToIncrease = 0;
			}     
		
            if (hunger < 100)
                hunger += 0.05f;

            if (hunger >= 100)
            {
                CameraFader fade = GameObject.Find("Main Camera").GetComponent<CameraFader>();

                if (fade != null)
                {
                    fading = true;
                    fade.FadeOut(FailGame);
                }
                else
                {
                    Debug.LogWarning("CameraFader not found");
                }
            }
        }
	}

    void FailGame()
    {
        Application.LoadLevel(failState); 
	}

    /// <summary>
    /// Resets the hunger's auto-increment timer.
    /// </summary>
    public void resetHungerTimer()
    {
        timeToIncrease = 0;
    }

    // Undocumented thing
    void OnValidate()
    {
        interval = Mathf.Clamp(interval, 0.5f, 20);
        increasePerInterval = Mathf.Clamp(increasePerInterval, 1, 15);
        hunger = Mathf.Clamp(hunger, 0, 100);
    }

    /// <summary>
    /// Gets the amount of time (in milliseconds) until the hunger meter will auto-increment.
    /// </summary>
    /// <returns>Time in millisconds to the next increase.</returns>
    public float getTimeToIncrease()
    {
        return timeToIncrease;
    }
}
