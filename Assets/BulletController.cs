using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,2);
        
    }

    public Vector3 direction;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * 
                            5f * Time.deltaTime);
    }
}
