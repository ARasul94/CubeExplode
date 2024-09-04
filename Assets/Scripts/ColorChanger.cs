using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ColorChanger : MonoBehaviour
{
    [SerializeField] private List<Material> _materials;

    private void Awake()
    {
        if (_materials.Count == 0)
            return;
        
        var meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material = _materials[Random.Range(0, _materials.Count)];
    }
}