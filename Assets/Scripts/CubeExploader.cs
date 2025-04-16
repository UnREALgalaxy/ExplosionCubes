using System;
using UnityEngine;

public class CubeExploader : MonoBehaviour
{
    [SerializeField] private ChanceManager _chanceManager;

    public event Action Exploaded;

    private void OnMouseDown()
    {
        
    }
}
