using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PooyanMovement : MonoBehaviour {

    public Transform minHeghit;
    public Transform maxHeghit;
    public float speed = 5;
    private Transform myTransform;

    // Use this for initialization
    void Start () {
        myTransform = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        float inputY = Input.GetAxis("Vertical");
        float yPosition = Mathf.Clamp(myTransform.position.y + (inputY * speed * Time.deltaTime), minHeghit.position.y, maxHeghit.position.y);
        myTransform.position = new Vector2(myTransform.position.x, yPosition);
	}
}
