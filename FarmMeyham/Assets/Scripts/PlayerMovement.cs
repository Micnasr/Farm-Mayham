using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float movementSpeed = 5f;

    public Rigidbody rb;
    public Animator animator;

    Vector3 movement;
    void Start()
    {
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
    }

  
    void Update()
    {
        movement.z = -(Input.GetAxisRaw("Horizontal"));
        movement.x = Input.GetAxisRaw("Vertical");

        //animator.SetFloat("Horizontal", movement.z);
        //animator.SetFloat("Vertical", movement.x);
        //animator.SetFloat("Speed", movement.sqrMagnitude);

        Rotation();

        


    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * movementSpeed * Time.fixedDeltaTime);
    }

    void Rotation()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, -90, 0));
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));
        }
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, -135, 0));
        }
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 135, 0));
        }
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 45, 0));
        }
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, -45, 0));
        }
    }
}
