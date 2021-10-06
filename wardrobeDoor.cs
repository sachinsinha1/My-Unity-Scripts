using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wardrobeDoor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private bool doorOpen = false;
    private RaycastHit hit;
    private Ray ray;
    private float distance = 3.0f;
    private GameObject doorR;
    private Vector3 doorRpos;
    private GameObject doorL;
    private Vector3 doorLpos;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, distance))
            {
                if (hit.collider.gameObject.CompareTag("wDoor") || hit.collider.gameObject.CompareTag("wDoor1"))
                {
                    doorR = GameObject.FindGameObjectWithTag("wDoor");
                    doorRpos = doorR.transform.position;
                    doorL = GameObject.FindGameObjectWithTag("wDoor1");
                    doorLpos = doorL.transform.position;

                    if (!doorOpen)
                    {
                        doorOpen = true;
                    }
                    else
                    {
                        doorOpen = false;
                    }                    
                }
            }
        }
        if (doorOpen)
        {
            Vector3 targetpos = new Vector3(1.29f, 0.0f, 0.0f) + doorRpos;
            doorR.transform.position = Vector3.Lerp(doorR.transform.position, targetpos, Time.deltaTime * 2f);

            Vector3 targetpos1 = new Vector3(-1.29f, 0.0f, 0.0f) + doorLpos;
            doorL.transform.position = Vector3.Lerp(doorL.transform.position, targetpos1, Time.deltaTime * 2f);
           
        }
        if (!doorOpen)
        {
            
            Vector3 closepos = new Vector3(-1.29f, 0.0f, 0.0f) + doorRpos;
            doorR.transform.position = Vector3.Lerp(doorR.transform.position, closepos, Time.deltaTime * 2f);

            Vector3 closepos2 = new Vector3(1.29f, 0.0f, 0.0f) + doorLpos;
            doorL.transform.position = Vector3.Lerp(doorL.transform.position, closepos2, Time.deltaTime * 2f);
        }
    }
}
