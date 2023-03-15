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
			EndGame();
		}
	}

	void EndGame()
	{
		
	}

	public void WinLevel()
	{
		GameIsOver = true;
		completeLevelUI.SetActive(true);
	}
}
