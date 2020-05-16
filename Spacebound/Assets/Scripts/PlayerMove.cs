using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float moveDamp;

    [SerializeField]
    private float jumpForce;
    [SerializeField]
    private float jumpSpeed;

    [SerializeField]
    private LayerMask groundLayer;
    private bool isGrounded;

    [SerializeField]
    private float rayDist;

    void Update()
    {
        float horAxis = Input.GetAxis("Horizontal");

        if (horAxis != 0)
        {
            transform.Translate(Vector2.right * ((horAxis * moveSpeed) * (Time.deltaTime * moveDamp)), Space.World);
        }

        if (Input.GetKeyDown ("space") && isGrounded)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * (jumpForce * jumpSpeed), ForceMode2D.Impulse);
        }

        if (Physics2D.Raycast (transform.position, Vector2.down, rayDist, groundLayer))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

    }
}
