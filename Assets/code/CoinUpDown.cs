
using System;
using UnityEngine;

public class CoinUpDown : MonoBehaviour
{
    public float maxUpDownDistance = 1f;

    private float _nowMove = 0.0f;
    private float _timer = 0;
    private Vector3 _initPos;
    private void Start()
    {
        _timer = Time.time;
        _initPos = transform.position;

    }

    void Update()
    {
         
         _nowMove = maxUpDownDistance * Mathf.Sin(Time.time - _timer);
         transform.position = _initPos+new Vector3(0,_nowMove,0) ;
        
    }

}
