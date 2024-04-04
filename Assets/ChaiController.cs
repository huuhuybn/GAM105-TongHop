using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaiController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject target;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = transform.position - target.transform.position;
        //Quaternion quaternion = Quaternion.LookRotation(Vector3.forward,direction);
        //target.transform.rotation = quaternion;

        Quaternion qua2 = Quaternion.FromToRotation(Vector3.forward,direction);

        transform.rotation = Quaternion.Slerp(target.transform.rotation, qua2, 5f * Time.deltaTime);

        
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Vector3 dir = new Vector3(5, 5, 5);
            Quaternion quar = Quaternion.LookRotation(Vector3.forward, dir);
            target.transform.rotation = quar;
            var xoay = Quaternion.Angle(target.transform.rotation, quar);
            Debug.Log(xoay);   
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            Vector3 egler = new Vector3(0, 45, 45);
            Quaternion quar45 = Quaternion.Euler(egler);
            target.transform.rotation = quar45;
            
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
}
