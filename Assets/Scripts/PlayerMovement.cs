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
    public GameObject giveMaskObject;
    public GameObject maskSprite;

    public int masksAvailable = 1;

    public bool equipMask = false;
    public bool equipSpray = true;



    void Update()
    {
        ProcessInputs();
        DisableSpray();
        DisableMask();
        showSprite();
        Equip();

        animator.SetFloat("Horizontal", moveDirection.x);
        animator.SetFloat("Vertical", moveDirection.y);
        animator.SetFloat("Speed", moveDirection.sqrMagnitude);
    }

    private void DisableSpray()
    {
        if (Input.GetMouseButtonDown(0) && equipSpray)
        {
            playerSpray.SetActive(true);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            playerSpray.SetActive(false);
        }
    }

    private void DisableMask()
    {
        if (Input.GetMouseButtonDown(0) && equipMask)
        {
            giveMaskObject.SetActive(true);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            giveMaskObject.SetActive(false);
        }
    }

    private void showSprite()
    {
        if (equipMask)
        {
            maskSprite.SetActive(true);
        }
        else if (!equipMask)
        {
            maskSprite.SetActive(false);
        }
    }

    private void Equip()
    {
        if (Input.GetMouseButtonDown(1) && equipSpray)
        {
            equipMask = true;
            equipSpray = false;

        }
        else if (Input.GetMouseButtonDown(1) && equipMask)
        {
            equipMask = false;
            equipSpray = true;
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
