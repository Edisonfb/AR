using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
	public GameObject panel;

	[SerializeField]
	private Ball ballPrefab;
	public Ball ball;

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

		panel.SetActive(false);
		StartLevel();
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

		ball.gameObject.SetActive(true);
		ball.transform.position = levels[currentLevel].spawnPoint.position;
		ball.rb.velocity = Vector3.zero;
	}

	public void FinishLevel()
	{
		panel.SetActive(true);
	}

	public void StartLevel()
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
		}
	}
}