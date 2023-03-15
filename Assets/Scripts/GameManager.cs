using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public static bool GameIsOver;

	public GameObject gameOverUI;
	public GameObject completeLevelUI;

	void Start()
	{
		GameIsOver = false;
	}

	// Update is called once per frame
	void Update()
	{
		if (GameIsOver)
			return;

		if (Player.Lives <= 0)
		{
			SceneManager.LoadScene("DeathScreen");
		}

	}

	void EndGame()
	{
		SceneManager.LoadScene("DeathScreen");
	}

	public void WinLevel()
	{
		GameIsOver = true;
		SceneManager.LoadScene("VictoryScreen");
	}
}
