using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public float minX, maxX;
    public Transform groundCheck;
    public LayerMask whatIsGround;
    public float groundCheckRadius = 0.2f;
    
    private SpriteRenderer sRend;
    private Animator animator;
    private Rigidbody2D rBody;

    private bool isMoveR = true;
    private bool isGrounded = false;

    private Vector3 oldPosition;

	// Use this for initialization
	void Start () {
        rBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sRend = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

        if (isMoveR)
        {
            this.transform.position = Vector2.MoveTowards(this.transform.position, new Vector2(maxX, this.transform.position.y), Time.deltaTime * 3.0f);

            Debug.Log(this.transform.position);

            if (this.transform.position.x >= maxX)
            {
                Debug.Log("Reached R");
                isMoveR = false;
            }
        }
        else
        {
            this.transform.position = Vector2.MoveTowards(this.transform.position, new Vector2(minX, this.transform.position.y), Time.deltaTime * 3.0f);

            if (this.transform.position.x <= minX)
            {
                isMoveR = true;
            }
        }

        float calculatedVelocityX = this.transform.position.x - oldPosition.x;

        animator.SetFloat("Speed", calculatedVelocityX + 1);
        animator.SetBool("Grounded", isGrounded);
        animator.SetFloat("vSpeed", rBody.velocity.y);

        oldPosition = this.transform.position;

        if(calculatedVelocityX > 0.0f)
        {
            sRend.flipX = false;
        } else if (calculatedVelocityX < 0.0f)
        {
            sRend.flipX = true;
        }
    }
}
