using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    Animator bossAnim;
    Rigidbody2D bossBody;
    BoxCollider2D weakPoint;

    int bossHitPoints = 100;

    float xLeftBounds = -7.5f;
    float xRightBounds = 7.5f;
    float yUpBounds = 2.5f;
    float yDownBounds = -1.5f;

    float waitTime;

    float randomMovement;
    float h;
    float v;
    float speed = 2.5f;

    // Start is called before the first frame update
    void Start()
    {
        bossAnim = GetComponent<Animator>();
        bossBody = GetComponent<Rigidbody2D>();
        weakPoint = GetComponent<BoxCollider2D>();

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
}
