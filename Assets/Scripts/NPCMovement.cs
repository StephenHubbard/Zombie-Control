using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    public Rigidbody2D rb;
    private Vector2 moveDirection;
    public Animator animator;
    [SerializeField] float changeDirectionTime = 2f;

    private void Start()
    {
        StartCoroutine(ChangeDirection());
        changeDirectionTime = Random.Range(1f, 3f);
    }   

    private void FixedUpdate()
    {
        Move();
        checkSick();
    }

    private void checkSick()
    {
        if (gameObject.CompareTag("Infected"))
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        animator.SetFloat("Horizontal", moveDirection.x);
        animator.SetFloat("Vertical", moveDirection.y);
        animator.SetFloat("Speed", moveDirection.sqrMagnitude);

    }



    IEnumerator ChangeDirection()
    {
        float RandomX = Random.Range(-1f, 1f);
        float RandomY = Random.Range(-1f, 1f);

        moveDirection = new Vector2(RandomX, RandomY).normalized;
        yield return new WaitForSeconds(changeDirectionTime);
        StartCoroutine(ChangeDirection());
    }

    private void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.CompareTag("Negative") && gameObject.CompareTag("Infected")) & !collision.gameObject.GetComponent<Mask>())
        {
            gameObject.tag = "Infected";
            collision.gameObject.tag = "Infected";
        }
    }
}
