using UnityEngine;
using System.Collections.Generic;

public class Spreader
{
    private Vector3 _direction;
    private float _forceMagnitude = 25f;

    public void Expload(List<Rigidbody> rigidbodies)
    {
        foreach (var rigidbody in rigidbodies)
        {
            _direction = Random.onUnitSphere;

            rigidbody.AddForce(_direction * _forceMagnitude, ForceMode.Impulse);
        }
    }
}