using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 dir;
    float speed;
    int attack;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 2f);
    }

    public void Initialize(Vector2 dir, float speed, int attack){
        this.dir = dir;
        this.speed = speed;
        this.attack = attack;
    }

    void FixedUpdate()
    {
        rb.velocity = dir * speed;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.GetComponent<Hp>()){
            other.gameObject.GetComponent<Hp>().TakeDamage(attack);
        }
        Destroy(gameObject);
    }
}
