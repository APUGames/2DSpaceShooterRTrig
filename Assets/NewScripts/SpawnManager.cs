using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;

    public Vector2[] spawnPoints;

    [SerializeField] private float qTime = 2.0f;
    private float currentQTime;
    private const int maxEnemies = 10;
    // Start is called before the first frame update
    void Start()
    {
        currentQTime = qTime;
    }

    // Update is called once per frame
    void Update()
    {
        GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        Debug.Log("Got game manager");
        if (gameManager.isGameActive)
        {
            Debug.Log("game is acive");
            if (currentQTime < 0.0f)
            {
                int spawnPosIndex = Random.Range(0, spawnPoints.Length);
                Vector3 spawnPos = spawnPoints[spawnPosIndex];
                Quaternion quaternion = Quaternion.Euler(0f, 0f, 0f);
                 GameObject enemy = Instantiate(enemyPrefab, spawnPos, quaternion);
                currentQTime = qTime;
            }
            else
            {
                currentQTime -= Time.deltaTime;
            }
        }
    }
}
