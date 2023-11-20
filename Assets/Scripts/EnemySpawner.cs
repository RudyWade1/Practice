using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Transform _target;
    [SerializeField] private float _spawnTime;

    private int _enemyCount;

    private void Start()
    {
        StartCoroutine(Spawner());
    }

    private IEnumerator Spawner()
    {
        while (_enemyCount < 5)
        {
            Vector3 direction = (_target.position - transform.position).normalized;
            var enemy = Instantiate(_enemy, transform.position + direction, Quaternion.identity);

            _enemy.Move();
            _enemyCount++;

            yield return new WaitForSeconds(_spawnTime);
        }
    }

}

