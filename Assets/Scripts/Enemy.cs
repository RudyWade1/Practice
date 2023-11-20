using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Transform _target;

    public void Init(Transform target)
    {
        _target = target;
    }

    private void Update()
    {
        Move();
    }

    public void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position , _target.position, _speed * Time.deltaTime);
    }
}
