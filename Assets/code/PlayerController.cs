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
        //��ȡrigidbody���
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //��ȡˮƽ������
        float horizontal = Input.GetAxis("Horizontal");
        //��ȡ��ֱ������
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
