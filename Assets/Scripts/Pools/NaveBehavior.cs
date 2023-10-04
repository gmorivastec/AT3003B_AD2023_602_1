using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions;

public class NaveBehavior : MonoBehaviour
{
    [SerializeField] private float _speed = 5;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        transform.Translate(
            h * _speed * Time.deltaTime,
            v * _speed * Time.deltaTime,
            0    
        );

        if(Input.GetButtonDown("Jump"))
        {
            BalaPool.Instance.GetFromPool(transform.position, transform.rotation);
        }
    }
}
