using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGiveMask : MonoBehaviour
{

    [SerializeField] RuntimeAnimatorController[] myControllers;
    PlayerMovement player;
    giveMaskSpriteFollowMouse giveMaskSpriteFollowMouse;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
        giveMaskSpriteFollowMouse = FindObjectOfType<giveMaskSpriteFollowMouse>();
    }

    // Update is called once per frame
    void Update()
    {
        faceMouse();

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
        if (collision.gameObject.CompareTag("Negative") && player.masksAvailable > 0)
        {
            var animator = collision.gameObject.GetComponent<Animator>();
            if (animator.runtimeAnimatorController == myControllers[0])
            {
                animator.runtimeAnimatorController = myControllers[1];
                collision.gameObject.AddComponent<Mask>();
            }
            else if (animator.runtimeAnimatorController == myControllers[2])
            {
                animator.runtimeAnimatorController = myControllers[3];
                collision.gameObject.AddComponent<Mask>();
            }
            player.masksAvailable--;
        }
        

    }
}
