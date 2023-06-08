using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 _offset;
    // Start is called before the first frame update
    void Start()
    {
        //��ȡ��ʼoffset
        _offset = transform.position -player.transform.position;
        _offset.x -= _offset.y;
    }

    // Update is called once per frame
    void Update()
    {
        //��ͷ�����ƶ�
        transform.position = player.transform.position + _offset;
    }
}
