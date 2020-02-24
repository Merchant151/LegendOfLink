using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    public int ItemID;
    public Color itemColor;
    SpriteRenderer myRen;

    // Start is called before the first frame update
    void Start()
    {
        myRen = gameObject.GetComponent<SpriteRenderer>();
        float r = (float)Random.Range(0, 255);
        //Debug.Log("float R = " + r);
        myRen.color = new Color(r/255, (float)Random.Range(0, 255) / 255, (float)Random.Range(0, 255) / 255);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
/*
    private void OnTriggerStay2D(Collider2D collision)
    {
        //Debug.Log("Hey I bumped into something");
        if (collision.tag == "Item")
        {
            if (Input.GetKey("x"))
            {
                Debug.Log("DEstroyed");
                Destroy(collision);
            }
        }
    }*/
}
