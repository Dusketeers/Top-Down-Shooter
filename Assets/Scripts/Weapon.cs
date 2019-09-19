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

public class Shotgun : Weapon
{
    public float bulletForce = 12f;
    public float bulletTTL = 1f;  // Time To Live
    public float spreadAngleVariance = 30f;
    public int numberOfBullets = 20;

    private float sampleGaussian()
    {
        float v1, v2, s;
        do
        {
            v1 = UnityEngine.Random.Range(-1f, 1f);
            v2 = UnityEngine.Random.Range(-1f, 1f);
            s = v1 * v1 + v2 * v2;
        } while (s >= 1.0f || s == 0f);

        s = Mathf.Sqrt((-2.0f * Mathf.Log(s)) / s);
        return v1 * s;
    }

    public override void Shoot(Transform transform)
    {
        for (int i = 0; i < numberOfBullets; i++)
        {
            float randomAngle = spreadAngleVariance * sampleGaussian();
            Quaternion aimDirection = transform.rotation;
            Quaternion flyDirection = aimDirection * Quaternion.AngleAxis(randomAngle, Vector3.forward);
            GameObject bullet = MonoBehaviour.Instantiate(bulletPrefab, transform.position, flyDirection);
            Rigidbody2D rb2d = bullet.GetComponent<Rigidbody2D>();
            rb2d.AddForce(bullet.transform.up * bulletForce, ForceMode2D.Impulse);
            Debug.Log(randomAngle);
        }
    }
}