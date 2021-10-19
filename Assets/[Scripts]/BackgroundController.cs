///
/// File          : BackgroundController.cs 
/// modified by   : Andrew Boulanger 
/// student num   : 101292574
/// Last modified : Oct 19, 2021
/// 
/// controls background scrolling and reseting when beyond the screen
/// 
/// revision history: v2 - changed vertical movement to horizontal after switching to landscape mode, all movement is now based on the x axis.
///



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// controls background scrolling and reseting when beyond the screen

public class BackgroundController : MonoBehaviour
{
    public float speed;
    public float boundary;

    // Update is called once per frame
    void Update()
    {
        _Move();
        _CheckBounds();
    }

    ///return to the x position specified by the boundary
    private void _Reset()
    {
        transform.position = new Vector3(boundary,0.0f);
    }

    private void _Move()
    {
        transform.position -= new Vector3(speed, 0.0f) * Time.deltaTime;
    }

    private void _CheckBounds()
    {
        // if the background is left of the screen then reset
        if (transform.position.x <= -boundary)
        {
            _Reset();
        }
    }

}
