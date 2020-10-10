using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    Rigidbody2D stoneRigidbody;
    private Player player;
    Vector2 moveDirection;

   
    void Start()
    {
        stoneRigidbody = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        moveDirection = (player.transform.position - transform.position).normalized * moveSpeed;
        stoneRigidbody.velocity = new Vector2(moveDirection.x, moveDirection.y);
        Destroy(gameObject, 3f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (stoneRigidbody.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            Destroy(gameObject);
        }
    }
}
