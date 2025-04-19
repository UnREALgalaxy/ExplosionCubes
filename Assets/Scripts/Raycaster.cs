using System;
using UnityEngine;

public class Raycaster : MonoBehaviour
{
    [SerializeField] private LayerMask _cubeLayerMask;

    private float _rayDistance = 50f;

    public event Action<Cube> CubeClicked;

    private void Update()
    {
        PerformClick();
    }

    private void PerformClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, _rayDistance, _cubeLayerMask))
            {
                if (hit.collider.TryGetComponent<Cube>(out Cube cube))
                {
                    CubeClicked.Invoke(cube);
                }
            }
        }
    }
}
