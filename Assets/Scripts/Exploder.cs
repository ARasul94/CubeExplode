using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;

    public void Explode(List<Rigidbody> rigidbodies)
    {
        foreach (Rigidbody rigidbody in rigidbodies)
            rigidbody.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
    }

    public void ExplodeNearbyObjects()
    {
        float adjustedToScaleRadius = _explosionRadius / transform.localScale.x;
        float adjustedToScaleForce = _explosionForce / transform.localScale.x;

        foreach (Rigidbody explodableObject in GetExplodableObjects(adjustedToScaleRadius))
            explodableObject.AddExplosionForce(adjustedToScaleForce, transform.position, adjustedToScaleRadius);
    }

    private List<Rigidbody> GetExplodableObjects(float radius)
    {
        IEnumerable<Collider> hits = Physics.OverlapSphere(transform.position, radius).Where(x => x.attachedRigidbody != null);

        List<Rigidbody> explodableObjects = new();

        foreach (Collider hit in hits)
            explodableObjects.Add(hit.attachedRigidbody);

        return explodableObjects;
    }
}