using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeInvisibleOnCollision : MonoBehaviour
{
    public float moveDistance = 0.1f; // The distance to move the object
    public LayerMask layerMask; // The layers to check for collisions

    private void Update()
    {
        Vector3 startPosition = transform.position; // Store the current position
        Vector3 endPosition = transform.position + (transform.forward * moveDistance); // Calculate the new position

        // Check for collisions between the current and new position
        RaycastHit[] hits = Physics.RaycastAll(startPosition, transform.forward, moveDistance, layerMask);

        foreach (RaycastHit hit in hits)
        {
            Destroy(hit.collider.gameObject); // Destroy any objects that were hit
        }

        // Move the object to the new position
        transform.position = endPosition;
    }
  }
