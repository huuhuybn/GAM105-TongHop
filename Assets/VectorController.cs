using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject target;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += target.transform.position * 2f * Time.deltaTime;

        }

        
    }
}
