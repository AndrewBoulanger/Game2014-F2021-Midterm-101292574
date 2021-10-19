using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    void UpdateCameraViewPort()
    {
        orientation = Screen.orientation;

        newViewPortRect.width = (Screen.safeArea.width / targetResolution.width ) ;
        newViewPortRect.height = (Screen.safeArea.height / targetResolution.height);
        newViewPortRect.position = Screen.safeArea.position / targetResolution.size;

        camera.rect = newViewPortRect;
    }
}
