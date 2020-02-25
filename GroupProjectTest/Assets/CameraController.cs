using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //obtains horizontal and vertical as floats in the case of analog input
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        //Vector3 step = new Vector3(h, 0, v); //equivalent to line 21
        //Vector3 step = Vector3.right * h + Vector3.forward * v; //this is world-aligned movement, camera-aligned is below
        Vector3 step = transform.right * h + transform.up * v;

        transform.position += step * 5 * Time.deltaTime;
    }
}
