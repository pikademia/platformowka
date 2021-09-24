using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] int attack = 2;
    [SerializeField] float speed = 20f;
    private void Update() {
        if(Input.GetButtonDown("Fire1")){
            Shoot();
        }
    }
    public void Shoot(){
        GameObject bullet = Instantiate(prefab, new Vector3(transform.position.x + 1.5f, transform.position.y, 0), Quaternion.identity);
        bullet.GetComponent<Bullet>().Initialize(attack, speed);
    }
}
