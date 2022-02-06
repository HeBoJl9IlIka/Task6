using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    [SerializeField] private List<GameObject> _enemies;

    private Point[] _points;
    private float _runningTime;
    private float _spawnTime = 2;

    private void Awake()
    {
        _points = GetComponentsInChildren<Point>();
    }

    void Update()
    {
        int minValue = 0;
        int maxValue = GetComponentsInChildren<Point>().Length;
        
        _runningTime += Time.deltaTime;
        if(_runningTime >= _spawnTime)
        {
            int index = Random.Range(minValue, maxValue);
            _enemies.Add(Instantiate(_enemy, _points[index].transform));
            _runningTime = 0;
        }
    }
}
