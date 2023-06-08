using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowSpeed : MonoBehaviour
{
    private Rigidbody _rb;
    //线条对象
    private LineRenderer _lineRenderer;
    // Start is called before the first frame update
    void Start()
    {
        _rb =GetComponent<Rigidbody>();
        Vector3 position = transform.position;

        _lineRenderer = GetComponent<LineRenderer>();
        _lineRenderer.SetPosition(0, position);
        _lineRenderer.SetPosition(1, position);
    }

    // Update is called once per frame
    void Update()
    {
        //计算速度
        Vector3 speed = _rb.velocity;
        //画出速度
        Vector3 position = transform.position;
        _lineRenderer.SetPosition(0, position);
        _lineRenderer.SetPosition(1, position + speed);
    }
}
