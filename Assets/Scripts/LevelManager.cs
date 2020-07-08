using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Experimental.AI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
	[SerializeField]
	private Ball ballPrefab;
	private Ball ball;

	public Level[] levels;
	public int currentLevel = -1;

	public static LevelManager Instance;

	public float levelHeight = 1;

	private void Start()
	{
		if (!Instance)
		{
			Instance = this;
		}

		foreach (var level in levels)
		{
			level.gameObject.SetActive(false);
			level.transform.position = Vector3.up * levelHeight;
		}

		FinishLevel();

	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			FinishLevel();
		}
	}

	public void SpawnBall()
	{
		if (!ball)
		{
			ball = Instantiate(
				ballPrefab, 
				levels[currentLevel].spawnPoint.position, 
				Quaternion.identity
			);

			return;
		}

		ball.transform.position = levels[currentLevel].spawnPoint.position;
		ball.rb.velocity = Vector3.zero;
	}

	public void FinishLevel()
	{
		//SceneManager.LoadScene(++levelIndex);

		if (currentLevel >= 0)
		{
			levels[currentLevel].gameObject.SetActive(false);
		}
		currentLevel++;
		if (currentLevel < levels.Length)
		{
			levels[currentLevel].gameObject.SetActive(true);
			SpawnBall();
		}
	}
}
