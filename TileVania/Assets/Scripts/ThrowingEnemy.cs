﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingEnemy : MonoBehaviour
{
    [SerializeField] float fireRate = 1f;
    [SerializeField] float rotationSpeed = 5f;
    [SerializeField] GameObject projectile;
    [SerializeField] GameObject gun;
    [SerializeField] float fireRange = 10f;
    
    
    Player player;
    Animator animator;
    
    

    // Start is called before the first frame update
    void Start()
    {        
        player = FindObjectOfType<Player>();
        animator = GetComponent<Animator>();        
    }

    // Update is called once per frame
    void Update()
    {
        TurnToPlayer();
        CheckIfInRangeToFire(); 
    }

    private void CheckIfInRangeToFire()
    {
        if(Vector3.Distance(player.transform.position, transform.position) < fireRange)
        {
            animator.SetBool("Attacking", true);
        }
        else
        {
            animator.SetBool("Attacking", false);
        }
    }
    public void Fire()
    {
        Instantiate(projectile, gun.transform.position, transform.rotation);
        
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
        
}
