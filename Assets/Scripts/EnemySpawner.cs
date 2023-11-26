using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private float _spawnInterval;
    [SerializeField] private float _enemySpeed;

    private float _xRange = 9f;
    private float _yRange = 5f;

    private void Start()
    {
        StartCoroutine(Spawner());
    }

    IEnumerator Spawner()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-_xRange, _xRange), Random.Range(-_yRange, _yRange));
        GameObject newEnemy = Instantiate(_enemyPrefab, spawnPosition, Quaternion.identity);

        newEnemy.GetComponent<CheckEnemyPosition>().GetEnemy(newEnemy);
        newEnemy.GetComponent<CheckEnemyPosition>().GetRanges(_xRange, _yRange);

        newEnemy.GetComponent<EnemyMover>().SetDirection(transform.right * _enemySpeed);
        newEnemy.GetComponent<EnemyMover>().SetSpeed(_enemySpeed);

        yield return new WaitForSeconds(_spawnInterval);
        StartCoroutine(Spawner());
    }
}

