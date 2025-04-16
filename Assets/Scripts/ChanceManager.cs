using UnityEngine;

public class ChanceManager : MonoBehaviour
{
    [SerializeField] private CubeExploader _cubeExploader;

    public int SpreadChance { get; private set; } = 100;

    private void OnEnable()
    {
        _cubeExploader.Exploaded += HalfChanceDecrease;
    }

    private void OnDisable()
    {
        _cubeExploader.Exploaded -= HalfChanceDecrease;
    }

    public void HalfChanceDecrease()
    {
        SpreadChance /= 2;
    }
}
