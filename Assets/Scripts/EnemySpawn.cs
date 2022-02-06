using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private GameObject _prefabEnemy;
    [SerializeField] private List<GameObject> _enemies;

    private Point[] _points;
    private WaitForSeconds _pauseSpawn = new WaitForSeconds(2);

    private void Awake()
    {
        _points = GetComponentsInChildren<Point>();
    }

    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        while (_enemies.Count < 10)
        {
            int minValue = 0;
            int maxValue = _points.Length;

            int index = Random.Range(minValue, maxValue);
            _enemies.Add(Instantiate(_prefabEnemy, _points[index].transform));

            yield return _pauseSpawn;
        }
    }
}
