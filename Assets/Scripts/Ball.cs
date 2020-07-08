using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
	[NonSerialized]
	public Rigidbody rb;
	
	void Awake()
	{
		rb = GetComponent<Rigidbody>();
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.collider.CompareTag("Hole"))
		{
			LevelManager.Instance.SpawnBall();
		}
		else if (collision.collider.CompareTag("Goal"))
		{
			LevelManager.Instance.FinishLevel();
		}
	}
}
