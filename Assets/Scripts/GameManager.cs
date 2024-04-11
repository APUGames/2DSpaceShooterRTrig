using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
   
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Text timer;
    [SerializeField] private Text gameOverText;
    [SerializeField] private Text titleText;
    [SerializeField] private Button restartButton;
    [SerializeField] private List<GameObject> enemies = new List<GameObject>();
    [SerializeField] private int initialWaveSize;
    [SerializeField] private GameObject titleScreen;
    private float spawnRate;
    public float timeLeft = 60f;
    public bool isGameActive;
    private Vector3 spawnPoint;


    private float xRange = 4;
    private float ySpawnPos = 8;

    public float minSpeed;
    public float maxSpeed;

    private Vector3 rSpawnPos;
    private Vector3 rForce;
    // Start is called before the first frame update
    void Start()
    {
        
      
    }

    // Update is called once per frame
    void Update()
    {
     
        TimeLeft();
    }

    public void TimeLeft()
    {
        if (isGameActive)
        {
            timeLeft -= Time.deltaTime;
            timer.text = "Time: " + (int)timeLeft;
        }
        if (timeLeft <= 0)
        {
            GameOver();
        }
    }


    public void StartGame(int difficulty)
    {
        // Find the GameObject with the Enemy script attached
        Debug.Log("Start game");
        GameObject enemyObject = GameObject.FindGameObjectWithTag("Enemy");

        spawnRate /= difficulty;
        gameOverText.gameObject.SetActive(false);
        isGameActive = true;

        /*
        titleText.gameObject.SetActive(true);
        InitializeEnemyWave(initialWaveSize);
        SpawnEnemy();
        */
   
        titleScreen.gameObject.SetActive(false);

    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        Debug.Log("Game Over");
        isGameActive = false;
        Time.timeScale = 0;

    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("Hit restart");
    }

    /*
   private void InitializeEnemyWave(int size)
   {

       for (int i = 0; i < size; i++)
       {
           Quaternion quaternion = Quaternion.Euler(0f, 0f, 0f);
           Vector3 up = new Vector3(0, 8);
           GameObject enemyObject = Instantiate(enemyPrefab,up,quaternion);

           enemies.Add(enemyObject);
           enemyObject.SetActive(true);
       }
   }

  private void SpawnEnemy()
   {

       if(isGameActive)
       {
           GameObject enemy = GetInactiveEnemy();

            rSpawnPos = Vector3.down * Random.Range(minSpeed, maxSpeed);
            rForce = new Vector3(UnityEngine.Random.Range(-xRange, xRange), ySpawnPos,0);

              // enemy.transform.position = rSpawnPos;
               enemy.GetComponent<Rigidbody2D>().velocity = rForce;
               enemy.SetActive(true);


       }

   }



   private GameObject GetInactiveEnemy()
   {
       foreach (GameObject enemyObject in enemies)
       {
           if (!enemyObject.activeInHierarchy)
           {
               return enemyObject;
           }
       }
       return null;
   }
   */


}
