using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateGPSText : MonoBehaviour
{
    // Update is called once per frame
    public Text coordinates;
    void Update()
    {
        coordinates = GetComponentInChildren<Text>();
        coordinates.text = "latitude = " + GPSLocation.Instance.latitude.ToString() + " longitude = " + GPSLocation.Instance.latitude.ToString();
    }
}
