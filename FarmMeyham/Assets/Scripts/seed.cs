using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class seed : MonoBehaviour
{
    GameObject hand;
    GameObject hand2;

    bool pickable = true;
    bool pickable2 = true;
    
    bool CanThrow = false;
    bool CanThrow2 = false;

    float timer;
    float timer2;

    bool CanTake = true;
    bool CanTake2 = true;

    void Start()
    {
        hand = GameObject.Find("Hand");
        hand2 = GameObject.Find("Hand2");
    }

   
    void Update()
    {
        

        if (pickable == false)
        {
            transform.position = hand.transform.position;


            timer += Time.deltaTime;
            if (timer >= 0.2)
            {
                CanThrow = true;
                
            }

            if (Input.GetKey(KeyCode.Space) && CanThrow)
            {
                StartCoroutine(CanPickUp());
            }
        }

        if (pickable2 == false)
        {
            transform.position = hand2.transform.position;


            timer2 += Time.deltaTime;
            if (timer2 >= 0.2)
            {
                CanThrow2 = true;

            }

            if (Input.GetKey(KeyCode.RightControl) && CanThrow2 || Input.GetButton("xButton") && CanThrow2)
            {
                StartCoroutine(CanPickUp2());
            }
        }


    }

    void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "hand")
        {
            if (Input.GetKey(KeyCode.Space) && CanTake)
            {
                
                pickable = false;
                hand.transform.tag = "full";
                print("handfull");
                StartCoroutine(CanTake_());
                //GetComponent<Collider>().enabled = false;
            }
           
            
        }

        if (other.transform.tag == "hand2")
        {
            if (Input.GetKey(KeyCode.RightControl) && CanTake2 || Input.GetButton("xButton") && CanTake2)
            {
                pickable2 = false;
                hand2.transform.tag = "full";
                StartCoroutine(CanTake2_());
                // GetComponent<Collider>().enabled = false;
            }


        }

        if (other.transform.tag == "trashcan")
        {
            if (Input.GetKey(KeyCode.E))
            {

                hand.transform.tag = "hand";
                Destroy(gameObject);
            }

            if (Input.GetKey(KeyCode.RightShift) || Input.GetButton("SquareButton"))
            {
                hand2.transform.tag = "hand2";
                Destroy(gameObject);
            }
        }


    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "plowed")
        {
            Destroy(gameObject);
        }

        
    }

    



    IEnumerator CanPickUp()
    {
        CanThrow = false;
        timer = 0f;
        yield return new WaitForSeconds(.1f);
        hand.transform.tag = "hand";
        pickable = true;
       // GetComponent<Collider>().enabled = true;
    }

    IEnumerator CanPickUp2()
    {
        CanThrow2 = false;
        timer2 = 0f;
        yield return new WaitForSeconds(.1f);
        hand2.transform.tag = "hand2";
        pickable2 = true;
       // GetComponent<Collider>().enabled = true;
    }

    IEnumerator CanTake_()
    {
        CanTake = false;
        yield return new WaitForSeconds(0.3f);
        CanTake = true;
    }

    IEnumerator CanTake2_()
    {
        CanTake2 = false;
        yield return new WaitForSeconds(0.3f);
        CanTake2 = true;
    }

}

