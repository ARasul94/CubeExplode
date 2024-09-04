using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Separator _prefab;
    [SerializeField][Range(2,5)] private int _minSpawnCount;
    [SerializeField][Range(3,6)] private int _maxSpawnCount;

    public List<Rigidbody> Spawn(int nextSpawnChance)
    {
        var spawnedObjectsRigidbodyList = new List<Rigidbody>();
        var spawnCount = Random.Range(_minSpawnCount, _maxSpawnCount + 1);
        var spawnScale = transform.localScale / 2;

        for (int i = 0; i < spawnCount; i++)
        {
            var cube = Instantiate(_prefab, transform.position, Quaternion.identity);
            cube.transform.localScale = spawnScale;
            cube.SetSpawnChance(nextSpawnChance);
            spawnedObjectsRigidbodyList.Add(cube.GetComponent<Rigidbody>());
        }

        return spawnedObjectsRigidbodyList;
    }

    private void OnValidate()
    {
        if (_minSpawnCount >= _maxSpawnCount)
            _minSpawnCount = _maxSpawnCount - 1;

        if (_maxSpawnCount <= _minSpawnCount)
            _maxSpawnCount = _minSpawnCount + 1;
    }
}