using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ExitCounter : MonoBehaviour
{
    public TextMeshProUGUI signText; // ��ͤ���㹻���
    private int counter = 0; // ��ǹѺ�������
    private const int maxCounter = 8; // ����ҡ����ش�������ö������

   

    void Start()
    {
        UpdateSignText(); // �ѻവ����������������
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Portal_0")
        {
            ResetCounter(); // ������ 0 ����ͪ� Portal_0
        }
        else if (other.gameObject.name == "Portal_1")
        {
            IncreaseCounter(); // ������ҷ��� 1 ����ͪ� Portal_1
        }
    }

    // �ѧ��ѹ������ǹѺ����ͼ����蹼�ҹ Portal_1
    private void IncreaseCounter()
    {
        if (counter < maxCounter)
        {
            counter++; // �������
        }
        else
        {
            counter = 0; // ������ 0 �ҡ�֧����٧�ش
        }
        UpdateSignText(); // �ѻവ����
    }

    // �ѧ��ѹ���絵�ǹѺ����ͼ����蹼�ҹ Portal_0
    private void ResetCounter()
    {
        counter = 0; // ���絵�ǹѺ
        UpdateSignText(); // �ѻവ����
    }

    // �ѧ��ѹ�ѻവ����Ţ㹻���
    private void UpdateSignText()
    {

            signText.text = counter.ToString(); // �ʴ���һѨ�غѹ������
       
    }
}
