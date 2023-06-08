using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieWall : MonoBehaviour
{
    public Vector3 initPos;
    // Start is called before the first frame update
    public GameObject player;
    public int subScore = 5;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        initPos = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SubScore();
            player.transform.position = initPos;
            player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }
    void SubScore()
    {
        player.GetComponent<PlayerController>().ChangeCount(-subScore);
    }
}
