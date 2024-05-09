using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMouse : MonoBehaviour
{
    [SerializeField] private float _rotationSmoothTime = 0.1f;

    private Transform _objectToRotate;
    private float _currentRotationVelocity;

    private void Start()
    {
        _objectToRotate = GetComponent<Transform>();
    }

    void Update()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 objectPosition = _objectToRotate.position;

        Vector2 direction = mousePosition - objectPosition;

        float targetAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        float smoothAngle = Mathf.SmoothDampAngle(_objectToRotate.rotation.eulerAngles.z, targetAngle, ref _currentRotationVelocity, _rotationSmoothTime);

        _objectToRotate.rotation = Quaternion.Euler(0f, 0f, smoothAngle);
    }
}
