using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManagement : MonoBehaviour
{
    [SerializeField] private List<Material> skyboxes;
    [SerializeField] private Text timeDisplay;

    private float dayLength = 24f; //in hours
    private float hourLength = 60f;
    private float startingTime = 0f; //military time

    private float currentHours;
    private float currentMinutes;
    private float timeProgressFactor = 1f; //how many IRL seconds ingame (in seconds)

    // Start is called before the first frame update
    void Start()
    {
        currentHours = startingTime;
        currentMinutes = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentMinutes = currentMinutes + Time.deltaTime * timeProgressFactor;

        if (currentMinutes >= hourLength)
        {
            currentMinutes = startingTime;
            currentHours = (currentHours + 1f) % dayLength;
        }

        timeDisplay.text = currentHours.ToString("F0").PadLeft(2, '0') + " : " + currentMinutes.ToString("F0").PadLeft(2, '0');

        switch (currentHours)
        {
            case >= 0 and < 6 or >= 20 and < 24:
                
                RenderSettings.skybox = skyboxes[0];
                break;
            case >= 6 and < 10:
                
                RenderSettings.skybox = skyboxes[1];
                break;
            case >= 10 and < 17 :
                
                RenderSettings.skybox = skyboxes[2];
                break;
            case >= 17 and < 20:
                
                RenderSettings.skybox = skyboxes[3];
                break;


        }
    }

    public void SpeedTime(float multiplier)
    {
        print("change time by: " + multiplier);
        Time.timeScale = multiplier;
    }

}
