using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Vector3 moveDirection;
    public float movSpeed = 5f;
    public Rigidbody2D rb;

    public GameObject dashEffect;

    public Vector2 savedVelocity;

    Vector2 movement;
    Vector2 mousePos;

    public Animator camAnim;
    public Camera cam;            // Used to refrence pixel positions in real word xyz

    private static readonly Dictionary<KeyCode, Vector2> keyDict = new Dictionary<KeyCode, Vector2>()
        {
            {KeyCode.W, Vector2.up},
            {KeyCode.A, Vector2.left},
            {KeyCode.S, Vector2.down },
            {KeyCode.D, Vector2.right}
        };


    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

     }

    // Used to execute the commands given inthe Update function
    void FixedUpdate()
    {
        Move();
        Rotate();
        if (Input.GetButton("Fire2"))
        {
            Dash();
        }
    }

    private void Move()
    {
        rb.MovePosition(rb.position + movement * movSpeed * Time.fixedDeltaTime);
    }

    private void Rotate()
    {
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }

    private void Dash()
    {
        foreach (var butt in keyDict)
        {
            if (Input.GetKey(butt.Key))
            {
                rb.AddForce(butt.Value * 50, ForceMode2D.Impulse);
                Instantiate(dashEffect, transform.position, Quaternion.identity);
                camAnim.SetTrigger("shake");
            }
        }
    }
}
