using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ExitCounter : MonoBehaviour
{
    public TextMeshProUGUI signText; // ข้อความในป้าย
    private int counter = 0; // ตัวนับเริ่มต้น
    private const int maxCounter = 8; // ค่ามากที่สุดที่สามารถเพิ่มได้

   

    void Start()
    {
        UpdateSignText(); // อัปเดตป้ายเมื่อเริ่มเกม
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Portal_0")
        {
            ResetCounter(); // รีเซ็ตเป็น 0 เมื่อชน Portal_0
        }
        else if (other.gameObject.name == "Portal_1")
        {
            IncreaseCounter(); // เพิ่มค่าทีละ 1 เมื่อชน Portal_1
        }
    }

    // ฟังก์ชันเพิ่มตัวนับเมื่อผู้เล่นผ่าน Portal_1
    private void IncreaseCounter()
    {
        if (counter < maxCounter)
        {
            counter++; // เพิ่มค่า
        }
        else
        {
            counter = 0; // รีเซ็ตเป็น 0 หากถึงค่าสูงสุด
        }
        UpdateSignText(); // อัปเดตป้าย
    }

    // ฟังก์ชันรีเซ็ตตัวนับเมื่อผู้เล่นผ่าน Portal_0
    private void ResetCounter()
    {
        counter = 0; // รีเซ็ตตัวนับ
        UpdateSignText(); // อัปเดตป้าย
    }

    // ฟังก์ชันอัปเดตตัวเลขในป้าย
    private void UpdateSignText()
    {

            signText.text = counter.ToString(); // แสดงค่าปัจจุบันบนป้าย
       
    }
}
