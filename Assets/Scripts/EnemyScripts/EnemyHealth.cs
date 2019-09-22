using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("PlayerBullet"))
        {
            Destroy(collision.gameObject);
            StartCoroutine(RemoveEnemy());
        }
    }

    IEnumerator RemoveEnemy()
    {
        yield return new WaitForSeconds(0.3f);
        Destroy(gameObject);
    }
}
