using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    Animator bossAnim;

    Rigidbody bossBody;
    BoxCollider weakPoint;
    public AudioClip bossHit;

    AudioSource bossTakeDamage;

    int bossHitPoints = 100;

    float xLeftBounds = -23.38f; //-24.88
    float xRightBounds = -10.48f; //-9.88
    float yUpBounds = 19.9f; //18.9
    float yDownBounds = 10.9f; //14.9

    float waitTime;
    bool tailMove = false;
    float randomMovement;
    float h;
    float v;
    float speed = 2.5f;

    // Start is called before the first frame update
    void Start()
    {
        bossAnim = GetComponent<Animator>();
        
        bossBody = GetComponent<Rigidbody>();
        weakPoint = GetComponent<BoxCollider>();
        bossTakeDamage = GetComponent<AudioSource>();

        InvokeRepeating("MoveBoss", 4, Random.Range(2, 4));
    }

    // Update is called once per frame
    void Update()
    {
        weakPoint.tag = "BossWeakPoint";
        bossAnim.SetFloat("HAXIS", h);
        bossAnim.SetFloat("VAXIS", v);
        if (h < 0)
        {
            bossBody.transform.Translate(Vector2.left * -h * speed * Time.deltaTime);
            if(transform.position.x >= xRightBounds || transform.position.x <= xLeftBounds)
            {
                h *= -1;
            }
        }

        else if(h > 0)
        {
            bossBody.transform.Translate(Vector2.right * h * speed * Time.deltaTime);
            if (transform.position.x >= xRightBounds || transform.position.x <= xLeftBounds)
            {
                h *= -1;
            }
        }

        else
        {

        }

        if(v < 0)
        {
            bossBody.transform.Translate(Vector2.down * -v * speed * Time.deltaTime);
            if (transform.position.y >= yUpBounds || transform.position.y <= yDownBounds)
            {
                v *= -1;
            }
        }

        else if(v > 0)
        {
            bossBody.transform.Translate(Vector2.up * v * speed * Time.deltaTime);
            if (transform.position.y >= yUpBounds || transform.position.y <= yDownBounds)
            {
                v *= -1;
            }
        }

        else
        {

        }

        if(bossHitPoints <= 0)
        {
            Destroy(gameObject);
        }

        
    }

    void MoveBoss()
    {
        randomMovement = Random.Range(0, 2);
        if(randomMovement == 0)
        {
            v = 0;
            Vector2 moveLeftOrRight = bossBody.velocity;
            h = Random.Range(-1, 2);
            moveLeftOrRight.x = h;
            print(h);
        }

        else if(randomMovement == 1)
        {
            h = 0;
            Vector2 moveUpOrDown = bossBody.velocity;
            v = Random.Range(-1, 2);
            moveUpOrDown.y = v;
            print(v);
        }
        else
        {
            
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        bossHitPoints -= 5;
        print(bossHitPoints);
        if (bossHitPoints > 0)
        {
            bossTakeDamage.PlayOneShot(bossHit);
        }
        else
        {

        }
    }
}
