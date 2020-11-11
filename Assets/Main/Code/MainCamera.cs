using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    private Transform myTransform;

    [SerializeField] private Transform target;
    [SerializeField] private float ZOffsetFromTarget;

    private void Awake()
    {
        myTransform = transform;
    }

    private void FixedUpdate()
    {
        Vector3 newPosition = myTransform.position ;
        newPosition.z = target.position.z + ZOffsetFromTarget;
        myTransform.position = newPosition;
    }
}
