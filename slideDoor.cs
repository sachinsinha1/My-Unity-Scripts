using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slideDoor : MonoBehaviour
{
    [SerializeField] private Animator myAnimationController;
    private bool doorOpenS=true;
    private bool doorOpenMain = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (doorOpenMain)
        {
            if (doorOpenS && Input.GetKeyDown(KeyCode.E))
            {
                myAnimationController.SetBool("doorOpen", true);
                doorOpenS = false;
            }
            else if (!doorOpenS && Input.GetKeyDown(KeyCode.E))
            {
                myAnimationController.SetBool("doorOpen", false);
                doorOpenS = true;
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            doorOpenMain = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            doorOpenMain = false;            
        }
    }
}
