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
        // ѕолучаем ввод от игрока
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        // —оздаем вектор направлени€ движени€ на основе ввода игрока
        _movementDirection = new Vector2(horizontalInput, verticalInput).normalized;

        RotateTank();
    }

    void FixedUpdate()
    {
        MoveTank();
    }

    void MoveTank()
    {
        Vector2 movement = _movementDirection * _moveSpeed * Time.fixedDeltaTime;

        _rigidbody2D.MovePosition(_rigidbody2D.position + movement);
    }

    void RotateTank()
    {
        if (_movementDirection != Vector2.zero)
        {
            // ¬ычисл€ем угол между текущим направлением танка и желаемым направлением
            float targetAngle = Mathf.Atan2(_movementDirection.y, _movementDirection.x) * Mathf.Rad2Deg;

            // ѕолучаем направление танка
            Vector2 tankForward = transform.right;

            // ¬ычисл€ем угол между направлением танка и желаемым направлением
            float angleDiff = Vector2.SignedAngle(tankForward, _movementDirection);

            // ќпредел€ем, кака€ часть танка ближе к целевому направлению
            if (Mathf.Abs(angleDiff) > 90f)
            {
                // ≈сли задн€€ часть танка ближе к целевому направлению, разворачиваемс€ задним ходом
                targetAngle += 180f;
            }

            // ѕлавно поворачиваем танк в желаемое направление
            float angle = Mathf.MoveTowardsAngle(_rigidbody2D.rotation, targetAngle, _rotationSpeed * Time.deltaTime);

            // ѕримен€ем поворот к танку
            _rigidbody2D.MoveRotation(angle);
        }
    }
}
