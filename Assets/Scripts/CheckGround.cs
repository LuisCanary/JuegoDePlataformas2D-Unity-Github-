using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround : MonoBehaviour
{
	public static bool isGrounded;

	private void OnTriggerEnter2D(Collider2D other)
	{
		isGrounded = true;
		Debug.Log("Esta en el suelo");
	}
	private void OnTriggerExit2D(Collider2D other)
	{
		isGrounded = false;
		Debug.Log("NO Esta en el suelo");

	}
}
