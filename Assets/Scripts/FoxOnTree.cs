using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxOnTree : MonoBehaviour
{

    public Transform min;
    public Transform max;
    public float walkingSpeed;
    public GameObject fallingDinos;

    Rigidbody2D myRigitBody;
    Transform myTransform;
    SpriteRenderer mySpriteRenderer;
    float stopLocation;

    // Use this for initialization
    void Start()
    {
        myRigitBody = GetComponent<Rigidbody2D>();
        myTransform = GetComponent<Transform>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        stopLocation = Random.Range(min.position.x, max.position.x);
    }

    // Update is called once per frame
    void Update()
    {
        myRigitBody.velocity = Vector3.right * walkingSpeed;
        if (myTransform.position.x >= stopLocation)
        {
            myRigitBody.velocity = Vector3.zero;
            Instantiate(fallingDinos, myTransform.position, Quaternion.identity);
            fallingDinos.GetComponent<SpriteRenderer>().sortingOrder += mySpriteRenderer.sortingOrder;
            Destroy(gameObject, 0);
        }
    }
}
