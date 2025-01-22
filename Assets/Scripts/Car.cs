using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    void Update()
    {
        Move();
    }

    void Move()
    {
        float x = GameManager.Instance.directionX * Time.deltaTime;
        Vector3 newPosition = transform.position;
        newPosition.x += x;

        transform.position = newPosition;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Gas"))
        {
            GameManager.Instance.AddGas(10);
            Destroy(other.gameObject);
        }
    }
}
