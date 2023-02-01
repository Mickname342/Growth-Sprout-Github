using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Animator animator;

    public bool spriting = false;

    public float maxDistance;
    public float Velocity = 10f;
    float horizontalMove = 0f;
    float verticalMove = 0f;

    public Vector3 boxSize;

    public LayerMask layerMask;

    private Rigidbody2D rb2d;

    private void Start()
    {
        //animator = GetComponent<Animator>();

        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * Velocity;
        verticalMove = Input.GetAxisRaw("Vertical") * Velocity;

        //animator.SetFloat("Horizontal Speed", Mathf.Abs(horizontalMove));
        //animator.SetFloat("Vertical Speed", Mathf.Abs(verticalMove));

        HandleMovement();
    }

    public void HandleMovement()
    {
        if (spriting)
        {
            if (Input.GetKeyDown(KeyCode.Space) && GroundCheck())
            {
                rb2d.AddForce(transform.up * Velocity* 1.2f, ForceMode2D.Impulse);
                //animator.SetBool("IsJumping", true);
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

}
