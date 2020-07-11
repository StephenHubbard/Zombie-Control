using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed;
    public Rigidbody2D rb;
    private Vector2 moveDirection;
    // public Animator animator;
    private bool isWalking = false;
    public GameObject playerSpray;



    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
        faceMouse();
        disableSpray();

        //animator.SetFloat("Horizontal", moveDirection.x);
        //animator.SetFloat("Vertical", moveDirection.y);
        //animator.SetFloat("Speed", moveDirection.sqrMagnitude);
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



    private void faceMouse()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 direction = new Vector2(transform.position.x - mousePosition.x, transform.position.y - mousePosition.y);

        transform.up = direction;
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
