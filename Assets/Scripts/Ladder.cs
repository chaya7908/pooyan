using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{

    public Transform ladder1;
    public Transform ladder2;
    public Transform ladder3;
    public Transform ladder4;

    public GameObject laddeeFox;

    int numberOfLadders = 4;
    List<Vector2> ladders;
    Transform myTransform;

    // Use this for initialization
    void Start()
    {
        myTransform = GetComponent<Transform>();
        ladders = new List<Vector2>() { ladder1.position, ladder2.position, ladder3.position, ladder4.position };
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fox"))
        {
            if (numberOfLadders > 0)
            {
                Destroy(collision.gameObject);
                Instantiate(laddeeFox, ladders.ToArray()[ladders.Count - numberOfLadders], Quaternion.identity, myTransform);
                numberOfLadders--;
            }
        }
    }
}
