using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class projectile : MonoBehaviour
{
    [SerializeField] private float speed;
    private float direction;
    private bool hit = false;
    private float lifetime;
    
    private BoxCollider2D boxCollider;
    private PlayerController playerController;
    [SerializeField] private float bottomInstanstiatePos;
   
   

    // Start is called before the first frame update
    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        playerController = FindObjectOfType<PlayerController>();
       
    }


    // Update is called once per frame
    private void Update()
    {

        if (hit) return;
        float movementSpeed = speed * Time.deltaTime * direction;
        // Move the projectile directly instead of using Transform.Translate
        transform.position += transform.up * speed * Time.deltaTime;


        // Update lifetime
        lifetime += Time.deltaTime;

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

    public void setDirection(float directionX)
    {
        //set the lifetime of the bullet back to zero
        lifetime = 0;
        // sets the direction of the bullet
        transform.up = new Vector3(0, directionX, 0);
        gameObject.SetActive(true);
        hit = false;
        boxCollider.enabled = true;

        
    }
    private void Deactivate()
    {
        lifetime = 0f;
        gameObject.SetActive(false);
    }


}
