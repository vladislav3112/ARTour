using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Android;
using System;

public class DistanceFromGeotag : MonoBehaviour
{
    public static DistanceFromGeotag Instance { set; get; }
    public double distance;
    private Text TextDistance;
    private double start_latitude, start_longtitude;//set in from other script later
    private double curr_latitude, curr_longtitude;
    private bool isAudioDownloading = false;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        Instance = this;
        InvokeRepeating("UpdateDistance", 0, 5);
        InvokeRepeating("CheckDistance", 1, 5);
        //StartCoroutine(Camera.main.GetComponent<MusicHandler>().PlayAndDeleteAudio(distance));
    }

    private void CheckDistance()
    {

        if (distance < 10000 && !isAudioDownloading)
        {
            isAudioDownloading = true;
            StartCoroutine(Camera.main.GetComponent<MusicHandler>().PlayAndDeleteAudio(distance));
        }
    }
    private void UpdateDistance()
    {
        TextDistance = GetComponentInChildren<Text>();
        //hardcoded start point for a test
        start_latitude = 59.874729;
        start_longtitude = 29.8298377;
        
        curr_latitude = GPSLocation.Instance.latitude;
        curr_longtitude = GPSLocation.Instance.longitude;

        //calculate distance from start point:
        double lat_diff = Math.Abs(start_latitude - curr_latitude);
        double long_diff = Math.Abs(start_longtitude - curr_longtitude);
        double a = Math.Sin(lat_diff / 2) * Math.Sin(lat_diff / 2) +
            Math.Cos(curr_latitude) * Math.Cos(start_latitude) * Math.Sin(long_diff / 2) * Math.Sin(long_diff / 2);

        double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
        distance = c * 63170;   //distance in meters


        TextDistance.text = "distance = " + distance.ToString("0.0");

        
    }
}
