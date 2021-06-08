using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeMat : MonoBehaviour
{

    public Material[] material;
    public Renderer renderMat;
    public int x;

    // Start is called before the first frame update
    void Start()
    {
        x = 0;
        renderMat = GetComponent<Renderer>();
        renderMat.enabled = true;
        renderMat.sharedMaterial = material[x];
    }

    // Update is called once per frame
    void Update()
    {
        renderMat.sharedMaterial = material[x];
    }

    public void mat1()
    {
        x = 0;
    }

    public void mat2()
    {
        x = 1;
    }

    public void mat3()
    {
        x = 2;
    }

    public void mat4()
    {
        x = 3;
    }
}
