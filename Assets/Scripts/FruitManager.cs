using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FruitManager : MonoBehaviour
{
	public Text levelCleared;
	public GameObject transition;

	public void AllFruitsCollected()
	{
		if (transform.childCount==1)
		{
			Debug.Log("No quedan frutas, Victoria");
			transition.SetActive(true);
			
			levelCleared.gameObject.SetActive(true);
		}
	}
}
