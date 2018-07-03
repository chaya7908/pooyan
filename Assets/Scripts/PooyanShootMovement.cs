using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PooyanShootMovement : MonoBehaviour
{

    public float speed = 5;
    Rigidbody2D myRigitBody;
    Transform myTransform;

    bool down = false;

    // Use this for initialization
    void Start()
    {
        myRigitBody = GetComponent<Rigidbody2D>();
        myTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!down)
            myRigitBody.velocity = Vector3.left * speed;
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fox"))
        {
            down = true;
            myRigitBody.velocity = Vector3.down * speed / 1.5f;
            myTransform.Rotate(0, 0, 90);
        }
    }
}
