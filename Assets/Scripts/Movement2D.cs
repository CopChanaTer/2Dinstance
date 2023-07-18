using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Movement2D : MonoBehaviour
{
    private Rigidbody2D rb;
    public bool grounded;
    public bool facingRight = true;

    public float movementSmoothing = 0.05f;
    Vector3 refVelocity = Vector3.zero;

    public Transform groundCheck;
    public float groundCheckRadius = 0.05f;
    public LayerMask groundLayer;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (groundCheck != null)
        {
            grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        }
    }

    public void Move(float input)
    {
        Vector3 targetVelocity = new Vector2(input, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, 
            targetVelocity, 
            ref refVelocity, 
            movementSmoothing);

        if (input > 0 && !facingRight)
        {
            Flip();
        }else if (input < 0 && facingRight){
            Flip();
        }    
    }

    public void Jump(float power)
    {
       
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 charScale = transform.localScale;
        charScale.x *= -1;
        transform.localScale = charScale;

        
    }


}
