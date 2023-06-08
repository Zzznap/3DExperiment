using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterChangeCamera : MonoBehaviour
{
    public Camera main;

    public Camera sub;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            main.enabled = false;
            sub.enabled = true;

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            main.enabled = true;
            sub.enabled = false;

        }
    }
}
