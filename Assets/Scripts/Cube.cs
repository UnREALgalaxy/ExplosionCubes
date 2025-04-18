using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Cube : MonoBehaviour
{
    private const int MaxSpreadChance = 100;

    private ColorChanger _colorChanger;
    public int CurrentSpreadChance { get; private set; } = 100;
    
    public bool CanCreate => Random.Range(0, MaxSpreadChance) <= CurrentSpreadChance;

    private void Awake()
    {
        _colorChanger = new ColorChanger();

        Renderer renderer = GetComponent<Renderer>();
        _colorChanger.Set(renderer);
    }

    public void Initialize(int newChance, Vector3 scale)
    {
        CurrentSpreadChance = newChance;
        transform.localScale = scale;
    }
}
