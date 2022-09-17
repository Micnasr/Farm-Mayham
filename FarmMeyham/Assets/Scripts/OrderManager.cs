using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderManager : MonoBehaviour
{
    #region VariableOrders

    public GameObject Order1;
    public GameObject Order1Carrot;
    public GameObject Order1Pumpkin;
    public GameObject Order1Potato;
    public bool Order1Timer;
    public float Timer1 = 0f;
    bool Running1 = true;
    public Slider Slider1;
    public GameObject slider1;
    public float OrderExpire = 10f;
    float OrderTimer;
    float RandomNumber = 0f;

    public GameObject Order2;
    public GameObject Order2Carrot;
    public GameObject Order2Pumpkin;
    public GameObject Order2Potato;
    public bool Order2Timer;
    public float Timer2 = 0f;
    bool Running2 = true;
    public Slider Slider2;
    public GameObject slider2;
    float OrderTimer2;
    float RandomNumber2 = 0f;


    public GameObject Order3;
    public GameObject Order3Carrot;
    public GameObject Order3Pumpkin;
    public GameObject Order3Potato;
    public bool Order3Timer;
    public float Timer3 = 0f;
    bool Running3 = true;
    public Slider Slider3;
    public GameObject slider3;
    float OrderTimer3;
    float RandomNumber3 = 0f;

    public GameObject Order4;
    public GameObject Order4Carrot;
    public GameObject Order4Pumpkin;
    public GameObject Order4Potato;
    public bool Order4Timer;
    public float Timer4 = 0f;
    bool Running4 = true;
    public Slider Slider4;
    public GameObject slider4;
    float OrderTimer4;
    float RandomNumber4 = 0f;
    #endregion


    public float Score= 0f;

    string[] Crops = new string[] { "ORDERPUMPKIN", "ORDERCARROT", "ORDERPOTATO"};


    bool orderWinPumpkin = false;
    bool on = false;

    bool orderWinCarrot = false;
    bool on2 = false;

    bool orderWinPotato = false;
    bool on3 = false;

    public Text Scoring;
    public Text Scoring2;

    public Animator ScoreGain;

    public GameObject endgame;

    void Start()
    {
        Slider1.maxValue = OrderExpire;
        Slider1.value = Slider1.maxValue;
        slider1.SetActive(false);

        Slider2.maxValue = OrderExpire;
        Slider2.value = Slider2.maxValue;
        slider2.SetActive(false);

        Slider3.maxValue = OrderExpire;
        Slider3.value = Slider3.maxValue;
        slider3.SetActive(false);

        Slider4.maxValue = OrderExpire;
        Slider4.value = Slider4.maxValue;
        slider4.SetActive(false);

        
    }


    void Update()
    {
        FirstOrder();
        SecondOrder();
        ThirdOrder();
        FourthOrder();

        
        Scoring.text = Score.ToString();
        Scoring2.text = Score.ToString();

        if (endgame.transform.tag == "gameend")
        {
            Destroy(this);
        }
    }

    public void SetStatusPumpkin(bool status)
    {
        
        orderWinPumpkin = status;
        

        if (!status)
        {
            on = true;
        }
        

        if (orderWinPumpkin && on)
        {
            
            if (Order1.transform.tag == "ORDERPUMPKIN")
            {
                StartCoroutine(AnimationTimer());
                Running1 = true;
                Order1Timer = false;
                OrderTimer = 0f;
                Order1.transform.tag = "EMPTYORDER";
                slider1.SetActive(false);
                Order1Pumpkin.SetActive(false);
                Order1Carrot.SetActive(false);
                Order1Potato.SetActive(false);
                Timer1 = OrderExpire;
                on = false;
                Score = Score + 100;
                

            }
            else if (Order2.transform.tag == "ORDERPUMPKIN")
            {
                StartCoroutine(AnimationTimer());
                Running2 = true;
                Order2Timer = false;
                OrderTimer2 = 0f;
                Order2.transform.tag = "EMPTYORDER";
                slider2.SetActive(false);
                Order2Pumpkin.SetActive(false);
                Order2Carrot.SetActive(false);
                Order2Potato.SetActive(false);
                Timer2 = OrderExpire;
                on = false;
                Score = Score + 100;
            }
            else if (Order3.transform.tag == "ORDERPUMPKIN")
            {
                StartCoroutine(AnimationTimer());
                Running3 = true;
                Order3Timer = false;
                OrderTimer3 = 0f;
                Order3.transform.tag = "EMPTYORDER";
                slider3.SetActive(false);
                Order3Pumpkin.SetActive(false);
                Order3Carrot.SetActive(false);
                Order3Potato.SetActive(false);
                Timer3 = OrderExpire;
                on = false;
                Score = Score + 100;
            }
            else if (Order4.transform.tag == "ORDERPUMPKIN")
            {
                StartCoroutine(AnimationTimer());
                Running4 = true;
                Order4Timer = false;
                OrderTimer4 = 0f;
                Order4.transform.tag = "EMPTYORDER";
                slider4.SetActive(false);
                Order4Pumpkin.SetActive(false);
                Order4Carrot.SetActive(false);
                Order4Potato.SetActive(false);
                Timer4 = OrderExpire;
                on = false;
                Score = Score + 100;
            }
        }
        
        
    }
    public void SetStatusCarrot(bool status)
    {

        orderWinCarrot = status;
        

        if (!status)
        {
            on2 = true;
        }


        if (orderWinCarrot && on2)
        {

            if (Order1.transform.tag == "ORDERCARROT")
            {
                StartCoroutine(AnimationTimer());
                Running1 = true;
                Order1Timer = false;
                OrderTimer = 0f;
                Order1.transform.tag = "EMPTYORDER";
                slider1.SetActive(false);
                Order1Pumpkin.SetActive(false);
                Order1Carrot.SetActive(false);
                Timer1 = OrderExpire;
                on2 = false;
                Score = Score + 100;

            }
            else if (Order2.transform.tag == "ORDERCARROT")
            {
                StartCoroutine(AnimationTimer());
                Running2 = true;
                Order2Timer = false;
                OrderTimer2 = 0f;
                Order2.transform.tag = "EMPTYORDER";
                slider2.SetActive(false);
                Order2Pumpkin.SetActive(false);
                Order2Carrot.SetActive(false);
                Timer2 = OrderExpire;
                on2 = false;
                Score = Score + 100;
            }
            else if (Order3.transform.tag == "ORDERCARROT")
            {
                StartCoroutine(AnimationTimer());
                Running3 = true;
                Order3Timer = false;
                OrderTimer3 = 0f;
                Order3.transform.tag = "EMPTYORDER";
                slider3.SetActive(false);
                Order3Pumpkin.SetActive(false);
                Order3Carrot.SetActive(false);
                Timer3 = OrderExpire;
                on2 = false;
                Score = Score + 100;
            }
            else if (Order4.transform.tag == "ORDERCARROT")
            {
                StartCoroutine(AnimationTimer());
                Running4 = true;
                Order4Timer = false;
                OrderTimer4 = 0f;
                Order4.transform.tag = "EMPTYORDER";
                slider4.SetActive(false);
                Order4Pumpkin.SetActive(false);
                Order4Carrot.SetActive(false);
                Timer4 = OrderExpire;
                on2 = false;
                Score = Score + 100;
            }
        }


    }

    public void SetStatusPotato(bool status)
    {

        orderWinPotato = status;
        

        if (!status)
        {
            on3 = true;
        }


        if (orderWinPotato && on3)
        {

            if (Order1.transform.tag == "ORDERPOTATO")
            {
                StartCoroutine(AnimationTimer());
                Running1 = true;
                Order1Timer = false;
                OrderTimer = 0f;
                Order1.transform.tag = "EMPTYORDER";
                slider1.SetActive(false);
                Order1Pumpkin.SetActive(false);
                Order1Carrot.SetActive(false);
                Order1Potato.SetActive(false);
                Timer1 = OrderExpire;
                on3 = false;
                Score = Score + 100;

            }
            else if (Order2.transform.tag == "ORDERPOTATO")
            {
                StartCoroutine(AnimationTimer());
                Running2 = true;
                Order2Timer = false;
                OrderTimer2 = 0f;
                Order2.transform.tag = "EMPTYORDER";
                slider2.SetActive(false);
                Order2Pumpkin.SetActive(false);
                Order2Carrot.SetActive(false);
                Order2Potato.SetActive(false);
                Timer2 = OrderExpire;
                on3 = false;
                Score = Score + 100;
            }
            else if (Order3.transform.tag == "ORDERPOTATO")
            {
                StartCoroutine(AnimationTimer());
                Running3 = true;
                Order3Timer = false;
                OrderTimer3 = 0f;
                Order3.transform.tag = "EMPTYORDER";
                slider3.SetActive(false);
                Order3Pumpkin.SetActive(false);
                Order3Carrot.SetActive(false);
                Order3Potato.SetActive(false);
                Timer3 = OrderExpire;
                on3 = false;
                Score = Score + 100;
            }
            else if (Order4.transform.tag == "ORDERPOTATO")
            {
                StartCoroutine(AnimationTimer());
                Running4 = true;
                Order4Timer = false;
                OrderTimer4 = 0f;
                Order4.transform.tag = "EMPTYORDER";
                slider4.SetActive(false);
                Order4Pumpkin.SetActive(false);
                Order4Carrot.SetActive(false);
                Order4Potato.SetActive(false);
                Timer4 = OrderExpire;
                on3 = false;
                Score = Score + 100;
            }
        }


    }



    void FirstOrder()
    {
        if (Running1)
        {

            OrderTimer += Time.deltaTime;
            if (OrderTimer >= 1f)
            {

                RandomNumber = Random.Range(0, Crops.Length);

                for (int i = 0; i < Crops.Length; i++)
                {
                    if (RandomNumber == i)
                    {
                        Order1.transform.tag = Crops[i];

                        if (RandomNumber == 0)
                        {
                            Order1Pumpkin.SetActive(true);
                        }
                        else if (RandomNumber == 1)
                        {
                            Order1Carrot.SetActive(true);
                        }
                        else if (RandomNumber == 2)
                        {
                            Order1Potato.SetActive(true);
                        }

                    }
                }

                Order1Timer = true;
                Running1 = false;
                Timer1 = OrderExpire;

            }
        }

        if (Order1Timer)
        {
            
            Timer1 -= Time.deltaTime;
            Slider1.value = Timer1;
            slider1.SetActive(true);

            if (Timer1 <= 0f)
            {
                Running1 = true;
                Order1Timer = false;
                OrderTimer = 0f;
                Order1.transform.tag = "EMPTYORDER";
                slider1.SetActive(false);
                Order1Pumpkin.SetActive(false);
                Order1Carrot.SetActive(false);
                Order1Potato.SetActive(false);
                Timer1 = OrderExpire;
                Score = Score - 100;
            }
        }
    }

    void SecondOrder() 
    {
        if (Running2)
        {

            OrderTimer2 += Time.deltaTime;
            if (OrderTimer2 >= 5f)
            {

                RandomNumber2 = Random.Range(0, Crops.Length);

                for (int i = 0; i < Crops.Length; i++)
                {
                    if (RandomNumber2 == i)
                    {
                        Order2.transform.tag = Crops[i];

                        if (RandomNumber2 == 0)
                        {
                            Order2Pumpkin.SetActive(true);
                        }
                        else if (RandomNumber2 == 1)
                        {
                            Order2Carrot.SetActive(true);
                        }
                        else if (RandomNumber2 == 2)
                        {
                            Order2Potato.SetActive(true);
                        }

                    }
                }

                Order2Timer = true;
                Running2 = false;
                Timer2 = OrderExpire;

            }
        }

        if (Order2Timer)
        {

            Timer2 -= Time.deltaTime;
            Slider2.value = Timer2;
            slider2.SetActive(true);

            if (Timer2 <= 0f)
            {
                Running2 = true;
                Order2Timer = false;
                OrderTimer2 = 0f;
                Order2.transform.tag = "EMPTYORDER";
                slider2.SetActive(false);
                Order2Pumpkin.SetActive(false);
                Order2Carrot.SetActive(false);
                Order2Potato.SetActive(false);
                Timer2 = OrderExpire;
                Score = Score - 100;
            }
        }
    }
    
    void ThirdOrder()
    {
        if (Running3)
        {

            OrderTimer3 += Time.deltaTime;
            if (OrderTimer3 >= 7f)
            {

                RandomNumber3 = Random.Range(0, Crops.Length);

                for (int i = 0; i < Crops.Length; i++)
                {
                    if (RandomNumber3 == i)
                    {
                        Order3.transform.tag = Crops[i];

                        if (RandomNumber3 == 0)
                        {
                            Order3Pumpkin.SetActive(true);
                        }
                        else if (RandomNumber3 == 1)
                        {
                            Order3Carrot.SetActive(true);
                        }
                        else if (RandomNumber3 == 2)
                        {
                            Order3Potato.SetActive(true);
                        }

                    }
                }

                Order3Timer = true;
                Running3 = false;
                Timer3 = OrderExpire;

            }
        }

        if (Order3Timer)
        {

            Timer3 -= Time.deltaTime;
            Slider3.value = Timer3;
            slider3.SetActive(true);

            if (Timer3 <= 0f)
            {
                Running3 = true;
                Order3Timer = false;
                OrderTimer3 = 0f;
                Order3.transform.tag = "EMPTYORDER";
                slider3.SetActive(false);
                Order3Pumpkin.SetActive(false);
                Order3Carrot.SetActive(false);
                Order3Potato.SetActive(false);
                Timer3 = OrderExpire;
                Score = Score - 100;
            }
        }
    }

    void FourthOrder()
    {
        if (Running4)
        {

            OrderTimer4 += Time.deltaTime;
            if (OrderTimer4 >= 11f)
            {

                RandomNumber4 = Random.Range(0, Crops.Length);

                for (int i = 0; i < Crops.Length; i++)
                {
                    if (RandomNumber4 == i)
                    {
                        Order4.transform.tag = Crops[i];

                        if (RandomNumber4 == 0)
                        {
                            Order4Pumpkin.SetActive(true);
                        }
                        else if (RandomNumber4 == 1)
                        {
                            Order4Carrot.SetActive(true);
                        }
                        else if (RandomNumber4 == 2)
                        {
                            Order4Potato.SetActive(true);
                        }

                    }
                }

                Order4Timer = true;
                Running4 = false;
                Timer4 = OrderExpire;

            }
        }

        if (Order4Timer)
        {

            Timer4 -= Time.deltaTime;
            Slider4.value = Timer3;
            slider4.SetActive(true);

            if (Timer4 <= 0f)
            {
                Running4 = true;
                Order4Timer = false;
                OrderTimer4 = 0f;
                Order4.transform.tag = "EMPTYORDER";
                slider4.SetActive(false);
                Order4Pumpkin.SetActive(false);
                Order4Carrot.SetActive(false);
                Order4Potato.SetActive(false);
                Timer4 = OrderExpire;
                Score = Score - 100;
            }
        }
    }

    IEnumerator AnimationTimer()
    {
        ScoreGain.SetBool("+100", true);
        print("true");
        yield return new WaitForSeconds(1f);
        ScoreGain.SetBool("+100", false);
    }
}
