using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rb;
    int attack;
    float speed;

    public void Initialize(int attack, float speed){
        this.attack = attack;
        this.speed = speed;
    }
    void Start(){
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 1f);
    }
    void Update(){
        rb.velocity = new Vector2(speed,0f);
    }
    void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.GetComponent<Hp>()){
            other.gameObject.GetComponent<Hp>().TakeDamage(attack);
        }
        Destroy(gameObject);
    }
}
