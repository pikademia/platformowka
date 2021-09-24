using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform target;
    Vector3 offset = new Vector3(4f,2f,-10);

    private void FixedUpdate() {
        MoveXRightSmooth();
    }

    void MoveXandY(){
        transform.position = target.position + offset;
    }

    void MoveXOnly(){
        transform.position = new Vector3(target.position.x + offset.x, transform.position.y, transform.position.z);
    }

    void MoveXRight(){
        if(target.position.x > transform.position.x - offset.x){
            transform.position = new Vector3(target.position.x + offset.x, transform.position.y, transform.position.z);
        }
    }
    void MoveXRightSmooth(){
        if(target.position.x > transform.position.x - offset.x){
            transform.position = Vector3.Lerp(transform.position, new Vector3(target.position.x + offset.x, transform.position.y, transform.position.z), 0.1f);
        }
    }
}
