using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public bool spriting = false;

    public float maxDistance;
    public float Velocity = 10f;

    public Vector3 boxSize;

    public LayerMask layerMask;

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
            if (Input.GetKeyDown(KeyCode.Space) && GroundCheck())
            {
                rb2d.AddForce(transform.up * Velocity* 1.2f, ForceMode2D.Impulse);
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

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(transform.position - transform.up * maxDistance, boxSize);
    }

    private bool GroundCheck()
    {
        if (Physics2D.BoxCast(transform.position, boxSize, 0, -transform.up, maxDistance, layerMask))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bramble"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

}
