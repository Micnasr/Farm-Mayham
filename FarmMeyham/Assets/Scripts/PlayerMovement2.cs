using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2 : MonoBehaviour
{

    public float movementSpeed = 5f;

    public Rigidbody rb;
    public Animator animator;

    public bool controller = true;

    Vector3 movement;
    void Start()
    {
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
    }


    void Update()
    {
        movement.z = -(Input.GetAxisRaw("Horizontal2"));
        movement.x = Input.GetAxisRaw("Vertical2");

       
        Rotation();

        ControllerMovement();

        //print("Horizontal :" + Input.GetAxisRaw("LeftJoyHor"));
        //print("Vertical : " + Input.GetAxisRaw("LeftJoyVert"));

        //float heading = Mathf.Atan2(-movement.x, -movement.y);
        //transform.rotation = Quaternion.Euler(0f, -heading * Mathf.Rad2Deg , 0f);


        ControllerRotation();

    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * movementSpeed * Time.fixedDeltaTime);
    }

    void Rotation()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, -90, 0));
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));
        }
        if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.RightArrow))
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, -135, 0));
        }
        if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.LeftArrow))
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 135, 0));
        }
        if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.LeftArrow))
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 45, 0));
        }
        if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.RightArrow))
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, -45, 0));
        }
    }

    void ControllerMovement()
    {
        if (controller)
        {
            movement.z = -(Input.GetAxis("LeftJoyHor"));
            movement.x = -(Input.GetAxis("LeftJoyVert"));
            print("ok");
        }


        if (Input.GetAxisRaw("LeftJoyHor") <= 0.2 && Input.GetAxisRaw("LeftJoyHor") >= -0.2 && Input.GetAxisRaw("LeftJoyVert") <= 0.2 && Input.GetAxisRaw("LeftJoyVert") >= -0.2)
        {
            controller = false;

        }
        else if (Input.GetAxisRaw("LeftJoyHor") >= 0.2 || Input.GetAxisRaw("LeftJoyHor") <= -0.2 || Input.GetAxisRaw("LeftJoyVert") >= 0.2 || Input.GetAxisRaw("LeftJoyVert") <= -0.2)
        {
            controller = true;

        }
    }

    void ControllerRotation()
    {
        if (Input.GetAxisRaw("LeftJoyHor") >= 0.2 && Input.GetAxisRaw("LeftJoyVert") <= 0.2)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, -90, 0));
        }
        if (Input.GetAxisRaw("LeftJoyHor") <= -0.2 && Input.GetAxisRaw("LeftJoyVert") <= 0.2)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));
        }
        if (Input.GetAxisRaw("LeftJoyVert") <= -0.2 && Input.GetAxisRaw("LeftJoyHor") <= 0.2)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
        }
        if (Input.GetAxisRaw("LeftJoyVert") >= 0.2 && Input.GetAxisRaw("LeftJoyHor") <= 0.2)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }
        if (Input.GetAxisRaw("LeftJoyVert") >= 0.2 && Input.GetAxisRaw("LeftJoyHor") >= 0.2)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, -45, 0));
        }
        if (Input.GetAxisRaw("LeftJoyVert") >= 0.2 && Input.GetAxisRaw("LeftJoyHor") <= -0.2)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 45, 0));
        }
        if (Input.GetAxisRaw("LeftJoyVert") <= -0.2 && Input.GetAxisRaw("LeftJoyHor") >= 0.2)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, -135, 0));
        }
        if (Input.GetAxisRaw("LeftJoyVert") <= -0.2 && Input.GetAxisRaw("LeftJoyHor") <= -0.2)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 135, 0));
        }

    }
}
