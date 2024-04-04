using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoController : MonoBehaviour
{
    private bool isDie;

    private bool isMoving;
    private bool isShooting;
    public GameObject bullet;
    public GameObject drop;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            isDie = true;
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            isMoving = true;
            
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            StartCoroutine(startShoot());
        }
        
        if (Input.GetKeyDown(KeyCode.D))
        {
            StartCoroutine(dropInfinite());
        }

        if (isDie)
        {
            rotate360();
        }

        if (isMoving)
        {
            moveToTarget();
        }
    }

    public void setVisiableGameObject()
    {
        gameObject.SetActive(!gameObject.active);
    }

    IEnumerator dropInfinite()
    {
        while (true)
        {
            Instantiate(drop,new Vector3(-1, 6 ,0),Quaternion.identity);
            yield return new WaitForSeconds(2);
        }
    }

    IEnumerator startShoot()
    {
        while (true)
        {
            shooting();
            yield return new WaitForSeconds(1);
        }
    }

    void shooting()
    {
        // sinh ra 4 vien dan, 4 huong khac nhau up , down, left, right 
        BulletController bulletController =
            bullet.GetComponent<BulletController>();
        bulletController.direction = Vector3.up;
        Instantiate(bullet, transform.position, Quaternion.identity);

        bulletController.direction = Vector3.down;
        Instantiate(bullet, transform.position, Quaternion.identity);

        bulletController.direction = Vector3.left;
        Instantiate(bullet, transform.position, Quaternion.identity);

        bulletController.direction = Vector3.right;
        Instantiate(bullet, transform.position, Quaternion.identity);

    }

    void rotate360()
    {
        // 1 quaternion 
        Quaternion xoay = Quaternion.Euler(Vector3.forward * 45f * Time.deltaTime);
        transform.rotation *= xoay;
        
        // 2 transform 
        //transform.Rotate( Vector3.forward * 45f * Time.deltaTime);
    }

    void moveToTarget()
    {
        // tim lay vi tri cua Enemy
        Vector3 target = GameObject.FindWithTag("Enemy").transform.position;
        // di chuyen nhan vat toi vi tri chi dinh 
        transform.position = Vector3.MoveTowards(transform.position, target,
            5f * Time.deltaTime);
    }
    

}
