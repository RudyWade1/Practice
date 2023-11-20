using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Code : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _path;
    [SerializeField] private Transform[] _points;

    private int _currentPoint;

    void Start()
    {
        _points = new Transform[_path.childCount];

        for (int i = 0; i < _path.childCount; i++)
            _points[i] = _path.GetChild(i);
    }

    public void Update()
    {
        Transform target = _points[_currentPoint];
        transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);

        if (transform.position == target.position)
        {
            _currentPoint = 0;

            if (_currentPoint == _points.Length)
                _currentPoint++;
        }
    }
}
