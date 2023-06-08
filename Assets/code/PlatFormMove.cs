using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatFormMove : MonoBehaviour
{
    enum state
    {
        move,
        stop
    }

    private state nowState = state.stop;
    public Vector3 maxPos;
    public Vector3 minPos;
    private Vector3 targetPos;
    public float moveSpeed = 1.0f;
    [SerializeField]private float stopTimer = 0;
    public float stopTime = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        maxPos = GameObject.Find("MinAndMaxPos").GetComponent<MinAndMaxPos>().maxPos;
        minPos = GameObject.Find("MinAndMaxPos").GetComponent<MinAndMaxPos>().minPos;
        maxPos.y += 10;
        minPos.y += 5;
    }

    // Update is called once per frame
    void Update()
    {
        switch (nowState)
        {
            case state.move:
                Move();
                break;
            case state.stop:
                Stop();
                break;
        }
    }
    //随机获取一个位置
    private void Move()
    {
        stopTimer = Time.time;
        if (Vector3.Distance(transform.position, targetPos) > 0.1f)
        {
            transform.position  = Vector3.Lerp(transform.position, targetPos, moveSpeed * Time.deltaTime);
        }
        else
        {
            nowState = state.stop;
        }
    }

    private void Stop()
    {
        
        if (Time.time - stopTimer > stopTime)
        {
            targetPos = GetRandomPos();
            nowState = state.move;
        }
    }
    public Vector3 GetRandomPos()
    {
        float x = Random.Range(minPos.x, maxPos.x);
        float y = Random.Range(minPos.y, maxPos.y);
        float z = Random.Range(minPos.z, maxPos.z);
        return new Vector3(x,y,z);
    }
    
}
