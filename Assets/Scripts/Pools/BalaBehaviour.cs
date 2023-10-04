using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaBehaviour : MonoBehaviour
{
    [SerializeField] private float _speed = 5;
    [SerializeField] private float _timerForDestruction = 5;

    void OnEnable()
    {
        // posibles estrategias de destrucción - 
        // 1. por tiempo
        // 2. objeto se dejo de ver
        // 3. objeto chocó con algo que lo destruyó

        // vamos a hacer un timer
        StartCoroutine(DestructionTimer(_timerForDestruction));
    }

    void OnDisable()
    {
        StopAllCoroutines();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(
            0,
            _speed * Time.deltaTime,
            0
        );    
    }


    IEnumerator DestructionTimer(float time) 
    {
        yield return new WaitForSeconds(time);
        BalaPool.Instance.ReturnToPool(this);
    }
}
