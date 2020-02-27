using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchToggle : MonoBehaviour
{
    public bool on = false;
    //allows to be triggered
    public bool active = false;

    RoomController roomC;
    Sprite[] tiles;

    // Start is called before the first frame update
    void Start()
    {
        roomC = transform.root.GetComponent<RoomController>();

        //turn on first switch
        if (gameObject.name == "s1") active = true;
        //activate all targets
        if (gameObject.name == "target1" || gameObject.name == "target2" || gameObject.name == "target3") active = true;
        //activate first tile, reset tile
        if (gameObject.name == "t1" || gameObject.name == "reset") active = true;
        
        tiles = Resources.LoadAll<Sprite>("dungeonTiles");
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.name != "s1" && gameObject.name != "t1")
        {
            if (transform.parent.GetComponent<SwitchToggle>().on == true)
            {
                active = true;
            }
            else
            {
                active = false;
                on = false;
            }

        }

        if (transform.root.gameObject.name == "Room3")
        {
            if (on)
            {
                GetComponent<SpriteRenderer>().sprite = tiles[31];
            }
            else
            {
                GetComponent<SpriteRenderer>().sprite = tiles[44];
            }
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        //first room
        if (transform.root.name == "Room1")
        {
            if (active)
            {
                on = true;
                roomC.PlayStep();
            }
            else ResetRoom();
        }
        else
        {
            if (active && !on)
            {
                on = true;
                roomC.PlayStep();
            }
            else ResetRoom();
        }
    }

    //call reset as function
    private void ResetRoom()
    {
        if(gameObject.transform.root.name == "Room1")
        {
            roomC.gameObject.transform.Find("s1").GetComponent<SwitchToggle>().on = false;
        }
        else
        {
            roomC.gameObject.transform.Find("t1").GetComponent<SwitchToggle>().on = false;
        }
        roomC.ResetAlert();
    }
}
