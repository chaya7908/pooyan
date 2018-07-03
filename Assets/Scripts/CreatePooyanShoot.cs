using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePooyanShoot : MonoBehaviour {

    public GameObject shoot;
    public Transform spawnPoint;
    public float rateOfFire = 0.5f;
    private float timer = 0;

    // Use this for initialization
    void Start()
    {
        timer = rateOfFire;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (Input.GetKey(KeyCode.Space))
        {
            if (timer >= rateOfFire)
            {
                Instantiate(shoot, spawnPoint.position, Quaternion.identity);
                timer = 0;
            }
        }
    }
}
