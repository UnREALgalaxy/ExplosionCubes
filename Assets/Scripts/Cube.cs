using UnityEngine;

public class Cube : MonoBehaviour
{
    private ColorChanger _colorChanger = new ColorChanger();

    public int SpreadChance { get; private set; } = 100;

    private void Awake()
    {
        Renderer renderer = GetComponent<Renderer>();
        _colorChanger.Set(renderer);
    }

    public void SetChance(int newChance)
    {
        SpreadChance = newChance;
    }

    public void SetScale(Vector3 scale)
    {
        transform.localScale = scale;
    }
}
