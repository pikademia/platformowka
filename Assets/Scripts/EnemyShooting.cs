using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    Transform player;
    [SerializeField] GameObject prefab;
    [SerializeField] Transform aim;
    [SerializeField] float bulletSpeed = 2f;
    [SerializeField] float shootingDelay = 1f;
    [SerializeField] int attack = 1;
    float timer;
    void Start(){
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timer = shootingDelay;
    }
    void Update(){
        if(player){
            if(Mathf.Abs(player.position.x - transform.position.x) < 14f){
                timer -= Time.deltaTime;
                if(timer <= 0){
                    Shoot();
                    timer = shootingDelay;
                }
            }
        }
    }
    void Shoot(){
        GameObject bullet = Instantiate(prefab, aim.position, Quaternion.identity);
        bullet.GetComponent<EnemyBullet>().Initialize(aim.position - transform.position, bulletSpeed, attack);
    }
}
