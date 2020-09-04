using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    Rigidbody rb;

    public float speed = 30f;

    public float jumpspd = 1f;

    bool canJump = false;

    void OnCollisionEnter (Collision c) {
        if (c.gameObject.tag == "ground") {
            canJump = true;
        }
    }
    void OnCollisionExit (Collision c) {
        if (c.gameObject.tag == "ground") {
            canJump = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); // set rigid body
    }

    // Update is called once per frame
    void Update()
    {
        if (canJump == true) {
            if (Input.GetKey(KeyCode.W)) {
                rb.AddForce(transform.parent.transform.forward * speed);
            }
            if (Input.GetKey(KeyCode.S)) {
                rb.AddForce(-transform.parent.transform.forward * speed);
            }
            if (Input.GetKey(KeyCode.D)) {
                rb.AddForce(transform.parent.transform.right * speed);
            }
            if (Input.GetKey(KeyCode.A)) {
                rb.AddForce(-transform.parent.transform.right * speed);
            }
            if (Input.GetKey(KeyCode.Space)) {
                rb.AddForce(transform.parent.transform.up * jumpspd,ForceMode.Impulse);
            }
        }
    }
}
