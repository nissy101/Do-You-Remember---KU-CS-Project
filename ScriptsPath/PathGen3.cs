using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathGenerateV4 : MonoBehaviour
{
    public GameObject startPrefab;
    public List<GameObject> randomPrefabs = new List<GameObject>(); // กำหนด Prefab สุ่ม 5 อัน
    public GameObject endStraightPrefab;
    public GameObject endTurnPrefab;

    private Vector3 currentPos = Vector3.zero;
    private Quaternion currentRot = Quaternion.identity;
    private int segmentCount = 0;
    private const float segmentLength = 40.0f;

    enum SegmentType
    {
        Start,
        Random, // ประเภทสำหรับ Prefab สุ่ม
        EndStraight,
        EndTurn
    }

    void Start()
    {
        // เริ่มต้นด้วยการวาง Segment เริ่มต้น
        PlaceSegment(startPrefab, SegmentType.Start);

        // วาง Segment ตรงกลางโดยสุ่มจาก Prefab ที่มี
        PlaceRandomSegment();

        // วาง Segment สุดท้าย
        PlaceEndSegment();
    }

    void PlaceSegment(GameObject segmentPrefab, SegmentType type)
    {
        // ตรวจสอบว่า Prefab ถูกกำหนดค่าแล้ว
        if (segmentPrefab == null)
        {
            Debug.LogError($"Prefab สำหรับ {type} ยังไม่ได้กำหนดค่า!");
            return;
        }

        // สร้าง Segment ที่ตำแหน่งปัจจุบันและหมุนตามที่กำหนด
        GameObject segment = Instantiate(segmentPrefab, currentPos, currentRot);
        segmentCount++;

        // ปรับตำแหน่งถัดไปตาม segmentLength
        currentPos += currentRot * new Vector3(0, 0, segmentLength);

        // ตรวจสอบตำแหน่งใน Debug
        Debug.Log($"วาง {segment.name} ที่ {segment.transform.position} พร้อมการหมุน {segment.transform.rotation.eulerAngles}");
    }

    void PlaceRandomSegment()
    {
        // ตรวจสอบว่ามี Prefabs ให้สุ่มหรือไม่
        if (randomPrefabs.Count == 0)
        {
            Debug.LogError("ไม่มี Prefab ในรายการสำหรับสุ่ม!");
            return;
        }

        // เลือก Prefab แบบสุ่มจากรายการ
        GameObject selectedPrefab = randomPrefabs[Random.Range(0, randomPrefabs.Count)];

        // วาง Segment ที่สุ่มได้
        PlaceSegment(selectedPrefab, SegmentType.Random);
    }

    void PlaceEndSegment()
    {
        // สุ่มเลือกว่าจะใช้จุดจบทางตรงหรือทางเลี้ยว
        if (Random.value > 0.5f)
        {
            PlaceSegment(endStraightPrefab, SegmentType.EndStraight);
        }
        else
        {
            PlaceSegment(endTurnPrefab, SegmentType.EndTurn);
            currentRot *= Quaternion.Euler(0, 90, 0);
        }

        Debug.Log("วาง Segment สุดท้ายแล้ว");
    }
}
