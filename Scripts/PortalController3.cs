using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalController3 : MonoBehaviour
{
    public string portal1Name = "Portal_1";
    public string portal0Name = "Portal_0";

    private List<int> sceneIndexes = new List<int>(); // ��¡�� Scene ���������������

    private void Start()
    {
        // ��˹���¡�� Scene 2-16 �������ö���������
        for (int i = 18; i <= 27; i++)
        {
            sceneIndexes.Add(i);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == portal1Name)
        {
            ProcessPortal1();
        }
        else if (other.gameObject.name == portal0Name)
        {
            ResetToStartScene();
        }
    }

    private void ProcessPortal1()
    {
        // ��Ǩ�ͺ����� Scene �������������������
        if (sceneIndexes.Count > 0)
        {
            // �������͡ Scene �ҡ��¡�÷�������
            int randomIndex = Random.Range(0, sceneIndexes.Count);
            int sceneToLoad = sceneIndexes[randomIndex];

            // ��Ŵ Scene ���������
            SceneManager.LoadScene(sceneToLoad);

            // ź Scene ���١����͡�ҡ��¡��
            sceneIndexes.RemoveAt(randomIndex);
        }
        else
        {
            Debug.Log("����� Scene �����������");
        }
    }

    private void ResetToStartScene()
    {
        // ��Ŵ Scene ������� (Scene 1)
        SceneManager.LoadScene(17);

        // ������¡�� Scene ������������
        sceneIndexes.Clear();
        for (int i = 18; i <= 27; i++)
        {
            sceneIndexes.Add(i);
        }
    }
}

//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.SceneManagement;

//public class PortalController3 : MonoBehaviour
//{
//    public string portal1Name = "Portal_1";
//    public string portal0Name = "Portal_0";

//    private List<int> sceneIndexes = new List<int>(); // ��¡�� Scene ���������������

//    private void Start()
//    {
//        InitializeScenes();
//    }

//    private void InitializeScenes()
//    {
//        // ��˹� Scene 2-15 �����¡�� ������ Scene ���͡��������ҡѹ
//        for (int i = 18; i <= 27; i++)
//        {
//            sceneIndexes.Add(i);
//        }

//        // ���� Scene 16 ������������͡������ 1.5 ����������º�Ѻ Scene ��� �
//        for (int i = 0; i < 2; i++) // ���� Scene 16 ŧ��������
//        {
//            sceneIndexes.Add(27);
//        }
//    }

//    private void OnTriggerEnter(Collider other)
//    {
//        if (other.gameObject.name == portal1Name)
//        {
//            ProcessPortal1();
//        }
//        else if (other.gameObject.name == portal0Name)
//        {
//            ResetToStartScene();
//        }
//    }

//    private void ProcessPortal1()
//    {
//        if (sceneIndexes.Count > 0)
//        {
//            int randomIndex = Random.Range(0, sceneIndexes.Count);
//            int sceneToLoad = sceneIndexes[randomIndex];

//            SceneManager.LoadScene(sceneToLoad);

//            // ź Scene ���١����͡�ҡ��¡�÷�����
//            sceneIndexes.RemoveAll(scene => scene == sceneToLoad);
//        }
//        else
//        {
//            Debug.Log("����� Scene �����������");
//        }
//    }

//    private void ResetToStartScene()
//    {
//        SceneManager.LoadScene(17);

//        // ���� Scene ���������������������
//        sceneIndexes.Clear();
//        InitializeScenes();
//    }
//}