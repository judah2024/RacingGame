using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Road : MonoBehaviour
{
    void Update()
    {
        Vector3 newPosition = transform.position;
        newPosition.z -= GameManager.Instance.RoadSpeed * Time.deltaTime;
        transform.position = newPosition;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("RoadLimit"))
        {
            transform.position = new Vector3(0, 0, 18);
            SpawnGases();
        }
    }

    void SpawnGases()
    {
        for (float z = -9; z < 9; z += 1.5f)
        {
            int flag = Random.Range(0, 2);
            if (flag == 0)
            {
                float x = Random.Range(-1.5f, 1.5f);
                Vector3 position = new Vector3(x, 0, z);
                SpawnGas(position);
            }
        }
    }

    void SpawnGas(Vector3 position)
    {
        GameObject loaded = Resources.Load<GameObject>("Prefabs/Gas");
        GameObject obj = Instantiate(loaded, transform);
        obj.transform.localPosition = position;
    }
}
