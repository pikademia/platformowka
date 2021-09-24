using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float jumpForce = 3500f;
    Rigidbody2D rb;
    float dirX;
    float moveSpeed = 10f;
    bool jumpBtnPressed = false;
    bool isGrounded = false;
    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update() {
        dirX = Input.GetAxisRaw("Horizontal");
        if(Input.GetButtonDown("Jump") && isGrounded){
            jumpBtnPressed = true;
        }
    }

    void FixedUpdate(){
        rb.velocity = new Vector2(moveSpeed * dirX, rb.velocity.y);
        if(jumpBtnPressed){
            rb.AddForce(new Vector2(0f,jumpForce),ForceMode2D.Impulse);
            jumpBtnPressed = false;
            isGrounded = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D other) {
        isGrounded = true;
        if(other.gameObject.CompareTag("Enemies")){
            SceneManager.LoadScene(0);
        }
    }

    public void Move(int direction){
        dirX = direction;
    }

    public void Jump(){
        if(isGrounded){
            jumpBtnPressed = true;
        }
    }
}
