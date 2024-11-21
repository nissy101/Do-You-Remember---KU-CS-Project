using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathGenerateV2 : MonoBehaviour
{
    // List ของ Prefabs ที่จะใช้ (S1, S2, L1, L2, R1, R2)
    public GameObject S1, S2, L1, L2, R1, R2;
    public GameObject endPrefab; // จุดจบ
    public int minPathLength = 4; // อย่างน้อย 4 ชิ้นส่วนเส้นทาง

    // ตำแหน่งเริ่มต้นและการหมุน
    private Vector3 currentPosition;
    private Quaternion currentRotation;

    void Start()
    {
        currentPosition = Vector3.zero;
        currentRotation = Quaternion.identity;

        // สร้างเส้นทาง
        for (int i = 0; i < minPathLength; i++)
        {
            GenerateNextPath();
        }

        // วางจุดจบ
        Instantiate(endPrefab, currentPosition, currentRotation);
    }

    void GenerateNextPath()
    {
        GameObject nextPrefab = ChooseNextPrefab(); // เลือก Prefab
        GameObject newPath = Instantiate(nextPrefab, currentPosition, currentRotation);
        UpdatePositionAndRotation(nextPrefab); // อัพเดตตำแหน่งสำหรับชิ้นต่อไป
    }

    GameObject ChooseNextPrefab()
    {
        // คุณสามารถเพิ่มตรรกะในการเลือก Prefab ให้ต่อเนื่องกันอย่างถูกต้อง
        GameObject[] possiblePrefabs = { S1, S2, L1, L2, R1, R2 };
        return possiblePrefabs[Random.Range(0, possiblePrefabs.Length)];
    }

    void UpdatePositionAndRotation(GameObject prefab)
    {
        if (prefab == S1)
        {
            currentPosition += currentRotation * new Vector3(0, 0, 0); // แนวตั้ง
        }
        else if (prefab == S2)
        {
            currentRotation *= Quaternion.Euler(0, 90, 0); // 
            currentPosition += currentRotation * new Vector3(0, 0, 0); // แนวนอน
        }
        else if (prefab == L1)
        {
            currentRotation *= Quaternion.Euler(0, 90, 0); // เลี้ยวซ้ายแนวตั้ง
            currentPosition += currentRotation * new Vector3(0, 0, 0);
        }
        else if (prefab == L2)
        {
            currentRotation *= Quaternion.Euler(0, 180, 0); // เลี้ยวซ้ายแนวนอน
            currentPosition += currentRotation * new Vector3(10, 0, 0);
        }
        else if (prefab == R1)
        {
            currentRotation *= Quaternion.Euler(0, 0, 0); // เลี้ยวขวาแนวตั้ง
            currentPosition += currentRotation * new Vector3(0, 0, 0);
        }
        else if (prefab == R2)
        {
            currentRotation *= Quaternion.Euler(0, 270, 0); // เลี้ยวขวาแนวนอน
            currentPosition += currentRotation * new Vector3(10, 0, 0);
        }
    }
}