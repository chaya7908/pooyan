using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateEnemy : MonoBehaviour {

    public GameObject treeDinos;
    public Transform spawnPoint;
    public Transform min;
    public Transform max;

    public float delay;
    public int enemiesNumber;

    float timer = 0;

    // Use this for initialization
    void Start () {
        timer = Random.Range(0, delay);
    }
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            if (enemiesNumber-- == 0)
            {
                Destroy(this);
                return;
            }
            Instantiate(treeDinos, spawnPoint.position, Quaternion.identity);
            treeDinos.GetComponent<FoxOnTree>().min = min;
            treeDinos.GetComponent<FoxOnTree>().max = max;
            treeDinos.GetComponent<SpriteRenderer>().sortingOrder += enemiesNumber;
            timer = Random.Range(0, delay * 2);
        }
    }
}
