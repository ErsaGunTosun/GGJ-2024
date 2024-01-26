using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] KeyCode rightButton;
    [SerializeField] KeyCode leftButton;
    [SerializeField] KeyCode jumpButton;


    private BoxCollider2D boxcollider;
    private Rigidbody2D rb;
    private void Awake()
    {
        boxcollider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;

    }

    // Update is called once per frame
    private void Update()
    {
        // rb.velocity =  new Vector2(Input.GetAxis("Horizontal") * speed, rb.velocity.y);
        if (Input.GetKey(jumpButton) && isGround())
            Jump();

        if (Input.GetKey(rightButton))
            rb.velocity = new Vector2(speed, rb.velocity.y);
        else if (Input.GetKeyUp(rightButton))
            rb.velocity = new Vector2(0, rb.velocity.y);

        if (Input.GetKey(leftButton))
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        else if (Input.GetKeyUp(leftButton))
            rb.velocity = new Vector2(0, rb.velocity.y);
    }
    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, speed);

    }
    private bool isGround()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxcollider.bounds.center, boxcollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);

        return raycastHit.collider != null;
    }
}


