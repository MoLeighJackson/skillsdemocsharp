using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationManager : MonoBehaviour {

    private Animator animator;
    private InputState inputState;

    void Awake()
    {
        animator = GetComponent<Animator>();
        inputState = GetComponent<InputState>();

    }

    void Update()
    {
        var flying = true;

        // player hurt animation is called when player collides with hurdle
        if (inputState.absVelX > 0 && inputState.absVelY < inputState.standingThreshold) //if absolute velocity x is equal to 95 then the player is on top of hurdle or being pushed off screen
            flying = false;    


        animator.SetBool("Flying", flying);
    }
}
