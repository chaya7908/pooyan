using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxFalling : MonoBehaviour {

    public float speed;
    public GameObject Baloon;
    public GameObject groundedDinos;
    public bool dead = false;
    public float jumpHeight = 1;

    Rigidbody2D myRigitBody;
    Transform myTransform;
    Animator myAnimator;

    // Use this for initialization
    void Start()
    {
        myRigitBody = GetComponent<Rigidbody2D>();
        myTransform = GetComponent<Transform>();
        myAnimator = GetComponent<Animator>();

        jumpHeight += myTransform.position.y;
        //jump up
        myRigitBody.velocity = Vector2.up * speed * 2;
    }

    // Update is called once per frame
    void Update()
    {
        //fall down
        if (myTransform.position.y >= jumpHeight)
        {
            Baloon.active = true;
            Debug.Log("here");
            myRigitBody.velocity = Vector2.down * speed;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            if (dead)
            {
                Destroy(gameObject);
            }
            else
            {
                Instantiate(groundedDinos, myTransform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }

    public void handleDeath()
    {
        dead = true;
        myAnimator.SetTrigger("Dead");
        myRigitBody.velocity = Vector2.down * speed * 4f;
    }
}
