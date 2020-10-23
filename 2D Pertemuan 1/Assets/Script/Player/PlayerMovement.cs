using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
	public Flashing flashing;
	public Rigidbody2D body2D;
	public Animator animator;

	public bool isAttacking = false;

	public float runSpeed = 40f;
	public float sprintSpeed = 1.8f;

	float horizontalMove = 0f;
	bool jump = false;
	bool crouch = false;
	bool sprint = false;

    private void Start()
    {
		body2D.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
	{
		animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
		//Debug.Log(body2D.velocity.y);
		animator.SetFloat("Airbone", body2D.velocity.y);

		if (sprint)
		{
			horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed * sprintSpeed;
		}
        else
        {
			horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
		}

		if (Input.GetButtonDown("Run"))
        {
			sprint = true;
			flashing.start = true;
		}
        else if (Input.GetButtonUp("Run"))
        {
			sprint = false;
        }

		if (Input.GetButtonDown("Jump"))
		{
			
			animator.SetBool("isJumping", true);
			jump = true;
		}

		if (Input.GetButtonDown("Crouch") && !jump)
		{
			crouch = true;
			
		}
		else if (Input.GetButtonUp("Crouch"))
		{
			crouch = false;
		}

		animator.SetBool("Crouch", crouch);
		animator.SetBool("Sprint", sprint);
		//animator.SetBool("Attack", isAttacking);
	}

	public void OnLanding()
    {
		animator.SetBool("isJumping", false);
		jump = false;
	}

	void FixedUpdate()
	{
		// Move our character
		
		controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
	}
}
