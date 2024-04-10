using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D enemyRb;

 
    private bool hit = false;
    private float lifetime;
    private float xRange = 4;
    private float ySpawnPos = 8;

    public float minSpeed;
    public float maxSpeed;

    [SerializeField] private Vector3 startPos = Vector3.zero;

    [SerializeField] private float endZ = -10.0f;
    private void Awake()
    {
       
        enemyRb = GetComponent<Rigidbody2D>();
       // enemyRb.AddForce(Randomforce(), ForceMode2D.Impulse);
        //transform.position = RandomSpawnPos();
        


    }
    void Update()
    {
        SpawnPos();
        RandomPos();
        
    }

    
  
   public  void RandomPos()
    {
        if(transform.position.y < endZ)
        {
            float newX = Random.Range(-xRange, xRange);
            transform.position = new Vector3(newX, startPos.y);
        }
    }

    private void SpawnPos()
    {
        //float downSpeed = Random.Range(minSpeed, maxSpeed);
        float downSpeed = 1;
        transform.position = new Vector3(transform.position.x, transform.position.y - (downSpeed *Time.deltaTime));
        
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.gameObject.CompareTag("Bullet"))
        {
            hit = true;
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }
      
    }
    private void Deactivate()
    {
        lifetime = 0f;
       // gameObject.SetActive(false);
    }


}
