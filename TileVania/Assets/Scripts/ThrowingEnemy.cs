using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingEnemy : MonoBehaviour
{
    [SerializeField] float fireRate = 1f;
    [SerializeField] float rotationSpeed = 5f;
    [SerializeField] GameObject projectile;
    
    float nextFire;
    Player player;
    
    

    // Start is called before the first frame update
    void Start()
    {
        nextFire = Time.time;
        player = FindObjectOfType<Player>();
        
    }

    // Update is called once per frame
    void Update()
    {
        TurnToPlayer();
        CheckIfTimeToFire(); // TODO rework to animation event with player proximity trigger
    }

    private void TurnToPlayer()
    {
        if (player.transform.position.x <= transform.position.x)
        {
            transform.localScale = new Vector2(1, 1);
        }
        else
        {
            transform.localScale = new Vector2(-1, 1);
        }
    }

    private void CheckIfTimeToFire()
    {
        if (Time.time > nextFire)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            nextFire = Time.time + fireRate;
        }
    }
}
