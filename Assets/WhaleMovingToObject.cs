using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhaleMovingToObject : MonoBehaviour
{
    public Vector3 targetPosition;
    public float moveSpeed;

    void Update()
    {
      Vector3 directionToMove = targetPosition - transform.position;
      directionToMove = directionToMove.normalized * Time.deltaTime * moveSpeed;
      float maxDistance = Vector3.Distance(transform.position, targetPosition);
      transform.position = transform.position + Vector3.ClampMagnitude(directionToMove, maxDistance);
    }

}
