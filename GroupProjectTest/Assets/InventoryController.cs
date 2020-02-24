using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    Rigidbody2D mybod;
    public GameObject[] items;

    int emptySlot;
    int fullSlot;
    bool activeClock;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        items = new GameObject[5];

        mybod = gameObject.GetComponent<Rigidbody2D>();
        activeClock = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Timer
        if (activeClock)
        {
            timer += Time.deltaTime;
            if(timer > 1)
            {
                activeClock = false;
            }
        }

        //lol player controller for testing please remove.
        if (Input.GetKey("w"))
        {
            //Debug.Log("this is triggered");
            mybod.velocity = new Vector2(0, 2);
        } else if (Input.GetKey("s"))
        {
            mybod.velocity = new Vector2(0, -2);
        } else if (Input.GetKey("a"))
        {
            mybod.velocity = new Vector2(-2, 0);
        } else if (Input.GetKey("d"))
        {
            mybod.velocity = new Vector2(2, 0);
        } else
        {
            mybod.velocity = new Vector2(0, 0);
        }

        dropNextItem();
    }

    private void dropNextItem()
    {
        if (Input.GetKey("z")&&!activeClock)
        {
            StartClock();
            if (isEmpty(items))
            {
                items[fullSlot].transform.position = gameObject.transform.position;
                items[fullSlot].SetActive(true);
                items[fullSlot] = null;
            }
        }
    }

   private void StartClock()
    {
        activeClock = true;
        timer = 0;
    }
        private void OnTriggerStay2D(Collider2D collision)
        {
            //Debug.Log("Hey I bumped into something");
            if (collision.tag == "Item")
            {
                if (Input.GetKey("x"))
                {
                    if (isRoom(items))
                    {
                        GameObject item = collision.gameObject;
                        //Debug.Log("DEstroyed");
                        //Destroy(collision.gameObject);
                        item.SetActive(false);
                        items[emptySlot] = item;
                    }
                }
            }
        }
        private bool isRoom(GameObject[] myArray)
        {
            for (int i = 0; i < myArray.Length; i++)
            {
                if (myArray[i] == null)
                {
                    emptySlot = i;
                    return true;
                }
            }
            Debug.Log("Inventory full");
            return false;
        }
        private bool isEmpty(GameObject[] myArray)
        {
            for (int i = 0; i < myArray.Length; i++)
            {
                if (myArray[i] != null)
                {
                    fullSlot = i;
                    return true;
                }
            }
            Debug.Log("Inventory Empty");
            return false;
        }
    }

