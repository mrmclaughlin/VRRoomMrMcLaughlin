using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class sunTime : MonoBehaviour
{
	
	public float latitude = 40.7128f;  // Latitude of the location (for example, New York)
    public float longitude = -74.0060f; // Longitude of the location (for example, New York)
    public float fullDayLength = 1440f; // Length of the day in minutes, 1440 minutes in a 24-hour day
    public float sunInitialRotation = 90f; // Initial angle of the sun above the horizon at 12:00 AM

	
	
	
public GameObject sunAngle;
    // Start is called before the first frame update
    void Start()
    {
         // Initialize sun position based on current time
        DateTime currentTime = DateTime.Now.ToUniversalTime();
        float minutesPassed = (float)(currentTime - DateTime.Today.ToUniversalTime()).TotalMinutes;
        float rotationAmount = (minutesPassed / fullDayLength) * 360f; // 360 degrees in a full rotation
        rotationAmount += sunInitialRotation; // Add initial offset

        // Correct for timezone and longitude
        float timezoneCorrection = (4 - (longitude / 15)); // EST timezone offset is 4
        rotationAmount += timezoneCorrection * (360f / 24f); // 360 degrees in a full rotation, 24 hours in a day

        // Apply the rotation
        transform.eulerAngles = new Vector3(rotationAmount, 0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        updateSunAngle();
    }
    void updateSunAngle()
    {
    float rotationSpeed = 360f / fullDayLength * Time.deltaTime; // Time.deltaTime is the time passed since the last frame
    sunAngle.transform.Rotate(new Vector3(rotationSpeed, 0f, 0f));
    }
}
