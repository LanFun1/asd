using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesSpawner : MonoBehaviour
{
    [SerializeField] public SpriteRenderer _enemyPrefab;
    [SerializeField] private Transform[] _points;
    private Vector2 _enemyPos;
    private int _ch;
    private float _timer = 2f;

    private void Update()
    {
        _timer -= Time.deltaTime;
        if(_timer <= 0 )
        {
            _timer = 2f;
            StartCoroutine(SpawnIn());
        }
    }

    private IEnumerator SpawnIn()
    {       
        RandomPos();
        Instantiate(_enemyPrefab, _enemyPos, Quaternion.identity);
        yield return null;
    }
    private void RandomPos()
    {
        _ch = Random.Range(0, _points.Length);
        _enemyPos = _points[_ch].transform.position;
    }
}
