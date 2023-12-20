using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
//using UnityEngine.EventSystems;

public class Car : MonoBehaviour
{
    public float moveSpeed = 50f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.S))
        {
            //Debug.Log("Hello, World");
            transform.Translate(Time.deltaTime * new Vector3(0, 0, moveSpeed));
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Time.deltaTime * new Vector3(0, 0, -moveSpeed));
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Time.deltaTime * new Vector3(-moveSpeed, 0, 0));
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Time.deltaTime * new Vector3(moveSpeed, 0, 0));
        }
    }
}
