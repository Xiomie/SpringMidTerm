using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float startSpeed = 10f;

    public float speed;
    public event System.Action OnDeath;
    public float startHealth = 100;
    private float health;
    public int worth = 50;
    public GameObject deathEffect;
    public Image healthBar;
    private bool isDead = false;

    private void Start()
    {
        speed = startSpeed;
        health = startHealth;

    }
    public void TakeDamage(float amount)
    {
        health -= amount;
        healthBar.fillAmount = health / startHealth;

        if (health <= 0 && !isDead)
        {
            Die();
        }
    }
    public void Slow(float pct)
    {
        speed = startSpeed * (1f - pct);
    }

    void Die()
    {
        isDead = true;
        Debug.Log("Die");
        Player.Money += worth;

        if (OnDeath != null)
        {
            OnDeath();
        }

        Destroy(gameObject);
    }
}
