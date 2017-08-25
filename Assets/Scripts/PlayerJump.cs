using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour {

    //Video: "Make the player jump"

    //properties
    public float jumpSpeed = 320f;
    public float forwardSpeed = 20;
    private Rigidbody2D body2d;
    private InputState inputState;


    // method
    void Awake()
    {
        body2d = GetComponent<Rigidbody2D>();
        inputState = GetComponent<InputState>();
    }
    


    //method
    void Update ()
    {
        if (inputState.standing)
        {
            if (inputState.actionButton)
            {
                //make player jump forward when it lands on a hurdle
                body2d.velocity = new Vector2(transform.position.x < 0 ? forwardSpeed : 0, jumpSpeed);
                //body2d.velocity = new Vector2(0, jumpSpeed);

            }
        }
    }

}
