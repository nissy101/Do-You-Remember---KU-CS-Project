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

    public int totalSegments = 5; // ���������鹷ҧ����˹���
    private Vector3 currentPos = Vector3.zero;
    private Quaternion currentRot = Quaternion.identity;
    private int segmentCount = 0;

    void Start()
    {
        // �ҧ S0 �繨ش�������
        PlaceSegment(startPrefab);

        // �ҧ��ǹ��� 2 ��� 3 �������ö�����ǫ������͢����
        for (int i = 1; i < totalSegments - 1; i++)
        {
            PlaceNextSegment(i);
        }

        // �ҧ��ǹ�ش����
        PlaceEndSegment();
    }

    void PlaceSegment(GameObject segmentPrefab)
    {
        // ���ҧ Prefab �����˹觻Ѩ�غѹ�����ع�������˹�
        GameObject segment = Instantiate(segmentPrefab, currentPos, currentRot);
        segmentCount++;

        // ��Ѻ���˹觶Ѵ仵����Ҵ�ͧ Prefab (4:1:4)
        currentPos += currentRot * new Vector3(0, 0, 40); // ���ͧ�ҡ scale Z = 4

        // ��Ǩ�ͺ Debug
        Debug.Log($"Placed {segment.name} at {segment.transform.position} with rotation {segment.transform.rotation.eulerAngles}");
    }

    void PlaceNextSegment(int segmentIndex)
    {
        if (Random.value > 0.5f)
        {
            // �ҧ�ҧ�ç
            PlaceSegment(straightPrefab);
        }
        else
        {
            // �ҧ�ҧ�����Ǣ��
            PlaceSegment(turnRightPrefab);

            // ����¹��ȷҧ�ͧ�������͹��������˹� X
            if (currentRot == Quaternion.Euler(0, 0, 0))
            {
                currentRot *= Quaternion.Euler(0, 90, 0); // ������价ҧ��� (X+)
                currentPos += currentRot * new Vector3(40, 0, 0); // ��Ѻ���˹�仵�� X+
            }
            else if (currentRot == Quaternion.Euler(0, 90, 0))
            {
                currentRot *= Quaternion.Euler(0, 90, 0); // ������价ҧ��� (X-)
                currentPos += currentRot * new Vector3(-40, 0, 0); // ��Ѻ���˹�仵�� X-
            }
        }
    }

    void PlaceEndSegment()
    {
        // �ҧ�ش�� ����Ҩ�繷ҧ�ç���ͷҧ�����Ǣ��
        if (Random.value > 0.5f)
        {
            PlaceSegment(endStraightPrefab);
        }
        else
        {
            PlaceSegment(endTurnRightPrefab);
            currentRot *= Quaternion.Euler(0, 90, 0); // �������͡
        }

        Debug.Log("End Segment Placed.");
    }
}
