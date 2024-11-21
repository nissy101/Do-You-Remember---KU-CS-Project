using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathGenerateV2 : MonoBehaviour
{
    // List �ͧ Prefabs ������ (S1, S2, L1, L2, R1, R2)
    public GameObject S1, S2, L1, L2, R1, R2;
    public GameObject endPrefab; // �ش��
    public int minPathLength = 4; // ���ҧ���� 4 �����ǹ��鹷ҧ

    // ���˹����������С����ع
    private Vector3 currentPosition;
    private Quaternion currentRotation;

    void Start()
    {
        currentPosition = Vector3.zero;
        currentRotation = Quaternion.identity;

        // ���ҧ��鹷ҧ
        for (int i = 0; i < minPathLength; i++)
        {
            GenerateNextPath();
        }

        // �ҧ�ش��
        Instantiate(endPrefab, currentPosition, currentRotation);
    }

    void GenerateNextPath()
    {
        GameObject nextPrefab = ChooseNextPrefab(); // ���͡ Prefab
        GameObject newPath = Instantiate(nextPrefab, currentPosition, currentRotation);
        UpdatePositionAndRotation(nextPrefab); // �Ѿവ���˹�����Ѻ��鹵���
    }

    GameObject ChooseNextPrefab()
    {
        // �س����ö������á�㹡�����͡ Prefab ��������ͧ�ѹ���ҧ�١��ͧ
        GameObject[] possiblePrefabs = { S1, S2, L1, L2, R1, R2 };
        return possiblePrefabs[Random.Range(0, possiblePrefabs.Length)];
    }

    void UpdatePositionAndRotation(GameObject prefab)
    {
        if (prefab == S1)
        {
            currentPosition += currentRotation * new Vector3(0, 0, 0); // �ǵ��
        }
        else if (prefab == S2)
        {
            currentRotation *= Quaternion.Euler(0, 90, 0); // 
            currentPosition += currentRotation * new Vector3(0, 0, 0); // �ǹ͹
        }
        else if (prefab == L1)
        {
            currentRotation *= Quaternion.Euler(0, 90, 0); // �����ǫ����ǵ��
            currentPosition += currentRotation * new Vector3(0, 0, 0);
        }
        else if (prefab == L2)
        {
            currentRotation *= Quaternion.Euler(0, 180, 0); // �����ǫ����ǹ͹
            currentPosition += currentRotation * new Vector3(10, 0, 0);
        }
        else if (prefab == R1)
        {
            currentRotation *= Quaternion.Euler(0, 0, 0); // �����Ǣ���ǵ��
            currentPosition += currentRotation * new Vector3(0, 0, 0);
        }
        else if (prefab == R2)
        {
            currentRotation *= Quaternion.Euler(0, 270, 0); // �����Ǣ���ǹ͹
            currentPosition += currentRotation * new Vector3(10, 0, 0);
        }
    }
}