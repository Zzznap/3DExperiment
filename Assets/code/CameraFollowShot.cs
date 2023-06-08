using UnityEngine;
using System.Collections;
/// <summary>
/// Camera move.
/// ���ض��������
/// ���ã��������������
/// </summary>
public class CameraFollowShot : MonoBehaviour
{
    //��������ƶ��ٶ�
    public float moveSpeed = 3f;
    //���������ת�ٶ�
    public  float turnSpeed = 10f;
    //����˽�����
    private Transform m_Player;
    //����������֮��ĳ�ʼƫ����
    private Vector3 offset;
    //���ߵ���ײ��Ϣ
    private RaycastHit hit;
    //����������֮��ľ���
    private float distance;
    //������Ĺ۲��
    private Vector3[] currentPoints;
    //ͨ��Awake�õ���������
    void Awake ()
    {
        //ͨ��tag�ҵ��������
        m_Player = GameObject.FindWithTag ("Player").transform;
        //����һ��v3���͵����飬������5��Ԫ��
        currentPoints = new Vector3[5];
    }
    //��ʼ����Ϸ����
    void Start ()
    {
        //��Ϸ��ʼʱ����������֮��ľ���
        distance = Vector3.Distance (transform.position, m_Player.position);
        //�����ָ�����
        //����������֮���ƫ����
        offset = m_Player.position - transform.position;
    }


    //����������صķŵ�FixedUpdate��
    //LateUpdate���Ա��⿨��
    void LateUpdate ()
    {
        //������۲�ĵ�һ����
        Vector3 startPosition = m_Player.position - offset;
        //����������һ����
        Vector3 endPosition = m_Player.position + Vector3.up * distance;
        //�������������۲��ŵ������У�����1��2,3�����۲��ʹ�����Բ�ֵ�������ƽ���ƶ�Slerp
        currentPoints [1] = Vector3.Slerp (startPosition, endPosition, 0.25f);
        currentPoints [2] = Vector3.Slerp (startPosition, endPosition, 0.5f);
        currentPoints [3] = Vector3.Slerp (startPosition, endPosition, 0.75f);
        currentPoints [0] = startPosition;
        currentPoints [4] = endPosition;
        //����һ�����������洢�̶�֡���Կ�����ҵĹ۲��
        //viewposition = currentPoints [0]
        Vector3 viewposition = currentPoints [0];
        //forѭ��������Щ�㣬����ҵ�����ʵĵ�Ͱ��Ǹ���ǰ�㸳ֵ�����Կ�����ҵĹ۲��CheckView���ĳ�����ܷ񿴵����
        for (int i = 0; i < currentPoints.Length; i++) {
            //�����⵽ĳ������Կ������
            if (CheckView (currentPoints [i])) {
                //�������ǰ�㸳ֵ��viewposition
                viewposition = currentPoints [i];
                //֮�󷵻ز��ڼ�������
            break;
            }
        }
        //��������ƶ����۲��
        transform.position = Vector3.Lerp (transform.position, viewposition, Time.deltaTime * moveSpeed);
        //�����������ת����
        SmoothRotate ();
    }
    /// <summary>
    /// Checks the view.
    /// ���ĳ�����Ƿ���Կ������
    /// </summary>
    /// <returns><c>true</c>, if view was checked, <c>false</c> otherwise.</returns>
    /// <param name="pos">Position.</param>
    //���ĳ�����ܷ񿴵���ҵķ���bool����
    bool CheckView (Vector3 pos)
    {
        //���������۲��֮��ķ�������
        Vector3 dir = m_Player.position - pos;
        //��������
    if (Physics.Raycast (pos, dir, out hit)) {
        //������ߴ����
        if (hit.collider.CompareTag("Player")) {
            //����true
            return true;
        } 
    }
    //��Ȼ����false
    return false;
    }
    /// <summary>
    /// Smooths the rotate.
    /// �������ת�ķ���
    /// </summary>
    /// �������ת�ķ���
    void SmoothRotate ()
    {
        //ָ����ʼλ��
        //���������ҵ�����
        Vector3 m_Dir = m_Player.position - transform.position;
        //Ҫ��ת�ĽǶ�
        Quaternion qua = Quaternion.LookRotation (m_Dir);
        transform.rotation = Quaternion.Lerp (transform.rotation, qua, Time.deltaTime * turnSpeed);
        //�������x,y������
        transform.eulerAngles = new Vector3 (transform.eulerAngles.x, 0, 0);
    }
}

