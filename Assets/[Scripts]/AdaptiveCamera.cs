///
/// AdaptiveCamera.cs 
/// modified by Andrew Boulanger 101292574
/// modified by   : Andrew Boulanger 
/// student num   : 101292574
/// Last modified : Oct 19, 2021
/// 
/// controls background scrolling and reseting when beyond the screen
/// 
/// revision history: v1 changes camera view rect based on the difference in safe area and target resolution. Doesn't successfully scale yet
///


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// Attempt at making an adaptive camera that reacts to the device resolution and scales the screen accordingly.
public class AdaptiveCamera : MonoBehaviour
{
    ScreenOrientation orientation;

    Camera camera;

    public Rect targetResolution;
    private Rect newViewPortRect;
    

    // Start is called before the first frame update
    void Start()
    {
        camera = GetComponent<Camera>();
        UpdateCameraViewPort();

    }

    // Update is called once per frame
    void Update()
    {

        if (Screen.orientation != orientation)
        {
            UpdateCameraViewPort();
        }
    }

    ///called when screen orientation changes, updates main camera viewport rect
    void UpdateCameraViewPort()
    {
        orientation = Screen.orientation;

        newViewPortRect.width = (Screen.safeArea.width / targetResolution.width);
        newViewPortRect.height = (Screen.safeArea.height / targetResolution.height);
        newViewPortRect.position = Screen.safeArea.position / targetResolution.size;


        camera.rect = newViewPortRect;

    }
}
