using System;
using UnityEngine;

[ExecuteInEditMode]
public class FollowObjectEditMode : MonoBehaviour
{
    [SerializeField] private Transform targetTransform;
    
    private void Update()
    {
        transform.LookAt(targetTransform);
    }
}
