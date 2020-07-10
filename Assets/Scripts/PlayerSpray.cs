using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpray : MonoBehaviour
{
    public Sprite citizenSprite;

    public GameObject sprayVFX;


    private void Update()
    {
        fireSpray();

    }


    private void fireSpray()
    {
        if (Input.GetMouseButton(0))
        {
            GameObject sprayVFXObject = Instantiate(sprayVFX, transform.position, transform.rotation);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Zombie"))
        {
            collision.gameObject.GetComponent<SpriteRenderer>().sprite = citizenSprite;
            collision.gameObject.tag = "Citizen";
        }
    }

    
}
