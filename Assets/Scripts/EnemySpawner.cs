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
            Instantiate(_enemy, transform.position, Quaternion.identity);
            Vector2 direction = transform.position - _target.position;
            _enemy.Init(direction);
            _enemyCount++;

            yield return new WaitForSeconds(_spawnTime);
        }
    }

}

