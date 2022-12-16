using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drive : MonoBehaviour
{
    public float speed = 5f;
    public float rotationSpeed = 100.0f;
    Animator anim;
    public static GameObject controlledBy;


    void Start()
    {
        anim = this.GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if(controlledBy != null) return;
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        translation *= Time.fixedDeltaTime;
        rotation *= Time.fixedDeltaTime;
        transform.Translate(0, 0, translation);
        transform.Rotate(0, rotation, 0);

        if (translation > 0 && Input.GetKey(KeyCode.LeftShift))
        {
            anim.SetBool("isRunning", true);
            anim.SetBool("isWalking", true);
            anim.SetBool("isJumping", false);
            anim.SetFloat("botSpeed", 1);
            if (Input.GetKey(KeyCode.Space))
            {
                anim.SetBool("isJumping", true);
                anim.SetBool("isWalking", false);
                anim.SetBool("isRunning", true);
                anim.SetFloat("botSpeed", 1);
            }
        }
        else if (translation < 0 && Input.GetKey(KeyCode.LeftShift))
        {
            anim.SetBool("isRunning", true);
            anim.SetBool("isWalking", true);
            anim.SetBool("isJumping", false);
            anim.SetFloat("botSpeed", -1);
            if (Input.GetKey(KeyCode.Space))
            {
                anim.SetBool("isJumping", true);
                anim.SetBool("isWalking", false);
                anim.SetBool("isRunning", true);
                anim.SetFloat("botSpeed", -1);
            }
        }
        else if (translation == 0 && Input.GetKey(KeyCode.Space))
        {
            anim.SetBool("isJumping", true);
            anim.SetBool("isWalking", false);
            anim.SetBool("isRunning", false);
            anim.SetFloat("botSpeed", translation);
        }

        else if (translation < 0)
        {
            anim.SetBool("isWalking", true);
            anim.SetBool("isRunning", false);
            anim.SetBool("isJumping", false);
            anim.SetFloat("botSpeed", -1);
            if (Input.GetKey(KeyCode.Space))
            {
                anim.SetBool("isJumping", true);
                anim.SetBool("isWalking", true);
                anim.SetBool("isRunning", false);
                anim.SetFloat("botSpeed", -1);
            }
        }
        else if (translation > 0)
        {
            anim.SetBool("isWalking", true);
            anim.SetBool("isRunning", false);
            anim.SetBool("isJumping", false);
            anim.SetFloat("botSpeed", 1);
            if (Input.GetKey(KeyCode.Space))
            {
                anim.SetBool("isJumping", true);
                anim.SetBool("isWalking", true);
                anim.SetBool("isRunning", false);
                anim.SetFloat("botSpeed", 1);
            }
        }
        else
        {
            anim.SetBool("isRunning", false);
            anim.SetBool("isWalking", false);
            anim.SetBool("isJumping", false);
            anim.SetFloat("botSpeed", 0);
        }

        

    }

}
