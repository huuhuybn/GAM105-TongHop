using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class CircleController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public GameObject chai;
    // Update is called once per frame
    void Update()
    {
        
        // di chuyen  nhan vat toi vi tri cua Chai 
        transform.position = Vector3.MoveTowards(transform.position, chai.transform.position,
            5f * Time.deltaTime);
        
        if (Input.GetKeyDown(KeyCode.A))
        {
            // phép cộng vector đơn giản, thay đổi vị trí 
            // tăng thêm 5 đơn vị cho x, y 
            transform.position += new Vector3(5,5,0);
        }

        if (Input.GetKey(KeyCode.S))
        {
            Vector3 vitriChai = chai.transform.position;
            Vector3 position = vitriChai * 5f * Time.deltaTime;
            Vector3 postionNomarlized = position.normalized; // chỉ chứa thông tin về hướng 
            // di chuyee gameObact theo huong Vector 
            transform.position += position;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            Vector3 pos1 = transform.position;
            Vector3 pos2 = chai.transform.position;
            Vector3 direction = pos1 - pos2;
            Vector3 directionR = pos2 - pos1;
            Debug.Log("Huong 1: "  +  direction);
            Debug.Log("Huong 2: "  +  directionR);
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            // phep nhan Vector 
            Vector3 cross = Vector3.Cross(transform.position, chai.transform.position);
            //  croos là kết quả của 2 vector cso gái trị vuông góc với 2 vector đầu vào 
            
            // kiem tra xem, 1 đối đướng có đang hướng về 1 đối tượng khác không ??? 

            Vector3 forward = Vector3.back;
            Vector3 directon = chai.transform.position - transform.position;

            var ketQua = Vector3.Dot(forward.normalized, directon.normalized);
            if (ketQua > 0 )
            {
                Debug.Log("Muc tieu o phia truoc");
            }
            else
            {
                Debug.Log("Muc tieu o phia sau");
            }
        }
        
    }
}
