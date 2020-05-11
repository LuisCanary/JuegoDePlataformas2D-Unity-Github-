using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.transform.CompareTag("Player"))
		{
			collision.transform.GetComponent<PlayerRespawn>().ReachedCheckPoint(transform.position.x,transform.position.y);
		}

		//Start Animation Checkpoint
		GetComponent<Animator>().enabled = true;
	}
}
