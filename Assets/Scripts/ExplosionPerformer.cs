using UnityEngine;

public class ExplosionPerformer : MonoBehaviour
{
    [SerializeField] private LayerMask _cubesLayer;
    [SerializeField, Min(0.1f)] private float _maxExplosionRadius;
    [SerializeField] private float _maxExplosionForce;

    private float _minScale = 0.001f;

    public void Explode(Vector3 scale, Vector3 parentPosition)
    {
        float scaleMultiplier = Mathf.Max(scale.x, _minScale);
        float explosionRadius = _maxExplosionRadius / scaleMultiplier;
        float explosionForce = _maxExplosionForce / scaleMultiplier;

        Collider[] colliders = Physics.OverlapSphere(parentPosition, explosionRadius, _cubesLayer);

        foreach (Collider collider in colliders)
        {
            Rigidbody rigidbody;

            if (collider.TryGetComponent<Rigidbody>(out rigidbody))
            {
                Vector3 direction = collider.transform.position - parentPosition;
                float distance = direction.magnitude;

                if (distance > 0)
                {
                    Vector3 forceDirection = direction.normalized;
                    float forceMagnitude = explosionForce * (1 - distance / explosionRadius);

                    rigidbody.AddForce(forceDirection *  forceMagnitude, ForceMode.Impulse);
                }
            }
        }
    }
}
