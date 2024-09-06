using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Separator : MonoBehaviour
{
    [SerializeField] private ClickHandler _clickHandler;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Exploder _exploder;
    [SerializeField] private int _defaultChanceToSeparate = 100;
    [SerializeField] private int _chanceToSeparate;

    private void Awake()
    {
        _chanceToSeparate = _defaultChanceToSeparate;
    }

    private void OnEnable()
    {
        _clickHandler.OnClicked += OnClickHandled;
    }

    private void OnDisable()
    {
        _clickHandler.OnClicked -= OnClickHandled;
    }
    
    public void SetSpawnChance(int chance)
    {
        _chanceToSeparate = chance;
        if (_chanceToSeparate == 0)
            _chanceToSeparate = 1;
    }

    private void OnClickHandled()
    {
        var needSpawn = Random.Range(1, _defaultChanceToSeparate + 1) <= _chanceToSeparate;
        
        if (needSpawn == false)
        {
            _exploder.ExplodeNearbyObjects();
            Destroy(gameObject);
            return;
        }

        var nextSpawnChance = _chanceToSeparate / 2;
        var spawnedObjects = _spawner.Spawn(nextSpawnChance);
        _exploder.Explode(spawnedObjects);
        Destroy(gameObject);
    }
}