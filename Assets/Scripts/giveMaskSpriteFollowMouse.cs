using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class giveMaskSpriteFollowMouse : MonoBehaviour
{

    PlayerMovement player;
    public GameObject extensionSprite;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        FaceMouse();
        changeMaskActiveColor();
    }

    private void changeMaskActiveColor()
    {
        if (Input.GetMouseButton(0) && player.masksAvailable > 0)
        {
            extensionSprite.GetComponent<SpriteRenderer>().color = new Color32(100, 212, 93, 255);
        }
        else if (Input.GetMouseButton(0) && player.masksAvailable == 0)
        {
            extensionSprite.GetComponent<SpriteRenderer>().color = new Color32(200, 50, 50, 255);
        }
        else
        {
            extensionSprite.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
        }
    }

    public void maskColorRed()
    {
        extensionSprite.GetComponent<SpriteRenderer>().color = new Color32(200, 50, 50, 255);
    }


    private void FaceMouse()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 direction = new Vector2(transform.position.x - mousePosition.x, transform.position.y - mousePosition.y);

        transform.up = direction;
    }
}
