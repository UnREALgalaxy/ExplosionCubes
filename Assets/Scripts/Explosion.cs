using UnityEngine;

public class Explosion : MonoBehaviour
{
    private int maxNewCubes = 6;
    private int minNewCubes = 2;
    private int SpreadChance = 100;
    private int ChanceDecreaseRatio = 2;

    public void SetChance(int newChance)
    {
        SpreadChance = newChance;
    }


}
