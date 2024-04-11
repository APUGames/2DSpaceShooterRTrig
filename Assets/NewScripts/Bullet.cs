using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // I need to call these
    private BoxCollider2D boxCollider;
    private PlayerController playerController;

    //the bool to check whether the hit function is true
    public bool hit = false;

    // this sets the lifetime of the bullet so that itr will be destroyed after a certain amount of time.
    private float lifetime;

    public float ScreenPosY;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        // These lines call the objects
        boxCollider = GetComponent<BoxCollider2D>();
        playerController = FindObjectOfType<PlayerController>();


       
        if (transform.position.y > ScreenPosY)
         {
             Destroy(gameObject);
         }
        
    }
    // Update is called once per frame
    void Update()
    {
        // Update lifetime
        lifetime += Time.deltaTime;

        transform.Translate(speed * Time.deltaTime * Vector2.up);

        // Deactivate after a certain lifetime
        if (lifetime > 5)
        {
            Deactivate();
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {


        if (other.gameObject.CompareTag("Enemy"))
        {
            hit = true;
            playerController.IncreaseScore(1);
            Deactivate();
        }

    }

    private void Deactivate()
    {

       gameObject.SetActive(false);
    }
}
