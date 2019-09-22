using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRushMovement : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float speed;
    private Vector3 dir;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("PlayerCharacter");
    }

    private void FixedUpdate()
    {
        Rigidbody2D rb2d = GetComponent<Rigidbody2D>();
        rb2d.AddForce(new Vector2(dir.x * speed, dir.y * speed));
    }

    void Update()
    {
        dir = (player.transform.position - transform.position).normalized;
    }
}
