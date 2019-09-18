using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Vector3 moveDirection;
    public float movSpeed = 5f;   // Player movement speed variable
    public Rigidbody2D rb;

    public GameObject dashEffect;

    public Vector2 savedVelocity;

    Vector2 movement;             //  Movement of the player
    Vector2 mousePos;             //  Storing the mouse position 

    public Animator camAnim;
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

        // Dash Start
        if (Input.GetButton("Fire2") && Input.GetKey(KeyCode.D))
        {

            rb.AddForce(Vector2.right * 50, ForceMode2D.Impulse);
            Instantiate(dashEffect, transform.position, Quaternion.identity);
            camAnim.SetTrigger("shake");
        }

        else if (Input.GetButton("Fire2") && Input.GetKey(KeyCode.A))
        {
            
            rb.AddForce(Vector2.left * 50, ForceMode2D.Impulse);
            Instantiate(dashEffect, transform.position, Quaternion.identity);
            camAnim.SetTrigger("shake");
        }

        else if (Input.GetButton("Fire2") && Input.GetKey(KeyCode.S))
        {
            
            rb.AddForce(Vector2.down * 50, ForceMode2D.Impulse);
            Instantiate(dashEffect, transform.position, Quaternion.identity);
            camAnim.SetTrigger("shake");
        }

        else if (Input.GetButton("Fire2") && Input.GetKey(KeyCode.W))
                {
            
            rb.AddForce(Vector2.up * 50, ForceMode2D.Impulse);
            Instantiate(dashEffect, transform.position, Quaternion.identity);
            camAnim.SetTrigger("shake");
        }
        // Dash End

    }
}
