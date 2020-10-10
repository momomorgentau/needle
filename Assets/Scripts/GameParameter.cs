using UnityEngine;

[CreateAssetMenu(fileName = "GameParameter", menuName = "GameParameter")]
public class GameParameter : ScriptableObject
{
    public float xMax;
    public float xMin;
    public float zMax;
    public float zMin;
    public float needleLength;
    public int maxNeedleNum;
    public float delayTime;
    public int destroyTime;
}
