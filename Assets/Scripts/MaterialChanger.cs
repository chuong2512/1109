using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialChanger : MonoBehaviour
{
    public Material[] build;
    int rand;
    // Start is called before the first frame update
    void Start()
    {
       rand =  Random.Range(0, build.Length);
        GetComponent<MeshRenderer>().material = build[rand];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
