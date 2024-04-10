using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Attack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] bullets;
  


  
    private float cooldownTimer = Mathf.Infinity;


    // Update is called once per frame
    private void Update()
    {
        cooldownTimer += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space) && cooldownTimer > attackCooldown)
        {
            
        }
    }

    private void Shoot()
    {
        cooldownTimer = 0;
        // resets the position of the fire ball to the firepoint
        bullets[FindBullet()].transform.position = firePoint.position;
        // this makes the fireball shoot
        bullet.GetComponent<projectile>().setDirection(1f);
    }

    private int FindBullet()
    {
        for (int i = 0; i < bullets.Length; i++)
        {
            // this checks if the bullet is active in the hierarchy
            if (!bullets[i].activeInHierarchy)
            {
                // this means that if the object(integer) in the array is not active, the code will allow it to be used.
                return i;
            }
        }
        return 0;
    }


}
