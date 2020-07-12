using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerSpray : MonoBehaviour
{
    public Sprite citizenSprite;
    public GameObject sprayVFX;
    public AudioClip spraySFX;

    private bool sprayAudioPlaying = false;

    PlayerMovement player;

    HandleSprayFill handleSprayFill;

    private void Update()
    {
        fireSpray();
        faceMouse();
    }

    private void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
        handleSprayFill = FindObjectOfType<HandleSprayFill>();
        //InvokeRepeating("audioSprayDelay", .5f, .15f);

    }

    private void fireSpray()
    {
        if (Input.GetMouseButton(0) && player.equipSpray && handleSprayFill.GetComponent<Slider>().value > 0)
        {
            GameObject sprayVFXObject = Instantiate(sprayVFX, transform.position, transform.rotation);
            handleSprayFill.sprayOn = true;
        }
        
    }


    // play the spray audio, implement later if time allows (can't find good audio)
    private void audioSprayDelay()
    {
        AudioSource.PlayClipAtPoint(spraySFX, Camera.main.transform.position);
        print("audio played");
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
