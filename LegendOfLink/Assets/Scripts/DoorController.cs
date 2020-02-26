using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    /*GameObject s1, s2, s3, s4, s5;*/
    //for tile swapping the door
    Sprite[] tiles;
    GameObject room;

    // Start is called before the first frame update
    void Start()
    {
        /*s1 = GameObject.Find("s1");
        s2 = GameObject.Find("s2");
        s3 = GameObject.Find("s3");
        s4 = GameObject.Find("s4");
        s5 = GameObject.Find("s5");*/

        tiles = Resources.LoadAll<Sprite>("dungeonTiles");
        room = transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(room.GetComponent<RoomController>().roomClear)
        {
            this.GetComponent<SpriteRenderer>().sprite = tiles[346];
        }
        else
        {
            this.GetComponent<SpriteRenderer>().sprite = tiles[338];
        }
    }
}
