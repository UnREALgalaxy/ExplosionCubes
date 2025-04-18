using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _cubePrefab;
    [SerializeField] private Raycaster _raycaster;
    [SerializeField, Range(6, 30)] private int _maxNewCubes = 6;
    [SerializeField, Range(2, 26)] private int _minNewCubes = 2;

    private const int MaxSpreadChance = 100;
    private const int ChanceDecreaseRatio = 2;
    private const int ScaleDecreaseRatio = 2;
    private Exploader _exploader = new Exploader();

    private void OnValidate()
    {
        if (_minNewCubes >= _maxNewCubes)
            _minNewCubes = _maxNewCubes - 1;
    }

    private void OnEnable() => _raycaster.OnRaycast += PerformExplosion;

    private void OnDisable() => _raycaster.OnRaycast -= PerformExplosion;

    private void PerformExplosion(GameObject parentCube)
    {
        Cube parentCubeHandler = parentCube.GetComponent<Cube>();
        int spreadChance = parentCubeHandler.SpreadChance;

        if (Random.Range(0, MaxSpreadChance) <= spreadChance)
        {
            CreateCubes(parentCube, spreadChance);
        }

        Destroy(parentCube);
    }

    private void CreateCubes(GameObject parentCube, int spreadChance)
    {
        List<Rigidbody> rigidbodies = new List<Rigidbody>();

        for (int i = 0; i < Random.Range(_minNewCubes, _maxNewCubes); i++)
        {
            Vector3 parentPosition = parentCube.transform.position;
            Vector3 parentScale = parentCube.transform.localScale;

            GameObject childCube = Instantiate(_cubePrefab, parentPosition, Quaternion.identity);

            rigidbodies.Add(childCube.GetComponent<Rigidbody>());

            Cube childCubeHandler = childCube.GetComponent<Cube>();

            childCubeHandler.SetChance(spreadChance / ChanceDecreaseRatio);
            childCubeHandler.SetScale(parentScale / ScaleDecreaseRatio);
        }

        _exploader.Expload(rigidbodies);
    }
}

