using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    float speed;
    bool isJumping;
    float jump_force;
    Animator animator;
    public ChatBoxController chatbox;
    void Start()
    {
        isJumping = false;
        speed = 5.0f;
        jump_force = 4.0f;
        animator = gameObject.GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(transform.position.x) > 8)
        {
            chatbox.id = 1;
            chatbox.text.text = "Want to EXIT?";
            chatbox.Open();
        }
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
            isJumping = true;
        }
        Move();
        if (Mathf.Abs(transform.position.x) > 100)
            Debug.Log("want to exit");
    }
    void Move()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        if (moveHorizontal > 0)
        {
            animator.SetInteger("Move", 1);
            transform.localScale = new Vector3(-1 * Mathf.Abs(transform.localScale.x), transform.localScale.y);
        }
        else if (moveHorizontal < 0)
        {
            animator.SetInteger("Move", 1);
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y);
        }
        else
            animator.SetInteger("Move", 0);

        GetComponent<Rigidbody2D>().velocity = new Vector2(moveHorizontal * speed, GetComponent<Rigidbody2D>().velocity.y);
    }
    void Jump()
    {
        animator.SetInteger("Jump", 1);
        Debug.Log("jump");
        if (!isJumping)
        {
            GetComponent<Rigidbody2D>().velocity += (Vector2.up * jump_force);
        }
    }

    void OnCollisionEnter2D()
    {
        isJumping = false;
        animator.SetInteger("Jump", 0);
    }

}
