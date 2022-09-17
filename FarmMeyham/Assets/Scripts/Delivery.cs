using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    public GameObject Order1;
    public GameObject Order2;
    public GameObject Order3;
    public GameObject Order4;

    public bool PumpkinSent = false;
    public bool CarrotSent = false;
    public bool PotatoSent = false;

    public OrderManager ordermanager;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "finishedPumpkin")
        {
            if (Order1.transform.tag == "ORDERPUMPKIN")
            {
                StartCoroutine(AcceptPumpkin());
            }
            else if (Order2.transform.tag == "ORDERPUMPKIN")
            {
                StartCoroutine(AcceptPumpkin());
            }
            else if (Order3.transform.tag == "ORDERPUMPKIN")
            {
                StartCoroutine(AcceptPumpkin());
            }
            else if (Order4.transform.tag == "ORDERPUMPKIN")
            {
                StartCoroutine(AcceptPumpkin());
            }
            else
            {
                //ignore
            }

        }
        else if (collision.transform.tag == "finishedcarrot")
        {
            if (Order1.transform.tag == "ORDERCARROT")
            {
                StartCoroutine(AcceptCarrot());
            }
            else if (Order2.transform.tag == "ORDERCARROT")
            {
                StartCoroutine(AcceptCarrot());
            }
            else if (Order3.transform.tag == "ORDERCARROT")
            {
                StartCoroutine(AcceptCarrot());
            }
            else if (Order4.transform.tag == "ORDERCARROT")
            {
                StartCoroutine(AcceptCarrot());
            }
            else
            {
                //ignore
            }
        }
        else if (collision.transform.tag == "finishedpotato")
        {
            if (Order1.transform.tag == "ORDERPOTATO")
            {
                StartCoroutine(AcceptPotato());
            }
            else if (Order2.transform.tag == "ORDERPOTATO")
            {
                StartCoroutine(AcceptPotato());
            }
            else if (Order3.transform.tag == "ORDERPOTATO")
            {
                StartCoroutine(AcceptPotato());
            }
            else if (Order4.transform.tag == "ORDERPOTATO")
            {
                StartCoroutine(AcceptPotato());
            }
            else
            {
                //ignore
            }
        }

    }

        IEnumerator AcceptPumpkin()
        {
            print("accepted pumpkin");
            PumpkinSent = true;
            yield return new WaitForSeconds(.1f);
            PumpkinSent = false;
        }

        IEnumerator AcceptCarrot()
        {
            print("accepted carrot");
            CarrotSent = true;
            yield return new WaitForSeconds(.1f);
            CarrotSent = false;
        }

        IEnumerator AcceptPotato()
        {
            print("accepted potato");
            PotatoSent = true;
            yield return new WaitForSeconds(.1f);
            PotatoSent = false;
        }

        void Update()
        {
            ordermanager.SetStatusPumpkin(PumpkinSent);
            ordermanager.SetStatusCarrot(CarrotSent);
            ordermanager.SetStatusPotato(PotatoSent);
        }
    
}
