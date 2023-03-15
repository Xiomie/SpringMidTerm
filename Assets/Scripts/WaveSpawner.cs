using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public static int EnemiesAlive = 0;

    public Wave[] waves;
    public Transform spawnPoint;
    public float timeBetweenWaves = 5f;
    private float countdown = 2f;
    public TextMeshProUGUI waveCountdownText;
    public GameManager gameManager;
    public GameObject enemyPrefab;
    private int waveIndex = 0;

    void Start()
    {
        EnemiesAlive = 0;
    }

    void Update()
    {
        if (EnemiesAlive > 0)
        {
            return;
        }

        if (waveIndex == waves.Length)
        {
            // gameManager.WinLevel();
            this.enabled = false;
            return;
        }

        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return;
        }

        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
        waveCountdownText.text = string.Format("{0:00.00}", countdown);
    }

    IEnumerator SpawnWave()
    {
        Player.Rounds++;

        Wave wave = waves[waveIndex];

        EnemiesAlive = wave.count;

        for (int i = 0; i < wave.count; i++)
        {
            GameObject enemy = Instantiate(wave.enemy, spawnPoint.position, spawnPoint.rotation);
            Enemy enemyScript = enemy.GetComponent<Enemy>();
            enemyScript.OnDeath += OnEnemyDeath;

            yield return new WaitForSeconds(1f / wave.rate);
        }

        waveIndex++;
    }

    void OnEnemyDeath()
    {
        EnemiesAlive--;
    }
}

