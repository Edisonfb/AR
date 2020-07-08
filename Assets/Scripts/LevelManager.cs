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
	public Transform spawnPoint;

	public GameObject imageTarget;
	public GameObject[] levels;
	public int levelIndex = -1;

	public static LevelManager Instance;

	private void Start()
	{
		if (!Instance)
		{
			Instance = this;
		}

		foreach (var level in levels)
		{
			level.gameObject.SetActive(false);
		}

		FinishLevel();
		SpawnBall();
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
			ball = Instantiate(ballPrefab, spawnPoint.position, Quaternion.identity);
			return;
		}

		ball.transform.position = spawnPoint.position;
		ball.rb.velocity = Vector3.zero;
	}

	public void FinishLevel()
	{
		//SceneManager.LoadScene(++levelIndex);

		if (levelIndex >= 0)
		{
			levels[levelIndex].gameObject.SetActive(false);
		}
		levelIndex++;
		if (levelIndex < levels.Length)
		{
			levels[levelIndex].gameObject.SetActive(true);
		}
	}
}
