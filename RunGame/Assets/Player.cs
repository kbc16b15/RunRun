using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public float movespeed = 2.0f;     //移動速度
                                       //Rigidbody rb;
    Vector2 pre_input;
    Animator animator;
    CharacterController chaCon;
    float moveSpeed = 5.0f;
    float jumpSpeed = 0.0f;
    // Use this for initialization
    void Start() {
        //rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        chaCon = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update() {
        float xSpeed = Input.GetAxisRaw("Horizontal");

        if (xSpeed > .1 ) //(移動入力があると)
        {
            animator.SetFloat("Speed", 1f); //キャラ走行のアニメーションON
            xSpeed = 0.07f;
        }
        else if(xSpeed < -.1)
        {
            animator.SetFloat("Speed", -1f); //キャラ走行のアニメーションON
            xSpeed = -0.07f;
        }
        else    //(移動入力が無いと)
        {
            animator.SetFloat("Speed", 0f); //キャラ走行のアニメーションOFF
            xSpeed = 0.0f;
        }

       

       
        if (chaCon.isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                jumpSpeed = 0.1f;
                animator.SetBool("Jump",true);
                animator.SetFloat("JumpHeight", jumpSpeed);
            }else
            {
                jumpSpeed = 0.0f;
                animator.SetBool("Jump",false);
                animator.SetFloat("JumpHeight", jumpSpeed);
            }
        }
        Vector3 speed=new Vector3 ( xSpeed, jumpSpeed, 0 );
        
        chaCon.Move(speed);
        //jumpSpeed = 0;
        //キー入力
        //Vector2 input = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
    }
}