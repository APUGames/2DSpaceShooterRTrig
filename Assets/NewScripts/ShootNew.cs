using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootNew : MonoBehaviour
{
    public GameObject bullet;
    public Transform firePoint;


    // this is for the bullet cooldown
    [SerializeField] private float attackCooldown;
    private float cooldownTimer = Mathf.Infinity;

    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        cooldownTimer += Time.deltaTime;



        if (Input.GetKeyDown(KeyCode.Space) && cooldownTimer > attackCooldown)
        {
            shoot();
        }
    }

    private void shoot()
    {
        cooldownTimer = 0;
        Quaternion quaternion = Quaternion.Euler(0, 0, 0);
        Instantiate(bullet, firePoint.position, quaternion);
    }
}
