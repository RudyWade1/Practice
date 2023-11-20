using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _prefab;
    [SerializeField] private float _spawnTime;

    private Transform _target;

    void Start()
    {
        StartCoroutine(ShootingWorker());
    }
    private IEnumerator ShootingWorker()
    {
        bool isWork = true;

        while (isWork)
        {
            var _vector3direction = (_target.position - transform.position).normalized;
            var NewBullet = Instantiate(_prefab, transform.position + _vector3direction, Quaternion.identity);

            NewBullet.GetComponent<Rigidbody>().transform.up = _vector3direction;
            NewBullet.GetComponent<Rigidbody>().velocity = _vector3direction * _speed;

            yield return new WaitForSeconds(_spawnTime);
        }
    }
}
