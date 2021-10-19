///
/// File          : BulletController.cs 
/// modified by   : Andrew Boulanger 
/// student num   : 101292574
/// Last modified : Oct 19, 2021
/// 
/// controls background scrolling and reseting when beyond the screen
/// 
/// revision history: v2  changed vertical movement to horizontal after switching to landscape mode, all movement is now based on the x axis.
///


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// controls bullet movement. when off screen bullets will return to the bullet manager
public class BulletController : MonoBehaviour, IApplyDamage
{
    public float horizontalSpeed;
    public float horizontalBoundary;
    public BulletManager bulletManager;
    public int damage;

    
    // Start is called before the first frame update
    void Start()
    {
        bulletManager = FindObjectOfType<BulletManager>();
    }

    // Update is called once per frame
    void Update()
    {
        _Move();
        _CheckBounds();

    }

    ///moves the bullet right
    private void _Move()
    {
        transform.position += new Vector3(horizontalSpeed, 0.0f, 0.0f) * Time.deltaTime;
    }

    ///returns bullet to the bullet pool on exiting the screen
    private void _CheckBounds()
    {
        if (transform.position.x > horizontalBoundary)
        {
            bulletManager.ReturnBullet(gameObject);
        }
    }

    ///returns bullet to the bullet pool on trigger enter
    public void OnTriggerEnter2D(Collider2D other)
    {
        bulletManager.ReturnBullet(gameObject);
    }

    ///returns damage to be applied
    public int ApplyDamage()
    {
        return damage;
    }


}
