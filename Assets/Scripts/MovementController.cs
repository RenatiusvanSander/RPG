using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    /*
    * Defines speed of movement.
    */
    public float movementSpeed = 3.0f;

    Animator animator;

    string animationState = "AnimationState";

    // Holds the position of PlayerObject as 2D Vector.
    Vector2 movement = new Vector2();

    //
    Rigidbody2D rb2D;

    // statesfor the state machine as enum.
    enum CharStates
    {
        walkEast = 1,
        walkSouth = 2,
        walkWest = 3,
        walkNorth = 4,
        idleSouth = 5    
    }

    // Start is called before the first frame update
    // Use this for initialization
    private void Start()
    {
        animator = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        UpdateState();
        // Keep this empty for now.
    }

    // Fixed update time for frame.
    void FixedUpdate() {
        MoveCharacter();
    }

    private void MoveCharacter() {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        movement.Normalize();

        rb2D.velocity = movement * movementSpeed;
    }

    private void UpdateState() {
        if(movement.x > 0)
        {
            animator.SetInteger(animationState, (int) CharStates.walkEast);
        }
        else if (movement.x < 0)
        {
            animator.SetInteger(animationState, (int) CharStates.walkWest);
        }
        else if (movement.y > 0)
        {
            animator.SetInteger(animationState, (int) CharStates.walkNorth);
        }
        else if (movement.y < 0)
        {
            animator.SetInteger(animationState, (int) CharStates.walkSouth);
        }
        else
        {
            animator.SetInteger(animationState, (int) CharStates.idleSouth);
        }
    }
}
