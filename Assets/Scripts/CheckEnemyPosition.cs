using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckEnemyPosition : MonoBehaviour
{
    private GameObject _enemy;
    private float _xRange;
    private float _yRange;

    private void Update()
    {
        EnemyPositionChecker();
    }

    public void GetEnemy(GameObject enemy)
    {
        _enemy = enemy;
    }

    public void GetRanges(float xRange, float yRange)
    {
        _xRange = xRange;
        _yRange = yRange;
    }

    public void EnemyPositionChecker()
    {
        if (_enemy.transform.position.x > _xRange || _enemy.transform.position.y > _yRange || _enemy.transform.position.x < -_xRange || _enemy.transform.position.y < -_yRange)
            Destroy(_enemy);
    }
}
