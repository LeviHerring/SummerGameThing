using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;
    Collider col;
    public float speed;
    public float jumpHeight = 1; 
    public float playerHeight = 1; 
    void Start()
    {
       rb = GetComponent<Rigidbody>(); 
        col = GetComponent<Collider>(); 
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(transform.forward * speed, ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.velocity = speed * -transform.forward;
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = speed * -transform.right;
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = speed * transform.right;
        }

    }

    void Jump()
    {
        if(Input.GetKey(KeyCode.Space) && GroundCheck())
        {
            rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

            rb.AddForce(transform.up * jumpHeight, ForceMode.Impulse);
        }

    }
    bool GroundCheck()
    {
        return Physics.Raycast(transform.position, Vector3.down, playerHeight); 
    }
}
