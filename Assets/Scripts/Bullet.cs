using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float timeToLive = float.PositiveInfinity;

    // Start is called before the first frame update
    void Start()
    {
        if (!float.IsPositiveInfinity(this.timeToLive)) {
            StartCoroutine(DestroyOnTimeout());
        }
    }

    private IEnumerator DestroyOnTimeout()
    {
        yield return new WaitForSeconds(timeToLive);
        Debug.Log("Destroyed bullet");
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}