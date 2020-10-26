using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    private Animator animator = null;
    Rigidbody2D rigid2D;

    // Start is called before the first frame update
    void Start()
    {
        this.rigid2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        animator.SetBool("Stay", true);
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKey("d"))
        //{
        //    animator.SetBool("Stay", false);
        //    animator.SetBool("Jump", true);
        //    Invoke("Stay", 0.5f);
        //}
        //if (Input.GetKeyDown(KeyCode.UpArrow))
        //{
        //    animator.Play("TrampolineAnimation");
        //}
    }
    void Stay()
    {
        animator.SetBool("Jump", false);
        animator.SetBool("Stay", true);
    }
    void Jump()
    {
        animator.SetBool("Jump", true);
        Invoke("Stay", 0.7f);
    }
    private void OnTriggerEnter2D(Collider2D collision)//衝突したとき
    {
        if (collision.gameObject.tag == "Player")
        {
            animator.SetBool("Stay", false);
            Invoke("Jump", 0.8f);
        }
    }

}
