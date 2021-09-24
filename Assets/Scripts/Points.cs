using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Points : MonoBehaviour
{
    [SerializeField] Text txtPoints;
    int points = 0;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("point")){
            points++;
            txtPoints.text = points.ToString();
            Destroy(other.gameObject);
        }
    }
}
