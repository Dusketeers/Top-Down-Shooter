using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    public Weapon weapon { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        if (Random.Range(0f, 1f) >= 0.5)
        {
            weapon = new Pistol();
        } else
        {
            weapon = new Shotgun();
        }
        GetComponent<SpriteRenderer>().sprite = weapon.pickupSprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("PlayerCharacter"))
        {
            collision.gameObject.GetComponent<Shoot>().CurrentWeapon = weapon;
            Destroy(this.gameObject);
        }
    }
}
