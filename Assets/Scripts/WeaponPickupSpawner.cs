using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickupSpawner : MonoBehaviour
{
    [SerializeField] private GameObject weaponPickup;
    public float minWait = 10f;
    public float maxWait = 30f;
    private readonly Quaternion DEFAULT_ROTATION = new Quaternion();

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnOnInterval());
    }

    private IEnumerator SpawnOnInterval()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minWait, maxWait));
            Spawn();
        }
    }

    private void Spawn()
    {
        Instantiate(weaponPickup, generatePosition(), DEFAULT_ROTATION);
    }

    private Vector3 generatePosition()
    {
        float height = Camera.main.orthographicSize * 2.0f;
        float width = height * Screen.width / Screen.height;

        return new Vector3(
            Random.Range(- width / 2, width / 2),
            Random.Range(- height / 2, height / 2)
            );
    }
}
