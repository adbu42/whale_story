using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatObject : MonoBehaviour
{
public Vector3 targetPosition;
public GameObject objectToDisappear;
public float moveSpeed;
public float rotationSpeed = 1f;
private bool rotating = true;
private float currentRotation = 0f;

void Update(){
  Debug.Log("move");
    Vector3 directionToMove = targetPosition - transform.position;
    directionToMove = directionToMove.normalized * Time.deltaTime * moveSpeed;
    float maxDistance = Vector3.Distance(transform.position, targetPosition);
    transform.position = transform.position + Vector3.ClampMagnitude(directionToMove, maxDistance);
/*
    if (targetPosition == transform.position)
            {
                Debug.Log("nowRotate");
                transform.Rotate(Vector3.left, rotationSpeed * Time.deltaTime);
                objectToDisappear.SetActive(false);

                if (rotating)
                {

                  currentRotation += rotationSpeed * Time.deltaTime;
                  if (currentRotation >= 180f)
                    {
                        rotating = false;
                    }
                }
            }*/
            }
          }
