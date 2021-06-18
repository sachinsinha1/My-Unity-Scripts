using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private bool doorOpen = false;
    private RaycastHit hit;
    private Ray ray;
    private float distance = 3.0f;
    private GameObject doorA;
    private int test = 1;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
            if (Physics.Raycast(ray, out hit, distance))
            {
             
                if (hit.collider.gameObject.CompareTag("Door") || hit.collider.gameObject.CompareTag("Door1"))
                {
                    doorA = hit.collider.gameObject;

                    if (!doorOpen)
                    {
                        doorOpen = true;
                    }
                    else
                    {
                        doorOpen = false;
                    }
                    if (hit.collider.gameObject.CompareTag("Door"))
                    {
                        test = 1;
                    }
                    if (hit.collider.gameObject.CompareTag("Door1"))
                    {
                        test = -1;
                    }


                }                
            }
        }
        if (doorOpen)
        {
            Quaternion target = Quaternion.Euler(0.0f, 90.0f*test, 0.0f);
            doorA.transform.rotation = Quaternion.Lerp(doorA.transform.rotation, target, Time.deltaTime * 2f);            
        }
        if (!doorOpen)
        {
            Quaternion target2 = Quaternion.Euler(0.0f, 0.0f, 0.0f);
            doorA.transform.rotation = Quaternion.Lerp(doorA.transform.rotation, target2, Time.deltaTime * 2f);                  
        }

    }
}



