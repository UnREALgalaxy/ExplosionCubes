using UnityEngine;

public class CubeClickerHandler : MonoBehaviour
{
    [SerializeField] private Raycaster _raycaster;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private ExplosionPerformer _explosionPerformer;

    private void OnEnable() => _raycaster.CubeClicked += PerformCubeLogic;

    private void OnDisable() => _raycaster.CubeClicked -= PerformCubeLogic;

    private void PerformCubeLogic(Cube parentCube)
    {
        if (parentCube.CanCreate)
            _spawner.CreateCubes(parentCube, parentCube.CurrentSpreadChance);
        else
            _explosionPerformer.Explode(parentCube.transform.localScale, parentCube.transform.position);

        Destroy(parentCube.gameObject);
    }
}
