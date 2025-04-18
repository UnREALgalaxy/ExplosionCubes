using UnityEngine;

public class CubeClickerHandler : MonoBehaviour
{
    [SerializeField] private Raycaster _raycaster;
    [SerializeField] private Spawner _spawner;

    private void OnEnable() => _raycaster.CubeClicked += PerformCubeLogic;

    private void OnDisable() => _raycaster.CubeClicked -= PerformCubeLogic;

    private void PerformCubeLogic(Cube parentCube)
    {
        if (parentCube.CanCreate)
            _spawner.CreateCubes(parentCube, parentCube.CurrentSpreadChance);

        Destroy(parentCube.gameObject);
    }
}
