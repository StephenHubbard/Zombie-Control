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
    public GameObject spraySprite;

    public int masksAvailable = 3;

    public bool equipMask = false;
    public bool equipSpray = true;
    public bool canMove = false;



    void Update()
    {
        ProcessInputs();
        DisableSpray();
        DisableMask();
        showSprite();
        showSpriteSpray();
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

    private void showSpriteSpray()
    {
        if (equipSpray)
        {
            spraySprite.SetActive(true);
        }
        else if (!equipSpray)
        {
            spraySprite.SetActive(false);
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
        if (canMove)
        {
            float moveX = Input.GetAxisRaw("Horizontal");
            float moveY = Input.GetAxisRaw("Vertical");
            moveDirection = new Vector2(moveX, moveY).normalized;
        }
    }

    private void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }
}
