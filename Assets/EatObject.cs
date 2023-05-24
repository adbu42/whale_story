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
public Renderer objectRenderer;
public float blinkInterval = 100f;
private bool isBlinking = false;

void Update(){

    Vector3 directionToMove = targetPosition - transform.position;
    directionToMove = directionToMove.normalized * Time.deltaTime * moveSpeed;
    float maxDistance = Vector3.Distance(transform.position, targetPosition);
    transform.position = transform.position + Vector3.ClampMagnitude(directionToMove, maxDistance);

    if (targetPosition == transform.position)
            {
                objectToDisappear.SetActive(visible);
                objectRenderer.material.color = Color.white;
                Debug.Log("StartBlinking");
                StartBlinking();
                StartCoroutine(WaitAndContinue());
            }
    if (endszene == true)
    {
      if (rotating2){
        OnDestroy();
        OnDestroy();
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
            yield return new WaitForSeconds(16.8f);
            visible = true;
            StartCoroutine(WaitAndContinue3());
          }

    IEnumerator WaitAndContinue3(){
      OnDestroy();
      objectRenderer.material.color = Color.white;
      yield return new WaitForSeconds(10f);
      Debug.Log("now start Rotation again");
      endszene = true;
    }

    private void StartBlinking()
    {
        if (objectRenderer == null)
        {
            objectRenderer = GetComponent<Renderer>();
        }

        if (objectRenderer != null)
        {
            isBlinking = true;
            if (isBlinking){
              InvokeRepeating("ToggleObjectColor", 0f, blinkInterval);
            }
        }
        else
        {
            Debug.LogWarning("Object Renderer not found!");
        }
    }

    private void ToggleObjectColor()
    {
      Color c = new Color(1.6f,0.4f,0f, 2f);
      if (isBlinking) {
        objectRenderer.material.color = Color.Lerp(Color.white, c, Mathf.PingPong(Time.time, 1));
      }
    }

    private void OnDestroy()
    {
        if (isBlinking)
        {
            objectRenderer.material.color = Color.white;
            CancelInvoke("ToggleObjectColor");
        }
    }
}
