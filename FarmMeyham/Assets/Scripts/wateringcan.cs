using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wateringcan : MonoBehaviour
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
            transform.rotation = hand.transform.rotation;


            timer += Time.deltaTime;
            if (timer >= 0.5)
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
            transform.rotation = hand2.transform.rotation;


            timer2 += Time.deltaTime;
            if (timer2 >= 0.5)
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
                GetComponent<Collider>().enabled = false;
                StartCoroutine(CanTake_());
            }


        }

        if (other.transform.tag == "hand2")
        {
            if (Input.GetKey(KeyCode.RightControl) || Input.GetButton("xButton"))
            {
                pickable2 = false;
                hand2.transform.tag = "full";
                GetComponent<Collider>().enabled = false;
            }


        }
    }



    IEnumerator CanPickUp()
    {
        CanThrow = false;
        timer = 0f;
        yield return new WaitForSeconds(.1f);
        hand.transform.tag = "hand";
        pickable = true;
        GetComponent<Collider>().enabled = true;
    }

    IEnumerator CanPickUp2()
    {
        CanThrow2 = false;
        timer2 = 0f;
        yield return new WaitForSeconds(.1f);
        hand2.transform.tag = "hand2";
        pickable2 = true;
        GetComponent<Collider>().enabled = true;
    }

    IEnumerator CanTake_()
    {
        CanTake = false;
        yield return new WaitForSeconds(1.5f);
        CanTake = true;
    }

}

