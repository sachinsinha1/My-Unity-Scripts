using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lighton : MonoBehaviour
{
    private RaycastHit hit;
    private Ray ray;
    private float distance = 3.0f;
    public bool lightStatusLiv = false;
    public bool lightStatusBed = false;
    //public Light lit;
    public GameObject[] lightMesh;
    public GameObject[] lightBed;

    private void Start()
    {
        lightMesh = GameObject.FindGameObjectsWithTag("lightBulb");
        lightBed = GameObject.FindGameObjectsWithTag("lightBed");
        
        for (int i = 0; i < 6; i++)
        {
            lightMesh[i].SetActive(false);            
        }
        for (int i = 0; i< 4; i++)
        {
            lightBed[i].SetActive(false);
        }

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit, distance))
                {

                    if (hit.collider.gameObject.CompareTag("switchLivingRoom"))
                    {
                        if (lightStatusLiv == false)
                        {
                            for (int i = 0; i < 6; i++)
                            {
                                lightMesh[i].SetActive(true);
                            }
                            lightStatusLiv = true;
                        }
                        else
                        {
                            for (int i = 0; i < 6; i++)
                             {
                                 lightMesh[i].SetActive(false);
                             }
                            lightStatusLiv = false;
                        }
                        
                    }
                    else if (hit.collider.gameObject.CompareTag("switchBedRoom"))
                {
                    if (lightStatusBed == false)
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            lightBed[i].SetActive(true);
                        }
                        lightStatusBed = true;
                    }
                    else
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            lightBed[i].SetActive(false);
                        }
                        lightStatusBed = false;
                    }
                }
            }
        }
    }
}



