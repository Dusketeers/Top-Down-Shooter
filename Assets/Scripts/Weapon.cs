using UnityEngine;
using System;
using UnityEditor;

public abstract class Weapon
{
    public GameObject bulletPrefab;

    public Weapon()
    {
        bulletPrefab = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/Resources/Bullet.prefab", typeof(GameObject));
    }

    public abstract void Shoot(Transform transform);
}

public class Pistol : Weapon
{
    public float bulletForce = 20f;

    public override void Shoot(Transform transform)
    {
        GameObject bullet = MonoBehaviour.Instantiate(bulletPrefab, transform.position, transform.rotation);
        Rigidbody2D rb2d = bullet.GetComponent<Rigidbody2D>();
        rb2d.AddForce(transform.up * bulletForce, ForceMode2D.Impulse);
    }
}