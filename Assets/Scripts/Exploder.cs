using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;

    public void Explode(List<Rigidbody> rigidbodies)
    {
        foreach (var rigidbody in rigidbodies)
            rigidbody.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
    }
}