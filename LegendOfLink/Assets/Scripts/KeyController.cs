using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    RoomController roomC;
    
    void Start()
    {
        roomC = transform.root.GetComponent<RoomController>();
        roomC.RoomClear();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (room.GetComponent<RoomController>().roomClear)
        {
            this.GetComponent<SpriteRenderer>().enabled = true;
        }
        else
        {
            this.GetComponent<SpriteRenderer>().enabled = false;
        }*/
    }
}
