using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoveTo : MonoBehaviour
{
    [SerializeField] private Transform _moveToPosition; // Целевая позиция
    [SerializeField] private Transform _moveToRotation;  // Целевой поворот
    [SerializeField] private float movementSpeed = 2f;  // Скорость изменения позиции
    [SerializeField] private float rotationSpeed = 2f;  // Скорость изменения поворота

    public void MoveCameraTo()
    {
        StartCoroutine(MoveAndRotateCamera());
    }

    private IEnumerator MoveAndRotateCamera()
    {
        while (Vector3.Distance(transform.position, _moveToPosition.position) > 0.1f ||
               Quaternion.Angle(transform.rotation, _moveToRotation.rotation) > 0.1f)
        {
            // Постепенное изменение позиции
            transform.position = Vector3.Lerp(transform.position, _moveToPosition.position, Time.deltaTime * movementSpeed);

            // Постепенное изменение поворота
            transform.rotation = Quaternion.Lerp(transform.rotation, _moveToRotation.rotation, Time.deltaTime * rotationSpeed);

            yield return null;
        }

        // Завершение корутины
        yield break;
    }
}
