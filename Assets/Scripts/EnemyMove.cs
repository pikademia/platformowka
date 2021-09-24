using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] Transform loc1, loc2;
    [SerializeField] float speed = 3f;
    [SerializeField] float waitTime = 1f;
    Vector3 target;
    float timer;

    private void Start() {
        timer = waitTime;
        target = loc1.position;
    }

    private void Update() {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(target.x, transform.position.y, transform.position.z), Time.deltaTime*speed);

        if(Mathf.Abs(transform.position.x - target.x) < 0.001f){
            timer -= Time.deltaTime;
            if(timer <= 0){
                if(target == loc1.position){
                    target = loc2.position;
                    transform.localScale = new Vector3(-1f,1f,1f);
                }else{
                    target = loc1.position;
                    transform.localScale = new Vector3(1f,1f,1f);
                }
                timer = waitTime;
            }
        }
    }
}
