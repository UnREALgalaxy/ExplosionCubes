using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;
    [SerializeField, Range(6, 30)] private int _maxNewCubes = 6;
    [SerializeField, Range(2, 26)] private int _minNewCubes = 2;

    private const int ChanceDecreaseRatio = 2;
    private const int ScaleDecreaseRatio = 2;

    private Spreader _spreader;

    private void OnValidate()
    {
        if (_minNewCubes >= _maxNewCubes)
            _minNewCubes = _maxNewCubes - 1;
    }

    private void Awake()
    {
        _spreader = new Spreader();
    }

    public void CreateCubes(Cube parentCube, int spreadChance)
    {
        List<Rigidbody> rigidbodies = new List<Rigidbody>();

        for (int i = 0; i < Random.Range(_minNewCubes, _maxNewCubes); i++)
        {
            Cube childCube = Instantiate(_cubePrefab, parentCube.transform.position, Random.rotationUniform);

            if (childCube.TryGetComponent<Rigidbody>(out Rigidbody rigidbody))
            {
                rigidbodies.Add(rigidbody);
            }

            Vector3 parentScale = parentCube.transform.localScale;
            childCube.Initialize(spreadChance / ChanceDecreaseRatio, parentScale / ScaleDecreaseRatio);
        }

        _spreader.Expload(rigidbodies);
    }
}