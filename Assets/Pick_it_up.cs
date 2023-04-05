using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pick_it_up : MonoBehaviour
{
    Animator anim;
    Rigidbody target_rigidbody;
    public GameObject target;
    public float IK_weight = 1.0f;
    public GameObject hand;
    public float let_it_go;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        target_rigidbody = target.GetComponent<Rigidbody>();
    }

    private void OnAnimatorIK(int layerIndex)
    {
        if(IK_weight>0.95)
        {
            target.transform.parent = hand.transform;
            target.transform.localPosition = new Vector3(0.3f, 1f, 0.4f);
            //target.transform.localPosition = new Vector3(0.2f, 1f, 0.2f);
            //target.transform.localRotation = Quaternion.Euler(20.469f, 70.204f, -180.401f);
        }
        if(let_it_go>0.95)
        {
            target.transform.parent = null;
            target_rigidbody.isKinematic = false;
            target_rigidbody.AddForce(transform.up * 500f + transform.forward * 800f);
            foreach(Transform child in target.transform)
            {
                Rigidbody child_rigidbody = child.gameObject.GetComponent<Rigidbody>();
                if(child_rigidbody != null){
                    child_rigidbody.isKinematic = false;
                    child_rigidbody.AddForce(transform.up * 4000f + transform.forward * 6400f);
                }
            }
        }
        anim.SetIKPosition(AvatarIKGoal.RightHand, target.transform.position);
        anim.SetIKPositionWeight(AvatarIKGoal.RightHand, IK_weight);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
