using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    private float moveVelocity;
    public float jumpHeight;

    // A point in space
    public Transform groundCheck;
    public float groundCheckRadius;
    // Invisible layer that contains Ground objects
    public LayerMask whatIsGround;
    private bool grounded;

    private bool doubleJump = false;

    private Animator anim;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

        if (grounded)
            doubleJump = false;

        anim.SetBool("Grounded", grounded);

        if ( (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) ) && grounded) {
            // Vector2 -> 2D vector x and y
            // get current x and mvoe y by jumpHeight
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
        }

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)) && !doubleJump && !grounded) {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
            doubleJump = true;
        }

        moveVelocity = 0f;

        // move left
        if (Input.GetKey(KeyCode.A)) {
            //GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            moveVelocity = -moveSpeed;
        }

        // move right
        if (Input.GetKey(KeyCode.D)) {
            //GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            moveVelocity = moveSpeed;
        }

        GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocity, GetComponent<Rigidbody2D>().velocity.y);

        // doesnt matter if going left or right
        anim.SetFloat("Speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));

        // flip character depending on x velocity
        if(GetComponent<Rigidbody2D>().velocity.x > 0) {
            transform.localScale = new Vector3(1f, 1f, 1f);
        } else if(GetComponent<Rigidbody2D>().velocity.x < 0) {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }

    /** 
     * only happens a certain amount of times every 
     * Checks if the ground point in player overlaps with ground (layer)
     */
    private void FixedUpdate() {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }
}
