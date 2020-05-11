using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRespawn : MonoBehaviour
{

	private float checkpointPositionX, checkpointPositionY;

	public Animator animator;

	void Start()
    {
		if (PlayerPrefs.GetFloat("checkpointPositionX") != 0)
		{
			transform.position = (new Vector2(PlayerPrefs.GetFloat("checkPointPositionX"), PlayerPrefs.GetFloat("checkPointPositionY")));
		}
	}

	public void ReachedCheckPoint(float x,float y)
	{
		PlayerPrefs.SetFloat("checkpointPositionX", x);
		PlayerPrefs.SetFloat("checkpointPositionY", y);
		Debug.Log("Pillado el checkpoint");
	}


	public void PlayerDamaged()
	{
		animator.Play("Hit");

		SceneManager.LoadScene(SceneManager.GetActiveScene().name);	
	} 
}
