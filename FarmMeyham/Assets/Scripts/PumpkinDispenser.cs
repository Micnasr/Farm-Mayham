using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpkinDispenser : MonoBehaviour
{
    public GameObject pumpkinSeed;

    GameObject hand;
    GameObject hand2;

    GameObject clone;

    bool CanTake = true;
    bool CanTake2 = true;

    void Start()
    {
        hand = GameObject.Find("Hand");
        hand2 = GameObject.Find("Hand2");
    }
    void OnTriggerStay(Collider other) 
    {
        if (other.transform.tag == "hand")
        {
            if (Input.GetKey(KeyCode.Space) && CanTake)
            {
                clone = Instantiate(pumpkinSeed, hand.transform.position, Quaternion.identity);
                StartCoroutine(MayTake());
            }
           
        }

        if (other.transform.tag == "hand2")
        {
            if (Input.GetKey(KeyCode.RightControl) && CanTake2 || Input.GetButton("xButton") && CanTake2)
            {
                clone = Instantiate(pumpkinSeed, hand2.transform.position, Quaternion.identity);
                StartCoroutine(MayTake2());
            }

        }
    }

    IEnumerator MayTake()
    {
        CanTake = false;
        yield return new WaitForSeconds(1f);
        CanTake = true;
    }

    IEnumerator MayTake2()
    {
        CanTake2 = false;
        yield return new WaitForSeconds(1f);
        CanTake2 = true;
    }
}
