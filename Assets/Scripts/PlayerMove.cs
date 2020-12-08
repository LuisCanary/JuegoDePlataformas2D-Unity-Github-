using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

	public float runSpeed=2;

	public float jumpSpeed = 3;

	public float doubleJumpSpeed = 2.5f;

	private bool canDoubleJump;

	Rigidbody2D rb2D;


	public bool betterJump = false;

	public float fallMultiplier = 0.5f;

	public float lowJumpMultiplier = 1f;

	public SpriteRenderer spriteRenderer;

	public Animator animator;

	public GameObject dustLeft;
	public GameObject dustRight;

	public float dashCooldown;

	public float dashForce=30;

	public GameObject dashParticle;

	void Start()
    {
		rb2D = GetComponent<Rigidbody2D>();
    }

	private void Update()
	{
		dashCooldown -= Time.deltaTime;

		if (Input.GetKey("space"))
		{
			if (CheckGround.isGrounded)
			{
				canDoubleJump = true;
				rb2D.velocity = new Vector2(rb2D.velocity.x, jumpSpeed);
			}
			else
			{
				if (Input.GetKeyDown("space"))
				{
					if (canDoubleJump)
					{
						animator.SetBool("DoubleJump", true);
						rb2D.velocity = new Vector2(rb2D.velocity.x, doubleJumpSpeed);
						canDoubleJump = false;

					}
				}
			}
		}

		if (CheckGround.isGrounded == false)
		{
			animator.SetBool("Jump", true);
			animator.SetBool("Run", false);
			dustLeft.SetActive(false);
			dustRight.SetActive(false);
		}
		if (CheckGround.isGrounded == true)
		{
			animator.SetBool("Jump", false);
			animator.SetBool("DoubleJump", false);
			animator.SetBool("Falling", false);
		}

		if (rb2D.velocity.y<0)
		{
			animator.SetBool("Falling", true);
		}
		else if (rb2D.velocity.y > 0)
		{
			animator.SetBool("Falling", false);
		}
	}

	void FixedUpdate()
    {

		if (Input.GetKey("d") || Input.GetKey("right"))
		{
			rb2D.velocity = new Vector2(runSpeed, rb2D.velocity.y);
			spriteRenderer.flipX = false;
			animator.SetBool("Run", true);

            if (CheckGround.isGrounded==true)
            {
				dustLeft.SetActive(true);
				dustRight.SetActive(false);
			}

			if (Input.GetKey("e") && dashCooldown <= 0)
			{
				Dash();
			}


		}

        else if (Input.GetKey("e")&& dashCooldown<=0)
        {
			Dash();
        }

		else if (Input.GetKey("a") || Input.GetKey("left"))
		{
			rb2D.velocity = new Vector2(-runSpeed, rb2D.velocity.y);
			spriteRenderer.flipX = true;
			animator.SetBool("Run", true);

			if (CheckGround.isGrounded == true)
			{
				dustLeft.SetActive(false);
				dustRight.SetActive(true);
			}
			if (Input.GetKey("e") && dashCooldown <= 0)
			{
				Dash();
			}
		}

		else
		{
			rb2D.velocity = new Vector2(0, rb2D.velocity.y);
			animator.SetBool("Run", false);

			dustLeft.SetActive(false);
			dustRight.SetActive(false);

		}


		if (betterJump)
		{
			if (rb2D.velocity.y<0)
			{
				rb2D.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier) * Time.deltaTime;
			}

			if (rb2D.velocity.y>0 && !Input.GetKey("space")) 
			{
				rb2D.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier) * Time.deltaTime;
			}


		}

    }

	public void Dash()
	{

		GameObject dashObject;

        dashObject = Instantiate(dashParticle,transform.position,transform.rotation);

        if (spriteRenderer.flipX==true)
        {
			rb2D.AddForce(Vector2.left*dashForce,ForceMode2D.Impulse);
        }
        else
        {
			rb2D.AddForce(Vector2.right * dashForce, ForceMode2D.Impulse);
		}

		dashCooldown = 2;

		Destroy(dashObject,1);


	}



}
