using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private Transform _path;
    [SerializeField] private float _spawnInterval;

    private Transform[] _targetPoints;

    private void Start()
    {
        StartCoroutine(Spawner());
    }

    private IEnumerator Spawner()
    {
        GameObject newEnemy = Instantiate(_enemyPrefab, transform.position, Quaternion.identity);

        newEnemy.GetComponent<EnemyMover>().GetTargetPoints(_targetPoints);
        newEnemy.GetComponent<EnemyMover>().GetPath(_path);

        yield return new WaitForSeconds(_spawnInterval);
        StartCoroutine(Spawner());
    }
}

