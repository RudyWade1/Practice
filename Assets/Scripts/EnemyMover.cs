using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Transform[] _targetPoints;
    private int _currentPoint;

    private void Update()
    {
        Transform target = _targetPoints[_currentPoint];
        transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);

        if (transform.position == target.position)
        {
            _currentPoint++;

            if (_currentPoint == _targetPoints.Length)
                _currentPoint = 0;
        }
    }

    public void GetTargetPoints(Transform[] newTargetPoints)
    {
        _targetPoints = newTargetPoints;
    }
}