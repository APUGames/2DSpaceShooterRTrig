using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float upForce;
    [SerializeField] private int health;
    [SerializeField] private int score;

    

    private float horizontalInput;
    private float verticalInput;
    //Sprite rigidbody2D
    private Rigidbody2D player;

    [SerializeField] private Text scoreText;

    // collider for raycasting
    private BoxCollider2D boxCollider;
    private GameManager gameManager;

    private void Awake()
    {
        player = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        if (gameManager.isGameActive)
        {
            horizontalInput = Input.GetAxis("Horizontal");
            verticalInput = Input.GetAxis("Vertical");

            player.velocity = new Vector2(horizontalInput * speed, verticalInput * upForce);
        }



       

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(1); // Damage amount

        }
    }


    public void TakeDamage(int damage)
    {
        health -= damage;
        // this will update the UI
        Debug.Log("Health: " + health);

        if(damage>= health)
        {
            gameManager.GameOver();
        }
    }

    public void IncreaseScore(int points)
    {
        score += points;
        // Update score UI or trigger effects
        score++;
        scoreText.text = score.ToString();
        scoreText.text = "Score: " + score;
    }
}
