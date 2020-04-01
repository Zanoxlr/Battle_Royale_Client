using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowForward : MonoBehaviour
{
    Rigidbody rb;
    Collider cl;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cl = GetComponent<Collider>();
    }
    void Update()
    {
        if(rb.isKinematic == false)
        {
            transform.rotation = Quaternion.LookRotation(rb.velocity);
        }
        if(transform.position.y < -100f)
        {
            //Destroy(gameObject);
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player" || collision.gameObject.layer == 8)
        {
            rb.isKinematic = true;
            cl.isTrigger = true;
        }
    }
}
