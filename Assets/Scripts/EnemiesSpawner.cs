using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesSpawner : MonoBehaviour
{
    [SerializeField] public SpriteRenderer _enemyPrefab;
    [SerializeField] private Transform[] _points;
    private Vector2 _enemyPos;
    private int _number;
    private bool _courChecker = true;

    private void Update()
    {
        if(_courChecker == true)
            StartCoroutine(SpawnIn());
        _courChecker = false;
    }

    private IEnumerator SpawnIn()
    {
        var waitforsec = new WaitForSeconds(2f);
        RandomPos();
        Instantiate(_enemyPrefab, _enemyPos, Quaternion.identity);
        yield return waitforsec;
        _courChecker = true;
    }
    private void RandomPos()
    {
        _number = Random.Range(0, _points.Length);
        _enemyPos = _points[_number].transform.position;
    }
}
