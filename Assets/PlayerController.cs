using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerController : MonoBehaviour
{
    private SpriteRenderer _renderer;
    public GameObject prefab;
    public GameObject broken;
    private AudioSource sound;
    void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
        sound = GetComponent<AudioSource>();
    }

    private int count = 0;
    public int level = 100;
    void Update()
    {
        count++;
        if (count > level )
        {
            int rand = Random.Range(-8, 9);
            GameObject obj = Instantiate(prefab, new Vector2(rand,8f),
                Quaternion.identity);
            Destroy(obj,2);
            count = 0;
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            // 1, doi tuong prefab se copy 
            // 2. vi tri xuat hien 
            // 3. Rotation mac dinh 
        
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * 5f * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * 5f * Time.deltaTime);   
        }

        if (Input.GetKey(KeyCode.Z))
        {
            transform.localScale = new Vector3(5, 5, 5);
            // luu y : việc phóng to, thu nhỏ bằng scale cũng gây ảnh hưởng tới 
            // các component khác ví dụ như : collider hoặc rigidbody 
        }

        if (Input.GetKeyUp(KeyCode.Z))
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        
        if (Input.GetKey(KeyCode.R))
        {
            transform.rotation = Quaternion.Euler(0,0,90);
            // luu y : việc phóng to, thu nhỏ bằng scale cũng gây ảnh hưởng tới 
            // các component khác ví dụ như : collider hoặc rigidbody 
        }

        if (Input.GetKeyUp(KeyCode.R))
        {
            transform.rotation = Quaternion.Euler(0,0,0);
        }

        if (Input.GetKey(KeyCode.F))
        { 
            // lấy ra vị trí hiên tại của nhân vật 
            var vitriNhanvat = transform.position;
            
            // áp dụng hướng 
            // 1. Vector3.forward 
            // 2 . rigidbody2D.velocity  :
            var target = new Vector3(4, 4, 0);
            transform.position = Vector3
                .MoveTowards(vitriNhanvat,  target , 5f * Time.deltaTime);
            // áp dụng tốc độ cho đối dượng đc gắn rigigbody2D theo hướng của vector 

        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            var newPosition = transform.position + new Vector3(5, 5, 0);
            transform.position = newPosition;
        }

        if (Input.GetKey(KeyCode.G))
        {
            var target = new Vector3(6, 6, 0);
            var phepTru =  target -  transform.position; // phép trừ vector . lấy ra hướng di chuyển 
            var phepTruNomarlized = phepTru.normalized;
            // tù vị trí nhân vật tới vị trí muc tiêu 
            // áp dụng di duyển theo hướng mục tiêu khớp với thời gian cập nhật FPS 
            transform.position += phepTru * 5f * Time.deltaTime;

        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            var vectorA = new Vector3(0,0,0);
            var vectorB = new Vector3(5,5,0);
            // phap nhan 2 vector
            float dotProduct = Vector3.Dot(vectorA.normalized, vectorB.normalized);
            float angleInRadians = Mathf.Acos(dotProduct); // Trả về góc trong Radians
            float angleInDegrees = angleInRadians * Mathf.Rad2Deg; // Chuyển đổi sang Degrees

            Debug.Log("Góc giữa hai vector là: " + angleInDegrees + " độ");

            
        }
        
        
    }

    public int score = 0;
    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "rock")
        {
            score++;
            Vector3 bottlePosition = other.gameObject.transform.position;
            Destroy(other.gameObject);
            // phat nhac
            // xuat hien cai chai vo 
            GameObject bro = Instantiate(broken, bottlePosition, Quaternion.identity);
            Destroy(bro,0.5f);
            sound.Play();
        }
    }
    private void OnCollisionStay2D(Collision2D other)
    {
    }
    private void OnCollisionExit2D(Collision2D other)
    {
    }
}

