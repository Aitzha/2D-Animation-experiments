using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D rb;
    private float HorizontalVelocity = 0f;
    private bool FacingRight = true;

    public float speed = 10f;
    public float jumpForce = 10f;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("space"))
        {
            rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        }

        HorizontalVelocity = Input.GetAxisRaw("Horizontal") * speed;

        if ((HorizontalVelocity > 0 && !FacingRight) || (HorizontalVelocity < 0 && FacingRight))
        {
            FacingRight = !FacingRight;
            transform.localScale = new Vector3(transform.localScale.x * -1, 1, 1);
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(HorizontalVelocity, rb.velocity.y);
    }
}
