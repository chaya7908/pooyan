using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxGrounded : MonoBehaviour {

    public float walkingSpeed;
    Rigidbody2D myRigitBody;

    // Use this for initialization
    void Start () {

        myRigitBody = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        myRigitBody.velocity = Vector3.right * walkingSpeed;
    }
}
