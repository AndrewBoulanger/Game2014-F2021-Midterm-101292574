///
/// EnemyController.cs 
/// modified by Andrew Boulanger 101292574
/// Last modified Oct 19, 2021
/// 
/// controls enemy movement, changes direction when it reaches the vertical bounds of the screen
/// 
/// Changes made: changed horizontal movement to vertical after switching to landscape mode, all movement is now based on the y axis.
///

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// controls enemy movement, changes direction when it reaches the vertical bounds of the screen
public class EnemyController : MonoBehaviour
{
    public float verticalSpeed;
    public float verticalBoundary;
    public float direction;

    public float xRightOffset;

    // Update is called once per frame
    void Update()
    {
        _Move();
        _CheckBounds();

    }

    ///moves the enemy in the current set direction
    private void _Move()
    {
        transform.position += new Vector3( 0.0f, verticalSpeed * direction * Time.deltaTime, 0.0f);
    }

    ///reverses enemy direction
    private void _CheckBounds()
    {
        // check right boundary
        if (transform.position.y >= verticalBoundary)
        {
            direction = -1.0f;
        }

        // check left boundary
        if (transform.position.y <= -verticalBoundary)
        {
            direction = 1.0f;
        }
    }
 
}
