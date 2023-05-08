using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SardineMovingToObject : MonoBehaviour
{
  public Transform target;
  public float speed = 5f;
    void Start()
    {

    }

    void Update()
    {
        if (target == null) return; // If target is not set, exit early.

        Vector3 direction = (target.position - transform.position).normalized;
        float distance = Vector3.Distance(transform.position, target.position);

        if (distance > 0)
        {
            transform.position += direction * speed * Time.deltaTime;
        }
        if (distance == 0)
        {
            speed = 0f;
        }
    }
}
