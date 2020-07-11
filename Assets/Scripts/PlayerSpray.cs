using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpray : MonoBehaviour
{
    public Sprite citizenSprite;
    public GameObject sprayVFX;

    PlayerMovement player;

    private void Update()
    {
        fireSpray();
        faceMouse();

    }

    private void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
    }

    private void fireSpray()
    {
        if (Input.GetMouseButton(0) && player.equipSpray)
        {
            GameObject sprayVFXObject = Instantiate(sprayVFX, transform.position, transform.rotation);
        }
    }

    private void faceMouse()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 direction = new Vector2(transform.position.x - mousePosition.x, transform.position.y - mousePosition.y);

        transform.up = direction;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Infected"))
        {
            collision.gameObject.GetComponent<SpriteRenderer>().sprite = citizenSprite;
            collision.gameObject.tag = "Negative";
        }
    }
}
