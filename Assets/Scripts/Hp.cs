using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hp : MonoBehaviour
{
    [SerializeField] int hp = 5;

    public void TakeDamage(int attack){
        hp -= attack;
        if(hp <= 0){
            if(gameObject.CompareTag("Player")){
                SceneManager.LoadScene(0);
            }

            if(gameObject.GetComponent<Boss>()){
                int sceneTotal  = SceneManager.sceneCountInBuildSettings;
                int currentScene = SceneManager.GetActiveScene().buildIndex;
                if(currentScene < sceneTotal - 1){
                    SceneManager.LoadScene(++currentScene);
                }else{
                    SceneManager.LoadScene(0);
                }

            }
            Destroy(gameObject);
        }
    }
}
