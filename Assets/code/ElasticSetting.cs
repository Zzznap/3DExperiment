using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElasticSetting : MonoBehaviour
{
    // Start is called before the first frame update
    public float elasticPower=10f;
    [SerializeField] private GameObject player;
    public float maxTimer = 2f;
    [SerializeField] private float startTimer = 0f;
    [SerializeField] private Boolean startTimerFlag = false;
    public float maxJumpScale = 2f;
    [SerializeField] private float jumpScale = 1f;
    public float jumpScaleSmooth = 0.5f;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (startTimerFlag && Input.GetButton("Jump"))
        {
            jumpScale =Mathf.Lerp (jumpScale,maxJumpScale,jumpScaleSmooth*Time.deltaTime);
        }
        if (startTimerFlag && (Time.time - startTimer > maxTimer || Input.GetButtonUp("Jump")))
        {
            //��ȡ�����������
            startTimerFlag = false;
            //��ȡ������������ĵ���ֵ
            // ElasticSetting elasticSetting = other.gameObject.GetComponent<ElasticSetting>();
            // float elasticPower = elasticSetting.ElasticPower;
            //��ȡ��Ҹ������
            Rigidbody rb = player.GetComponent<Rigidbody>();
            //����Ҹ���ʩ����
            rb.AddForce(Vector3.up*jumpScale * elasticPower, ForceMode.Impulse);
            jumpScale = 1f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            startTimerFlag = true;
            startTimer = Time.time;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            startTimerFlag = false;
        }
    }
}
