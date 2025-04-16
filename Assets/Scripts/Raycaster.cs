using UnityEngine;

public class Raycaster : MonoBehaviour
{
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

            if (Physics.Raycast(ray, out hit, 50f))
            {
                Debug.Log(hit.collider.name);
            }
        }
    }
}
