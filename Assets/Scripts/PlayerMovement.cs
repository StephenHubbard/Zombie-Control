using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 10f;
    public Rigidbody2D rb;
    private Vector2 moveDirection;
    public Animator animator;
    private bool isWalking = false;
    public GameObject playerSpray;



    void Update()
    {
        ProcessInputs();
        disableSpray();

        animator.SetFloat("Horizontal", moveDirection.x);
        animator.SetFloat("Vertical", moveDirection.y);
        animator.SetFloat("Speed", moveDirection.sqrMagnitude);
    }

    private void disableSpray()
    {
        if (Input.GetMouseButtonDown(0))
        {
            playerSpray.SetActive(true);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            playerSpray.SetActive(false);
        }

    }



    



    private void FixedUpdate()
    {
        Move();
    }

    private void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized;
    }

    private void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }
}
