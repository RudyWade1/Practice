using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private Transform _spawnPath;
    [SerializeField] private float _spawnTime;
    [SerializeField] private float _speed;

    private Transform[] _spawnPoints;


    private void Start()
    {
        _spawnPoints = new Transform[_spawnPath.childCount];

        for (int i = 0; i < _spawnPath.childCount; i++)
            _spawnPoints[i] = _spawnPath.GetChild(i);

        StartCoroutine(Spawner());
    }

    private IEnumerator Spawner()
    {
        var waitForSeconds = new WaitForSeconds(_spawnTime);

        for (int i = 0; i < _spawnPoints.Length; i++)
        {
            Instantiate(_enemyPrefab, _spawnPoints[i].position,Quaternion.identity);

            yield return waitForSeconds;
        }
    }
}
