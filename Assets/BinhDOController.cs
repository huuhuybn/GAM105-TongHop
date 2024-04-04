using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class BinhDOController : MonoBehaviour
{
    public GameObject violet;
    public float count = 0f;
    public StoreData data;
    public Slider bar;
    public ToggleGroup _group;

    private void Start()
    {
        foreach (Toggle toggle  in _group.GetComponentsInChildren<Toggle>())
        {
            toggle.onValueChanged.AddListener(delegate(bool arg0) { onChangeToggle(toggle);  });
        }
        StartCoroutine(genGameObject());
        StartCoroutine(checkTimeOUT());
        StartCoroutine(checkWin());
    }

    private int diemSo = 0;

    IEnumerator checkWin()
    {
        yield return new WaitUntil(()=> diemSo > 100);
        Debug.Log("NEXT Level");
    }
    

    IEnumerator checkTimeOUT()
    {
        yield return new WaitForSeconds(60);
        // kiem tra dieu kien win
    }
    IEnumerator genGameObject()
    {
        yield return new WaitForSeconds(3);
        Instantiate(violet, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(2);
        Instantiate(violet, transform.position, Quaternion.identity);
        
        yield return new WaitForSeconds(1);
        Instantiate(violet, transform.position, Quaternion.identity);
    }

    IEnumerator nextLevel()
    {
        // chờ tới khi hàm isNextLevel trả về true 
        yield return new WaitUntil(()=> _scrore > 100);
        Debug.Log("Next Level");
    }
    
    private bool _isNext;
    private int _scrore = 10;

    // dai dien cho 6 nut
    private String[] items = { "1", "2", "3", "4", "5", "6" };
    // xac suat 
    private float[] pro = { 0.2f, 0.1f, 0.1f, 0.1f, 0.05f, 0.05f };

    void GenNumber()
    {
        int index = 0;
        float random = Random.value;
        for (int i = 0; i < pro.Length; i++)
        {
            if (random < pro[i])
            {
                index = i;
                break;
            }
            random -= pro[i];
        }
        Debug.Log("Number : " + items[index]);
    }
    void NextLevel()
    {
        _isNext = true;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            diemSo++;
        }
        
        
        if (Input.GetKeyDown(KeyCode.K))
        {
            data.count++;
            Debug.Log(data.count);
            bar.value--;
            if (bar.value == 80)
            {
                bar.GetComponentInChildren<Image>().color = Color.blue;
            }else if (bar.value == 20)
            {
                bar.GetComponentInChildren<Image>().color = Color.green;
            }
        }

      
        
        //Vector3 direction = transform.position - violet.transform.position;
        //Quaternion quaternion = Quaternion.LookRotation(Vector3.forward,
        //  direction);
        //violet.transform.rotation = quaternion;
        //var xoay = Quaternion.Angle(violet.transform.rotation, quaternion);
        //Debug.Log(xoay);

        var de = new Vector3(0, 0, 90);
        Quaternion de_ = Quaternion.Euler(de);
        Quaternion quater = Quaternion.Slerp(Quaternion.identity, de_, count);
        count +=Time.deltaTime  *  0.1f;
        transform.rotation = quater;

        if (Input.GetKeyDown(KeyCode.R))
        {
            var degree = new Vector3(0, 0, 90);
            Quaternion quar = Quaternion.Euler(degree);
            violet.transform.rotation = quar;
        }
        
        
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * 5f * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * 5f * Time.deltaTime);
        }
    }

    void onChangeToggle(Toggle toggle)
    {
        bool isCheck = toggle.isOn;
        string labelText = toggle.GetComponentInChildren<Text>().text;
        string name = toggle.GetComponentInChildren<GameObject>().name;
        Debug.Log(labelText  + " -- " + name);
    }

 

    public void isCheck(bool toggle)
    {
        if (toggle)
        {
            Debug.Log("TIKT TIK");
        }
        else
        {
            Debug.Log("NO NONONO");
        }
    }

    
}
