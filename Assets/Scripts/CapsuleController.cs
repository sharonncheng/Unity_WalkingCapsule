using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleController : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] Transform earth;
    [SerializeField] float gravityScale = 2;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // rb.velocity = transform.forward * 5 * Input.GetAxis("Vertical"); // only moving foward/backward
        /* Vector3 move = transform.forward * 5 * Input.GetAxis("Vertical"); // move according to w or s button
         * move.y = rb.velocity.y; // there will be problem bc y is the world's y and not towards the earth
         * rb.velocity = move;
         */

        // translating the local coordinates to the world coordinates
        Vector3 localMove = transform.InverseTransformDirection(transform.forward * 5 * Input.GetAxis("Vertical"));
        localMove.y = transform.InverseTransformDirection(rb.velocity).y;
        rb.velocity = transform.TransformDirection(localMove);

        transform.Rotate(0, 240 * Time.deltaTime * Input.GetAxis("Horizontal"), 0);

        transform.rotation =
            Quaternion.FromToRotation(transform.up, transform.position - earth.position) * transform.rotation;

        if (Input.GetButtonDown("Jump")) rb.AddForce(transform.up * 8, ForceMode.Impulse);
    }

    private void FixedUpdate() // put physics calculations here ex: rb force calculations
    {
        // give a downward force towards the center of the earth
        rb.AddForce((earth.position - transform.position).normalized * 10 * gravityScale);
        
    }
}
