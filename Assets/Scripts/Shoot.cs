using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform firePoint;
    [SerializeField] private Weapon currentWeapon;

    public Weapon CurrentWeapon { get => currentWeapon; set => currentWeapon = value; }

    public void Start()
    {
        CurrentWeapon = new Pistol();
    }

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
        if (CurrentWeapon != null)
        {
            CurrentWeapon.Shoot(firePoint);
        } else
        {
            Debug.Log("Tried to shoot with no gun.");
        }
    }

}
