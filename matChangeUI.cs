using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class matChangeUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //can.gameObject.SetActive(false);

        TextureHolder.SetActive(false);
        BedRoomTexture1.SetActive(false);
        BedRoomTexture2.SetActive(false);
    }

    private RaycastHit hit;
    private Ray ray;
    private float distance = 5.0f;
    //public Canvas can;
    public GameObject TextureHolder;
    public GameObject BedRoomTexture1;
    public GameObject BedRoomTexture2;
    private bool canvasEnable = false;
    private float mouseSensitivityChange = 5.0f;
    private float savemouseSensitivity;
    private LookWithMouse lookwithmouse;

    private void Awake()
    {
        lookwithmouse = GameObject.FindObjectOfType<LookWithMouse>();        
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (canvasEnable == false)
            {
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit, distance))
                {

                    if (hit.collider.gameObject.CompareTag("floor") || hit.collider.gameObject.CompareTag("bedroomfloor") || hit.collider.gameObject.CompareTag("bedroomfloor2"))
                    {
                        //can.gameObject.SetActive(false);
                        if (hit.collider.gameObject.CompareTag("floor"))
                        {
                            TextureHolder.SetActive(true);
                        }
                        if (hit.collider.gameObject.CompareTag("bedroomfloor"))
                        {
                            BedRoomTexture1.SetActive(true);
                        }
                        if (hit.collider.gameObject.CompareTag("bedroomfloor2"))
                        {
                            BedRoomTexture2.SetActive(true);
                        }
                        Cursor.lockState = CursorLockMode.None;
                        Cursor.visible = true;
                        canvasEnable = true;
                        savemouseSensitivity = lookwithmouse.mouseSensitivity;
                        lookwithmouse.mouseSensitivity = mouseSensitivityChange;
                        //Debug.Log(hit.point);
                    }

                }
            }
            else
            {
                TextureHolder.SetActive(false);
                BedRoomTexture1.SetActive(false);
                BedRoomTexture2.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                canvasEnable = false;
                lookwithmouse.mouseSensitivity = savemouseSensitivity;
            }
        }
        
        if (Input.GetKeyDown(KeyCode.Escape) && canvasEnable == true)
        {
            TextureHolder.SetActive(false);
            BedRoomTexture1.SetActive(false);
            BedRoomTexture2.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            canvasEnable = false;
            lookwithmouse.mouseSensitivity = savemouseSensitivity;
        }
        
    }
}
