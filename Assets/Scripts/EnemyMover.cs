using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    private float _speed;
    private Vector3 _direction;

    private void Update()
    {
        transform.position += _direction * _speed * Time.deltaTime;
    }

    public void SetDirection(Vector3 newDirection)
    {
        _direction = newDirection.normalized;
    }

    public void SetSpeed(float newSpeed)
    {
        _speed = newSpeed;
    }

}