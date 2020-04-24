using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
	public float jumpSpeed = 5;

	public float runSpeed=2;

	Rigidbody2D rb2D;

	public bool betterJump = false;

	public float fallMultiplier = 1.5f;
	public float lowJumpMultiplier = 2f;


	public Animator animator;

	public SpriteRenderer spriteRend;

	private void Start()
	{
		rb2D = GetComponent<Rigidbody2D>();
	}

	private void FixedUpdate()
	{
		if (Input.GetKey("d") || Input.GetKey("right"))
		{
			rb2D.velocity = new Vector2(runSpeed,rb2D.velocity.y);
			animator.SetBool("Running", true);
			spriteRend.flipX = false;

		}
		else if (Input.GetKey("a") || Input.GetKey("left"))
		{
			rb2D.velocity = new Vector2(-runSpeed,rb2D.velocity.y);
			animator.SetBool("Running", true);
			spriteRend.flipX=true;

		}
		else
		{
			rb2D.velocity = new Vector2(0,rb2D.velocity.y);
			animator.SetBool("Running", false);
		}
		if (Input.GetKey("space") && CheckGround.isGrounded)
		{
			rb2D.velocity = new Vector2(rb2D.velocity.x, jumpSpeed);			
		}
		if (CheckGround.isGrounded==false)
		{
			animator.SetBool("Jump", true);
			animator.SetBool("Running", false);


		}
		if (CheckGround.isGrounded == true)
		{
			animator.SetBool("Jump", false);

		}

		if (betterJump)
		{
			if (rb2D.velocity.y < 0)
			{
				rb2D.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier) * Time.deltaTime;
			}
			else if (rb2D.velocity.y > 0 && !Input.GetKey("space"))
			{
				rb2D.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier) * Time.deltaTime;

			}
		}
	}


}
