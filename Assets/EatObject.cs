using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatObject : MonoBehaviour
{
public Vector3 targetPosition;
public GameObject objectToDisappear;
public Vector3 disappearPosition;
public float moveSpeed;
public float rotationSpeed = 1f;
public float rotationSpeed2 = 15f;
private bool rotating = true;
private bool rotating2 = true;
private float currentRotation = 0f;
private float currentRotation2 = 0f;
private bool visible = false;
private bool endszene = false;
public Transform target;
public float speed = 5f;
void Update(){
    Vector3 directionToMove = targetPosition - transform.position;
    directionToMove = directionToMove.normalized * Time.deltaTime * moveSpeed;
    float maxDistance = Vector3.Distance(transform.position, targetPosition);
    transform.position = transform.position + Vector3.ClampMagnitude(directionToMove, maxDistance);

    if (targetPosition == transform.position)
            {
                objectToDisappear.SetActive(visible);
                StartCoroutine(WaitAndContinue());
            }
    if (endszene == true)
    {
      if (rotating2){

        transform.Rotate(Vector3.right, rotationSpeed2 * Time.deltaTime);
        currentRotation2 += rotationSpeed2 * Time.deltaTime;
        if (currentRotation2 >= 90f)
          {
            rotating2 = false;
          }
      }
      Vector3 direction = (target.position - transform.position).normalized;
      float distance = Vector3.Distance(transform.position, target.position);

      if (target == null) return;




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

    IEnumerator WaitAndContinue()
            {
              yield return new WaitForSeconds(2f);
              if (rotating)
              {
                transform.Rotate(Vector3.left, rotationSpeed * Time.deltaTime);
                currentRotation += rotationSpeed * Time.deltaTime;
                Debug.Log(currentRotation);
                if (currentRotation >= 90f)
                  {
                    Debug.Log("stop rotation");
                    StartCoroutine(WaitAndContinue2());
                    rotating = false;
                  }
              }
          }
    IEnumerator WaitAndContinue2()
          {
            yield return new WaitForSeconds(16.9f);
            visible = true;
            StartCoroutine(WaitAndContinue3());
          }

    IEnumerator WaitAndContinue3(){
      yield return new WaitForSeconds(10f);
      Debug.Log("now start Rotation again");
      endszene = true;
    }
        }
