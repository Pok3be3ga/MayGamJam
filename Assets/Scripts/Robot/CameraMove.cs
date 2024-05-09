using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private Transform _target;

    private void LateUpdate()
    {
        transform.position = new Vector3(_target.position.x, _target.position.y, transform.position.z);

    }
}
