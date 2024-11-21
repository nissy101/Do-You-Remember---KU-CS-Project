using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathGenerateV4 : MonoBehaviour
{
    public GameObject startPrefab;
    public List<GameObject> randomPrefabs = new List<GameObject>(); // ��˹� Prefab ���� 5 �ѹ
    public GameObject endStraightPrefab;
    public GameObject endTurnPrefab;

    private Vector3 currentPos = Vector3.zero;
    private Quaternion currentRot = Quaternion.identity;
    private int segmentCount = 0;
    private const float segmentLength = 40.0f;

    enum SegmentType
    {
        Start,
        Random, // ����������Ѻ Prefab ����
        EndStraight,
        EndTurn
    }

    void Start()
    {
        // ������鹴��¡���ҧ Segment �������
        PlaceSegment(startPrefab, SegmentType.Start);

        // �ҧ Segment �ç��ҧ�������ҡ Prefab �����
        PlaceRandomSegment();

        // �ҧ Segment �ش����
        PlaceEndSegment();
    }

    void PlaceSegment(GameObject segmentPrefab, SegmentType type)
    {
        // ��Ǩ�ͺ��� Prefab �١��˹��������
        if (segmentPrefab == null)
        {
            Debug.LogError($"Prefab ����Ѻ {type} �ѧ������˹����!");
            return;
        }

        // ���ҧ Segment �����˹觻Ѩ�غѹ�����ع�������˹�
        GameObject segment = Instantiate(segmentPrefab, currentPos, currentRot);
        segmentCount++;

        // ��Ѻ���˹觶Ѵ仵�� segmentLength
        currentPos += currentRot * new Vector3(0, 0, segmentLength);

        // ��Ǩ�ͺ���˹�� Debug
        Debug.Log($"�ҧ {segment.name} ��� {segment.transform.position} ����������ع {segment.transform.rotation.eulerAngles}");
    }

    void PlaceRandomSegment()
    {
        // ��Ǩ�ͺ����� Prefabs ��������������
        if (randomPrefabs.Count == 0)
        {
            Debug.LogError("����� Prefab ���¡������Ѻ����!");
            return;
        }

        // ���͡ Prefab Ẻ�����ҡ��¡��
        GameObject selectedPrefab = randomPrefabs[Random.Range(0, randomPrefabs.Count)];

        // �ҧ Segment ���������
        PlaceSegment(selectedPrefab, SegmentType.Random);
    }

    void PlaceEndSegment()
    {
        // �������͡��Ҩ���ش���ҧ�ç���ͷҧ������
        if (Random.value > 0.5f)
        {
            PlaceSegment(endStraightPrefab, SegmentType.EndStraight);
        }
        else
        {
            PlaceSegment(endTurnPrefab, SegmentType.EndTurn);
            currentRot *= Quaternion.Euler(0, 90, 0);
        }

        Debug.Log("�ҧ Segment �ش��������");
    }
}
