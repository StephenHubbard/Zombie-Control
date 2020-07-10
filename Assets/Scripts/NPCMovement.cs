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
    public Sprite zombieSprite;

    private void FixedUpdate()
    {
        Move();
    }

    private void Start()
    {
        StartCoroutine(ChangeDirection());
        changeDirectionTime = Random.Range(1f, 3f);
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
        if (collision.gameObject.CompareTag("Citizen") && gameObject.CompareTag("Zombie"))
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = zombieSprite;
            collision.gameObject.GetComponent<SpriteRenderer>().sprite = zombieSprite;
            gameObject.tag = "Zombie";
            collision.gameObject.tag = "Zombie";
        }
    }
}
