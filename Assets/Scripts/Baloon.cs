using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baloon : MonoBehaviour {

    public GameObject dinos;
    public Transform baloonLocation;
    public AudioSource hitSFX;

    public Sprite redBaloon;
    public Sprite orangeBaloon;
    public Sprite greenBaloon;

    public Animator redBaloonAnimator;
    public Animator greenBaloonAnimator;
    public Animator orangeBaloonAnimator;

    SpriteRenderer mySpriteRenderer;
    Transform myTransform;
    Animator myAnimator;

    float lerpValue = 0;
    Vector2 currentPosition;

    int numberOfDamages = 0;
    // Use this for initialization
    void Start()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        myTransform = GetComponent<Transform>();
        myAnimator = GetComponent<Animator>();

        numberOfDamages = Random.Range(0, 3);
        setColor();
        currentPosition = myTransform.position;
    }

    void Update()
    {   
        lerpValue += Time.deltaTime / 3;
        currentPosition.x = Mathf.Lerp(currentPosition.x, baloonLocation.position.x, lerpValue);
        currentPosition.y = Mathf.Lerp(currentPosition.y, baloonLocation.position.y, lerpValue);
        myTransform.position = new Vector2(currentPosition.x, currentPosition.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Dart"))
        {
            Destroy(collision.gameObject);
            numberOfDamages++;

            setColor();
            if (numberOfDamages == 3)
            {
                myAnimator.SetTrigger("Bomb");
                hitSFX.Play();
                Destroy(gameObject, 0.5f);
                dinos.GetComponent<FoxFalling>().handleDeath();
            }
        }
    }

    void setColor()
    {
        Sprite sprite;
        RuntimeAnimatorController animator;

        switch (numberOfDamages)
        {
            case 0:
                animator = greenBaloonAnimator.runtimeAnimatorController;
                sprite = greenBaloon;
                break;
            case 1:
                animator = orangeBaloonAnimator.runtimeAnimatorController;
                sprite = orangeBaloon;
                break;
            default:
                animator = redBaloonAnimator.runtimeAnimatorController;
                sprite = redBaloon;
                break;
        }
        mySpriteRenderer.sprite = sprite;
        myAnimator.runtimeAnimatorController = animator;
    }
}
