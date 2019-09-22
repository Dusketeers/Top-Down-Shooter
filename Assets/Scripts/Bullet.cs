using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float timeToLive = float.PositiveInfinity;

    // Start is called before the first frame update
    void Start()
    {
        if (!float.IsPositiveInfinity(this.timeToLive))
        {
            StartCoroutine(DestroyOnTimeout());
        }
    }

    private IEnumerator DestroyOnTimeout()
    {
        yield return new WaitForSeconds(1);
        Debug.Log("Destroyed bullet");
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            //do something ex: sound effect, visual effect etc
            Destroy(gameObject);
        }
    }
}