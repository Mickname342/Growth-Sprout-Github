using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool spriting = false;
    public float Velocity = 10f;

    private Rigidbody2D rb2d;

    private void Start()
    {
        spriting = true;

        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        HandleMovement();
    }

    public void HandleMovement()
    {
        if (spriting)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb2d.AddForce(transform.up * Velocity, ForceMode2D.Impulse);
            }
        }
        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += transform.right * -Velocity * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += transform.right * Velocity * Time.deltaTime;
        }
    }
}
