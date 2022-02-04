using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position += new Vector3(0, 0, 0.1f);
        //transform.position += new Vector3(0, 0, 1) * 0.1f;
        //transform.position += Vector3.forward * 0.1f; //forward -> (0, 0, 1) in world
        //transform.position += Vector3.up * 0.1f; //up -> (0, 1, 0) in world
        //transform.position += Vector3.right * 0.1f; //right -> (1, 0, 0) in world
        //transform.position += (Vector3.forward + Vector3.up).normalized * 0.1f; //move in 45 degrees
        transform.position += transform.forward * 0.1f;

    }
}
