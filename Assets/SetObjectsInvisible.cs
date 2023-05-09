using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetObjectsInvisible : MonoBehaviour
{
  public GameObject[] objectsToHide;

  void Start()
  {
      foreach (GameObject obj in objectsToHide)
      {
          obj.SetActive(false);
      }
  }
    void Update()
    {

    }
}
