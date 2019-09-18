using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform firePoint;      // The point of firing the projectiles
    public GameObject bulletPrefab;  // The bullet object

    public float bulletForce = 20f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shooting();
        }
    }

    void Shooting()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);      // Creating the Bullet in the scene
        Rigidbody2D rb2d = bullet.GetComponent<Rigidbody2D>();                                      // Getting the Rigidbody component of the bullet
        rb2d.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);                             // Adding force to the bullet projectile

    }
}
