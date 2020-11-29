using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
public class ImageRecognition : MonoBehaviour
{
    private ARTrackedImageManager aRTrackedImageManager;

    private void Awake()
    {
        aRTrackedImageManager = FindObjectOfType<ARTrackedImageManager>();
    }

    public void OnEnable()
    {
        aRTrackedImageManager.trackedImagesChanged += OnImageChanged;
    }

    public void OnDisable()
    {
        aRTrackedImageManager.trackedImagesChanged -= OnImageChanged;
    }

    public void OnImageChanged(ARTrackedImagesChangedEventArgs args) {
        foreach (var trakedImage in args.added) {
            Debug.Log(trakedImage.name);
        }
    }

}
