using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : PawnInput
{
    private Movement2D move2d;
    public float runSpeed = 20f;
    public float jumpForce = 0f;



    float horizontalInput = 0f;
    bool JumpInput;

    // Start is called before the first frame update
    void Start()
    {
        move2d = GetComponent<Movement2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal") * runSpeed;
        if(Input.GetButtonDown("Jump"))
        {
            JumpInput = true;
        }

    }

    private void FixedUpdate()
    {
        move2d.Move(horizontalInput);
        if (JumpInput)
        {
            JumpInput = false;
            move2d.Jump(jumpForce);
        }

    }

}

