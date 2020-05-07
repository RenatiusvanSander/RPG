using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    /*
    * Defines speed of movement.
    */
    public float movementSpeed = 3.0f;

    // Holds the position of PlayerObject as 2D Vector.
    Vector2 movement = new Vector2();

    //
    Rigidbody2D rb2D;

    // Start is called before the first frame update
    // Use this for initialization
    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        // Keep this empty for now.
    }

    // ?
    void FixedUpdate() {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        movement.Normalize();

        rb2D.velocity = movement * movementSpeed;
    }
}
