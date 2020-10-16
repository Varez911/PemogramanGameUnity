using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    //public PlayerCombat playerCombat;
    public Rigidbody2D _2DBody;
    public SpriteRenderer sprite;
    public Animator animator;
    public int runSpeed;
    public int jumpHeight;

    public bool isAttacking;

    private float xMovement;
    private float yMovement;

    // Start is called before the first frame update
    void Start()
    {
        _2DBody = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        Debug.Log("X Velocity: " + _2DBody.velocity.x);
        Debug.Log("Y Velocity: " + _2DBody.velocity.y);
        */
        if (isAttacking == false)
        {
            xMovement = Input.GetAxisRaw("Horizontal");
            yMovement = Input.GetAxisRaw("Vertical");
        }

        if (xMovement < 0)
        {
            sprite.flipX = true;
        }
        else if (xMovement > 0)
        {
            sprite.flipX = false;
        }
        else
        {
            sprite.flipX = sprite.flipX;
        }
        /*
        if (yMovement > 0)
        {
            playerJump();
        }
        */
        animator.SetFloat("Speed", Mathf.Abs(xMovement));
        animator.SetFloat("Airbone", _2DBody.velocity.y);
        animator.SetBool("Attack", isAttacking);
        //animator.SetBool("Ground", isGrounded());
    }

    private void FixedUpdate()
    {

        //_2DBody.AddForce(new Vector2(0, yMovement) * jumpHeight);
        if (_2DBody.velocity.y == 0)
        {
            _2DBody.velocity = new Vector2(xMovement , yMovement * jumpHeight) * runSpeed;
        }
        else if (_2DBody.velocity.y < 0)
        {
            _2DBody.velocity = new Vector2(0, -1 * jumpHeight);
        }
        
    }
    private void playerJump()
    {
        _2DBody.MovePosition((Vector2)transform.position + (new Vector2(xMovement, 0) * runSpeed * Time.deltaTime));
    }
}
