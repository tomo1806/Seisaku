using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMove : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rigid2D;
    private Animator animator = null;
    //float walkForce = 2.0f;
    //float maxWalkSpeed = 2.0f;
    float walkForce;
    float maxWalkSpeed;
    float jumpForce = 450.0f;
    int key = 1;



    void Start()
    {
        this.rigid2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        animator.SetBool("Idle", true);
        animator.SetBool("Walk", false);
        animator.SetBool("Jump", false);
    }

    // Update is called once per frame
    void Update()
    {

            // プレイヤの速度
            float speedx = Mathf.Abs(this.rigid2D.velocity.x);

            // スピード制限
            if (speedx < this.maxWalkSpeed)
            {
                this.rigid2D.AddForce(transform.right * key * this.walkForce);
            }


        //if (Input.GetMouseButtonDown(0))
        //{
        //    var pos = transform.rotation;
        //    pos.y = 0;
        //    transform.rotation = pos;
        //}
    }
    private void OnTriggerEnter2D(Collider2D collision)//衝突したとき
    {
        if (collision.gameObject.tag == "Trampoline")
        {
            Invoke("JumpForce", 1f);
            Invoke("gen", 0.3f);

        }
        if(collision.gameObject.tag == "Block")
        {
            Invoke("move", 1.5f);
            //maxWalkSpeed = 2.0f;
            //walkForce = 2.0f;
        }
    }
    void JumpForce()
    {
        maxWalkSpeed = 0;
        this.rigid2D.AddForce(transform.up * this.jumpForce);
        animator.SetBool("Jump", true);
        //walkForce = 0.001f;
        //this.rigid2D.AddForce(transform.right * key * this.walkForce);

    }
    void gen()
    {
        maxWalkSpeed = 0;
        animator.SetBool("Walk", false);
    }
    void move()
    {
        maxWalkSpeed = 2.0f;
        walkForce = 2.0f;
        animator.SetBool("Walk", true);
        animator.SetBool("Jump", false);
        animator.SetBool("Idle", false);
    }
}
