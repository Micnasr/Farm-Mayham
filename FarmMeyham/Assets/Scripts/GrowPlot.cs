using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrowPlot : MonoBehaviour
{
    public GameObject UnwateredSeed;
    public GameObject seedLocation;

    public Material grass;
    public Material dirt;
    public GameObject Land;

    public float maxGrowTime = 8f;
    public Slider slider;
    public GameObject GrowBarUI;
    public GameObject fill;

    private bool Using = false;
    private float timer = 0f;

    bool watered = false;

    bool CanHoe = true;

    public GameObject DirtPlowedEffect;

    public Animator hoeanimator;

    #region Pumpkin ----
    //Pumpkin ----------------
    private bool Pumpkingrowing = false;
    public GameObject PumpkinStage2;
    public GameObject PumpkinStage3;
    public GameObject PumpkinStage4;
    public GameObject PumpkinDone;
    public GameObject PumpkinSpoiled;
    bool on1 = false;
    GameObject stage1;
    bool on2 = false;
    GameObject stage2;
    bool on3 = false;
    GameObject stage3;
    bool on4 = false;
    GameObject stage4;
    bool on5 = false;
    GameObject stage5;
    public bool PumpkinSpoil = true;
    #endregion

    #region Carrot ----
    //Carrot ----------------
    private float CarrotTimer;
    private bool CarrotGrowing = false;
    public GameObject Carrot1;
    public GameObject Carrot2;
    public GameObject Carrot3;
    public GameObject Carrot4;
    public GameObject CarrotSpoiled;
    bool Carroton1 = false;
    GameObject Carrotstage1;
    bool Carroton2 = false;
    GameObject Carrotstage2;
    bool Carroton3 = false;
    GameObject Carrotstage3;
    bool Carroton4 = false;
    GameObject Carrotstage4;
    bool Carroton5 = false;
    GameObject Carrotstage5;
    public bool CarrotSpoil = true;
    #endregion

    #region Potato ----
    //Potato ----------------
    private float PotatoTimer;
    private bool PotatoGrowing = false;
    public GameObject Potato1;
    public GameObject Potato2;
    public GameObject Potato3;
    public GameObject Potato4;
    public GameObject PotatoSpoiled;
    bool Potatoon1 = false;
    GameObject Potatostage1;
    bool Potatoon2 = false;
    GameObject Potatostage2;
    bool Potatoon3 = false;
    GameObject Potatostage3;
    bool Potatoon4 = false;
    GameObject Potatostage4;
    bool Potatoon5 = false;
    GameObject Potatostage5;
    public bool PotatoSpoil = true;
    #endregion

    void Start()
    {
        Land.GetComponent<MeshRenderer>().material = grass;
        slider.value = 0f;

        slider.maxValue = maxGrowTime;
        fill.GetComponent<Image>().color = Color.green;
    }

    
    void Update()
    {
        if (Pumpkingrowing)
        {
            GrowPumpkin();
            slider.value = timer;
        }

        if (CarrotGrowing)
        {
            GrowCarrot();
            slider.value = timer;
        }

        if (PotatoGrowing)
        {
            GrowPotato();
            slider.value = timer;
        }

        if (transform.tag == "unplowed")
        {
            Land.GetComponent<MeshRenderer>().material = grass;
            slider.value = 0f;
            GrowBarUI.SetActive(false);
        } else if (transform.tag == "plowed")
        {
            Land.GetComponent<MeshRenderer>().material = dirt;
        }


        

        if (timer > 0)
        {
            GrowBarUI.SetActive(true);
        } else
        {
            GrowBarUI.SetActive(false);
        }
    }

    

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "pumpkin" && Using == false && transform.tag == "plowed")
        {
            stage1 = Instantiate(UnwateredSeed, seedLocation.transform.position, Quaternion.Euler(-90,0,0));
            Using = true;
            Pumpkingrowing = true;
            PumpkinSpoil = true;

        }

        if (collision.transform.tag == "carrot" && Using == false && transform.tag == "plowed")
        {
            Carrotstage1 = Instantiate(UnwateredSeed, seedLocation.transform.position, Quaternion.Euler(-90, 0, 0));
            Using = true;
            CarrotGrowing = true;
            CarrotSpoil = true;

        }

        if (collision.transform.tag == "potato" && Using == false && transform.tag == "plowed")
        {
            Potatostage1 = Instantiate(UnwateredSeed, seedLocation.transform.position, Quaternion.Euler(-90, 0, 0));
            Using = true;
            PotatoGrowing = true;
            PotatoSpoil = true;

        }


    }

    void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "hoe")
        {
           if (Input.GetKey(KeyCode.E) && CanHoe || Input.GetKey(KeyCode.RightShift) && CanHoe || Input.GetButton("SquareButton") && CanHoe)
            {
                transform.tag = "plowed";
                
                
                GameObject dirtparticle = Instantiate(DirtPlowedEffect, seedLocation.transform.position, Quaternion.Euler(-90, 0, 0));
                Destroy(dirtparticle, 2f);
                StartCoroutine(HoeTimer());
            }
        }

        if (other.transform.tag == "wateringcan")
        {
            if (Input.GetKey(KeyCode.E) && Using || Input.GetKey(KeyCode.RightShift) || Input.GetButton("SquareButton"))
            {
                watered = true;
            }
        }
    }

    void OnCollisionExit(Collision collision)
    {
       if (collision.transform.tag == "finishedPumpkin")
        {
            PumpkinSpoil = false;
            Using = false;
            timer = 0f;
            Pumpkingrowing = false;
            on1 = false;
            on2 = false;
            on3 = false;
            on4 = false;
            on5 = false;
            transform.tag = "unplowed";
            fill.GetComponent<Image>().color = Color.green;
            watered = false;
        }

        if (collision.transform.tag == "SpoiledPumpkin")
        {
            PumpkinSpoil = false;
            Using = false;
            timer = 0f;
            Pumpkingrowing = false;
            on1 = false;
            on2 = false;
            on3 = false;
            on4 = false;
            on5 = false;
            transform.tag = "unplowed";
            fill.GetComponent<Image>().color = Color.green;
            watered = false;
        }

        if (collision.transform.tag == "finishedcarrot")
        {
            CarrotSpoil = false;
            Using = false;
            timer = 0f;
            CarrotGrowing = false;
            Carroton1 = false;
            Carroton2 = false;
            Carroton3 = false;
            Carroton4 = false;
            Carroton5 = false;
            transform.tag = "unplowed";
            fill.GetComponent<Image>().color = Color.green;
            watered = false;
        }

        if (collision.transform.tag == "SpoiledCarrot")
        {
            CarrotSpoil = false;
            Using = false;
            timer = 0f;
            CarrotGrowing = false;
            Carroton1 = false;
            Carroton2 = false;
            Carroton3 = false;
            Carroton4 = false;
            Carroton5 = false;
            transform.tag = "unplowed";
            fill.GetComponent<Image>().color = Color.green;
            watered = false;
        }

        if (collision.transform.tag == "finishedpotato")
        {
            PotatoSpoil = false;
            Using = false;
            timer = 0f;
            PotatoGrowing = false;
            Potatoon1 = false;
            Potatoon2 = false;
            Potatoon3 = false;
            Potatoon4 = false;
            Potatoon5 = false;
            transform.tag = "unplowed";
            fill.GetComponent<Image>().color = Color.green;
            watered = false;
        }

        if (collision.transform.tag == "SpoiledPotato")
        {
            PotatoSpoil = false;
            Using = false;
            timer = 0f;
            PotatoGrowing = false;
            Potatoon1 = false;
            Potatoon2 = false;
            Potatoon3 = false;
            Potatoon4 = false;
            Potatoon5 = false;
            transform.tag = "unplowed";
            fill.GetComponent<Image>().color = Color.green;
            watered = false;
        }
    }

    void GrowPumpkin()
    {
        if (watered)
        {
            timer += Time.deltaTime;
            if (timer >= 2 && timer < 3)
            {
                if (!on1)
                {
                    stage2 = Instantiate(PumpkinStage2, seedLocation.transform.position, Quaternion.Euler(-90, 0, 0));
                    on1 = true;
                    Destroy(stage1);
                }


            }
            if (timer >= 4 && timer < 5)
            {
                if (!on2)
                {
                    stage3 = Instantiate(PumpkinStage3, seedLocation.transform.position, Quaternion.Euler(-90, 0, 0));
                    on2 = true;
                    Destroy(stage2);
                }
            }
            if (timer >= 6 && timer < 7)
            {
                if (!on3)
                {
                    stage4 = Instantiate(PumpkinStage4, seedLocation.transform.position, Quaternion.Euler(0, 0, 0));
                    on3 = true;
                    Destroy(stage3);
                }
            }
            if (timer >= 8 && timer < 9)
            {
                if (!on4)
                {
                    stage5 = Instantiate(PumpkinDone, seedLocation.transform.position, Quaternion.Euler(0, 0, 0));
                    on4 = true;
                    Destroy(stage4);
                }
            }

            if (timer >= 14 && timer < 15 && PumpkinSpoil)
            {
                if (!on5)
                {
                    fill.GetComponent<Image>().color = Color.red;
                    Instantiate(PumpkinSpoiled, seedLocation.transform.position, Quaternion.Euler(0, 0, 0));
                    on5 = true;
                    Destroy(stage5);

                }
            }
        
        }
    }

    void GrowCarrot()
    {
        if (watered)
        {
            timer += Time.deltaTime;
            if (timer >= 2 && timer < 3)
            {
                if (!Carroton1)
                {
                    Carrotstage2 = Instantiate(Carrot1, seedLocation.transform.position, Quaternion.Euler(-90, 0, 0));
                    Carroton1 = true;
                    Destroy(Carrotstage1);
                }


            }
            if (timer >= 4 && timer < 5)
            {
                if (!Carroton2)
                {
                    Carrotstage3 = Instantiate(Carrot2, seedLocation.transform.position, Quaternion.Euler(-90, 0, 0));
                    Carroton2 = true;
                    Destroy(Carrotstage2);
                }
            }
            if (timer >= 6 && timer < 7)
            {
                if (!Carroton3)
                {
                    Carrotstage4 = Instantiate(Carrot3, seedLocation.transform.position, Quaternion.Euler(0, 0, 0));
                    Carroton3 = true;
                    Destroy(Carrotstage3);
                }
            }
            if (timer >= 8 && timer < 9)
            {
                if (!Carroton4)
                {
                    Carrotstage5 = Instantiate(Carrot4, seedLocation.transform.position, Quaternion.Euler(0, 0, 0));
                    Carroton4 = true;
                    Destroy(Carrotstage4);
                }
            }

            if (timer >= 14 && timer < 15 && PumpkinSpoil)
            {
                if (!Carroton5)
                {
                    fill.GetComponent<Image>().color = Color.red;
                    Instantiate(CarrotSpoiled, seedLocation.transform.position, Quaternion.Euler(0, 0, 0));
                    Carroton5 = true;
                    Destroy(Carrotstage5);

                }
            }

        }
    }

    void GrowPotato()
    {
        if (watered)
        {
            timer += Time.deltaTime;
            if (timer >= 2 && timer < 3)
            {
                if (!Potatoon1)
                {
                    Potatostage2 = Instantiate(Potato1, seedLocation.transform.position, Quaternion.Euler(-90, 0, 0));
                    Potatoon1 = true;
                    Destroy(Potatostage1);
                }


            }
            if (timer >= 4 && timer < 5)
            {
                if (!Potatoon2)
                {
                    Potatostage3 = Instantiate(Potato2, seedLocation.transform.position, Quaternion.Euler(-90, 0, 0));
                    Potatoon2 = true;
                    Destroy(Potatostage2);
                }
            }
            if (timer >= 6 && timer < 7)
            {
                if (!Potatoon3)
                {
                    Potatostage4 = Instantiate(Potato3, seedLocation.transform.position, Quaternion.Euler(0, 0, 0));
                    Potatoon3 = true;
                    Destroy(Potatostage3);
                }
            }
            if (timer >= 8 && timer < 9)
            {
                if (!Potatoon4)
                {
                    Potatostage5 = Instantiate(Potato4, seedLocation.transform.position, Quaternion.Euler(0, 0, 0));
                    Potatoon4 = true;
                    Destroy(Potatostage4);
                }
            }

            if (timer >= 14 && timer < 15 && PumpkinSpoil)
            {
                if (!Potatoon5)
                {
                    fill.GetComponent<Image>().color = Color.red;
                    Instantiate(PotatoSpoiled, seedLocation.transform.position, Quaternion.Euler(0, 0, 0));
                    Potatoon5 = true;
                    Destroy(Potatostage5);

                }
            }

        }
    }

    IEnumerator HoeTimer()
    {
        CanHoe = false;
        yield return new WaitForSeconds(3f);
        CanHoe = true;
    }
}
