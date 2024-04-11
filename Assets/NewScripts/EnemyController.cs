using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // the speed of the enemy
    [SerializeField] float downSpeed = 2.0f;
    // the rang ethe eny can be in
    [SerializeField] float hRangeMax = 9f;
    [SerializeField] float hRangeMin = -9f;
    [SerializeField] float endz = -10.0f;

    private Vector2 startPos = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CheckRespawn();
    }

    private void Move()
    {
        // this is making the eny start in a position and use the down force 
        transform.position = new Vector2(transform.position.x, transform.position.y - downSpeed * Time.deltaTime);
    }

    private void CheckRespawn()
    {
        if(transform.position.y < endz)
        {
            // respawn the enemy at a random x location

            float newX =Random.Range(hRangeMin, hRangeMax);
            transform.position = new Vector2(newX, startPos.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.gameObject.CompareTag("Bullet"))
        {
            //Destroy(this.gameObject);
            Destroy(collision.gameObject);
     
        }

    }


}
