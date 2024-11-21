using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalController3 : MonoBehaviour
{
    public string portal1Name = "Portal_1";
    public string portal0Name = "Portal_0";

    private List<int> sceneIndexes = new List<int>(); // รายการ Scene ที่เหลือให้สุ่ม

    private void Start()
    {
        // กำหนดรายการ Scene 2-16 ที่สามารถสุ่มเล่นได้
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
        // ตรวจสอบว่ามี Scene เหลือให้สุ่มหรือไม่
        if (sceneIndexes.Count > 0)
        {
            // สุ่มเลือก Scene จากรายการที่เหลือ
            int randomIndex = Random.Range(0, sceneIndexes.Count);
            int sceneToLoad = sceneIndexes[randomIndex];

            // โหลด Scene ที่สุ่มได้
            SceneManager.LoadScene(sceneToLoad);

            // ลบ Scene ที่ถูกเล่นออกจากรายการ
            sceneIndexes.RemoveAt(randomIndex);
        }
        else
        {
            Debug.Log("ไม่มี Scene เหลือให้เล่น");
        }
    }

    private void ResetToStartScene()
    {
        // โหลด Scene เริ่มต้น (Scene 1)
        SceneManager.LoadScene(17);

        // รีเซ็ตรายการ Scene ที่สุ่มเล่นได้
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

//    private List<int> sceneIndexes = new List<int>(); // รายการ Scene ที่เหลือให้สุ่ม

//    private void Start()
//    {
//        InitializeScenes();
//    }

//    private void InitializeScenes()
//    {
//        // กำหนด Scene 2-15 เข้ารายการ โดยแต่ละ Scene มีโอกาสสุ่มเท่ากัน
//        for (int i = 18; i <= 27; i++)
//        {
//            sceneIndexes.Add(i);
//        }

//        // เพิ่ม Scene 16 ซ้ำเพื่อเพิ่มโอกาสสุ่ม 1.5 เท่าเมื่อเทียบกับ Scene อื่น ๆ
//        for (int i = 0; i < 2; i++) // เพิ่ม Scene 16 ลงไปสามครั้ง
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

//            // ลบ Scene ที่ถูกเล่นออกจากรายการทั้งหมด
//            sceneIndexes.RemoveAll(scene => scene == sceneToLoad);
//        }
//        else
//        {
//            Debug.Log("ไม่มี Scene เหลือให้เล่น");
//        }
//    }

//    private void ResetToStartScene()
//    {
//        SceneManager.LoadScene(17);

//        // รีเซ็ต Scene ที่เหลือให้สุ่มได้ใหม่
//        sceneIndexes.Clear();
//        InitializeScenes();
//    }
//}