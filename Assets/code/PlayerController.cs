using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float power = 10f;
    Rigidbody rb;
    public TextMeshProUGUI  text;
    public int count;

    [SerializeField] private float elasticTimer;
    public float maxElasticTimer = 2f;

    public float jumpScale = 10f;
    // Start is called before the first frame update
    void Start()
    {
        elasticTimer = 0;
        count = 0;
        if (text.IsUnityNull())
            text = GameObject.Find("count").GetComponent<TextMeshProUGUI>();
        SetCountText();
        //获取rigidbody组件
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //获取水平轴输入
        float horizontal = Input.GetAxis("Horizontal");
        //获取垂直轴输入
        float vertical = Input.GetAxis("Vertical");
        Vector3 velocities = new Vector3(horizontal, 0, vertical);
        rb.AddForce(velocities * power * Time.deltaTime);
        
    }
    
    private void OnTriggerEnter(Collider other)
    {
        elasticTimer = Time.time;
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            ChangeCount(10);
        }

    }
   
    void SetCountText()
    {
        text.text = "Count: " + count;

    }
    public void ChangeCount(int change)
    {
        count += change;
        SetCountText();
    }
}
