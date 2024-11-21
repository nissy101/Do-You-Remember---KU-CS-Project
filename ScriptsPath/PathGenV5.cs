using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathGenV5 : MonoBehaviour
{
    public GameObject startPrefab;
    public GameObject straightPrefab;
    public GameObject turnRightPrefab;
    public GameObject endStraightPrefab;
    public GameObject endTurnRightPrefab;

    public int totalSegments = 5; // ความยาวเส้นทางที่กำหนดได้
    private Vector3 currentPos = Vector3.zero;
    private Quaternion currentRot = Quaternion.identity;
    private int segmentCount = 0;

    void Start()
    {
        // วาง S0 เป็นจุดเริ่มต้น
        PlaceSegment(startPrefab);

        // วางส่วนที่ 2 และ 3 ที่สามารถเลี้ยวซ้ายหรือขวาได้
        for (int i = 1; i < totalSegments - 1; i++)
        {
            PlaceNextSegment(i);
        }

        // วางส่วนสุดท้าย
        PlaceEndSegment();
    }

    void PlaceSegment(GameObject segmentPrefab)
    {
        // สร้าง Prefab ที่ตำแหน่งปัจจุบันและหมุนตามที่กำหนด
        GameObject segment = Instantiate(segmentPrefab, currentPos, currentRot);
        segmentCount++;

        // ปรับตำแหน่งถัดไปตามขนาดของ Prefab (4:1:4)
        currentPos += currentRot * new Vector3(0, 0, 40); // เนื่องจาก scale Z = 4

        // ตรวจสอบ Debug
        Debug.Log($"Placed {segment.name} at {segment.transform.position} with rotation {segment.transform.rotation.eulerAngles}");
    }

    void PlaceNextSegment(int segmentIndex)
    {
        if (Random.value > 0.5f)
        {
            // วางทางตรง
            PlaceSegment(straightPrefab);
        }
        else
        {
            // วางทางเลี้ยวขวา
            PlaceSegment(turnRightPrefab);

            // เปลี่ยนทิศทางของการเคลื่อนที่ตามตำแหน่ง X
            if (currentRot == Quaternion.Euler(0, 0, 0))
            {
                currentRot *= Quaternion.Euler(0, 90, 0); // เลี้ยวไปทางขวา (X+)
                currentPos += currentRot * new Vector3(40, 0, 0); // ปรับตำแหน่งไปตาม X+
            }
            else if (currentRot == Quaternion.Euler(0, 90, 0))
            {
                currentRot *= Quaternion.Euler(0, 90, 0); // เลี้ยวไปทางขวา (X-)
                currentPos += currentRot * new Vector3(-40, 0, 0); // ปรับตำแหน่งไปตาม X-
            }
        }
    }

    void PlaceEndSegment()
    {
        // วางจุดจบ ซึ่งอาจเป็นทางตรงหรือทางเลี้ยวขวา
        if (Random.value > 0.5f)
        {
            PlaceSegment(endStraightPrefab);
        }
        else
        {
            PlaceSegment(endTurnRightPrefab);
            currentRot *= Quaternion.Euler(0, 90, 0); // เลี้ยวออก
        }

        Debug.Log("End Segment Placed.");
    }
}
