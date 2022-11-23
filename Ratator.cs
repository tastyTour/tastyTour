using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ratator : MonoBehaviour
{
    public float rotatespeed= 66f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, rotatespeed * Time.deltaTime, 0f);
    }
}
