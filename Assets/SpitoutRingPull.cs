using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpitoutRingPull : MonoBehaviour
{
  public Vector3 startPosition;
      public Vector3 targetPosition;
      public float moveSpeed = 10f;
      public float waitTime = 0f;

      private bool isMoving = false;

      void Start()
      {
          Debug.Log("SpitoutRingPull");
          transform.position = startPosition;
          StartCoroutine(MoveToTargetPosition());
      }

      IEnumerator MoveToTargetPosition()
      {
          yield return new WaitForSeconds(waitTime);
          isMoving = true;

          while (transform.position != targetPosition)
          {
              transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
              yield return null;
          }

          isMoving = false;
      }
}
