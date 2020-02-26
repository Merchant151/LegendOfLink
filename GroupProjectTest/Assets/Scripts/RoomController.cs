using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour
{
    public int roomType;//1 for ordered switches, 2 for targets -  deprecated room type, 3 for path
    //1 - need final switch to check
    GameObject lastSwitch, rootSwitch;
    //need last switch in path
    GameObject[] tiles;

    //door, in case is needed
    GameObject door;
    //bool to open door
    public bool roomClear = false;

    //audiosource for buttons, targets, tiles, room clear sound, reset sound
    AudioSource myAudio;
    public AudioClip stepSound;
    public AudioClip clearSound;
    public AudioClip resetSound;

    //sound functions that switches can call
    public void PlayStep()
    {
        myAudio.PlayOneShot(stepSound);
    }
    public void RoomClear()
    {
        myAudio.PlayOneShot(clearSound);
        myAudio.Stop();
    }
    public void ResetAlert()
    {
        myAudio.PlayOneShot(resetSound);
    }

    // Start is called before the first frame update
    void Start()
    {
        myAudio = GetComponent<AudioSource>();

        if (roomType == 1)
        {
            //grab last switch to check
            lastSwitch = GameObject.Find("s5");
        }
        else if (roomType == 3)
        {
            //grab root switch to check children
            rootSwitch = GameObject.Find("t1");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (roomType == 1)
        {
            //check switch
            if (lastSwitch.GetComponent<SwitchToggle>().on)
            {
                roomClear = true;
                RoomClear();
            }
        }
        else
        {
            //check switch
            if (rootSwitch.GetComponent<SwitchToggle>().on)
            {
                foreach (Transform childTile in rootSwitch.transform)
                {
                    if (!childTile.GetComponent<SwitchToggle>().on)
                    {
                        roomClear = false;
                    }
                    else
                    {
                        roomClear = true;
                        RoomClear();
                    }
                }
            }
        }
    }
}
