using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class RobotMover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _rotationSpeed = 180f;

    private Rigidbody2D _rigidbody2D;
    private Vector2 _movementDirection;

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Получаем ввод от игрока
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        // Создаем вектор направления движения на основе ввода игрока
        _movementDirection = new Vector2(horizontalInput, verticalInput).normalized;

        RotateRobot();
    }

    void FixedUpdate()
    {
        MoveRobot();
    }

    void MoveRobot()
    {
        Vector2 movement = _movementDirection * _moveSpeed * Time.fixedDeltaTime;

        _rigidbody2D.MovePosition(_rigidbody2D.position + movement);
    }

    void RotateRobot()
    {
        if (_movementDirection != Vector2.zero)
        {
            float targetAngle = Mathf.Atan2(_movementDirection.y, _movementDirection.x) * Mathf.Rad2Deg;

            Vector2 tankForward = transform.right;

            float angleDiff = Vector2.SignedAngle(tankForward, _movementDirection);

            if (Mathf.Abs(angleDiff) > 90f)
            {
                targetAngle += 180f;
            }

            float angle = Mathf.MoveTowardsAngle(_rigidbody2D.rotation, targetAngle, _rotationSpeed * Time.deltaTime);

            _rigidbody2D.MoveRotation(angle);
        }
    }
}
