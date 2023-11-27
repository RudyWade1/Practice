using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Transform _path;
    [SerializeField] private float _spawnInterval;

    private Transform[] _targetPoints;

    private void Start()
    {
        _targetPoints = new Transform[_path.childCount];

        for (int i = 0; i < _path.childCount; i++)
            _targetPoints[i] = _path.GetChild(i);

        StartCoroutine(Spawner());
    }

    private IEnumerator Spawner()
    {
        Enemy newEnemy = Instantiate(_enemy, transform.position, Quaternion.identity);

        newEnemy.GetComponent<EnemyMover>().GetTargetPoints(_targetPoints);

        yield return new WaitForSeconds(_spawnInterval);
        StartCoroutine(Spawner());
    }
}

