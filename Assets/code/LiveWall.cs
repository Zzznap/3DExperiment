using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class LiveWall : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 maxPos;
    public Vector3 minPos;
    public GameObject player;
    public Vector3 initPos;
    public int addScore = 10;   
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        maxPos = GameObject.Find("MinAndMaxPos").GetComponent<MinAndMaxPos>().maxPos;
        minPos = GameObject.Find("MinAndMaxPos").GetComponent<MinAndMaxPos>().minPos;
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
            AddScore();
            player.transform.position = initPos;
            player.GetComponent<Rigidbody>().velocity = Vector3.zero;
            ChangePosion();
        }
    }
    //给玩家加分
    void AddScore()
    {
        player.GetComponent<PlayerController>().ChangeCount(addScore);
    }

    void ChangePosion()
    {
        transform.position =
            new Vector3(Random.Range(minPos.x, maxPos.x), maxPos.y, Random.Range(minPos.z, maxPos.z));

    }
}
