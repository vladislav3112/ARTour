using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Android;
using System;

public class GPSLocation : MonoBehaviour
{
    public static GPSLocation Instance { set; get; }

    public double latitude, longitude;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
        StartCoroutine(GPSTracking());
    }
        

    private IEnumerator GPSTracking()
    {
        Permission.RequestUserPermission(Permission.FineLocation);
        if (!Input.location.isEnabledByUser) System.Environment.Exit(0);//GPS tured off

        Input.location.Start();

        int maxwait = 20;
        while(Input.location.status == LocationServiceStatus.Initializing && maxwait > 0)
        {
            yield return new WaitForSeconds(2);
            maxwait--;
        }
        if (maxwait <= 0)
        {
            Debug.Log("Timed out");
            yield break;
        }
        while (Input.location.status == LocationServiceStatus.Failed && maxwait > 0)
        {
            Debug.Log("Unable to determine location");
            yield break;
        }
        latitude = Input.location.lastData.latitude;
        longitude = Input.location.lastData.longitude;


    }

}
