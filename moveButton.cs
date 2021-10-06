using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveButton : MonoBehaviour
{
    private RaycastHit hit;
    private Ray ray;
    private float distance = 3.0f;
    public GameObject eButton;
    private Vector3 saveButtonPos;
    // Start is called before the first frame update
    void Start()
    {
        eButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, distance))
        {
            if (hit.collider.gameObject.CompareTag("switchLivingRoom") && distance == 3.0f)
            {
                Vector3 center = hit.collider.gameObject.transform.position;
                saveButtonPos = center;
                center += new Vector3(0, 0, 0.1f);
                eButton.transform.position = center;
                eButton.SetActive(true);
                
            }
        }
        else
        {
            eButton.SetActive(false);
        }
    }
}
