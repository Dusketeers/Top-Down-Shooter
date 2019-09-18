using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movSpeed = 5f;   // Player movement speed variable
    public Rigidbody2D rb;

    Vector2 movement;             //  Movement of the player
    Vector2 mousePos;             //  Storing the mouse position 

    public Camera cam;            // Used to refrence pixel positions in real word xyz

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
        rb.MovePosition(rb.position + movement * movSpeed * Time.fixedDeltaTime);

        Vector2 lookDir = mousePos - rb.position;                               // Simple vetor math (Ask any explaination if needed)
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;

    }
}
