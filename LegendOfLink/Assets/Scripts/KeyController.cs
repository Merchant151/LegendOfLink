using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    Sprite[] tiles;
    GameObject room;
    
    void Start()
    {
        //tiles = Resources.LoadAll<Sprite>("dungeonTiles");
        room = transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (room.GetComponent<RoomController>().roomClear)
        {
            this.GetComponent<SpriteRenderer>().enabled = true;
        }
        else
        {
            this.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
