using UnityEngine;

public enum UpgradeType
{
    AtkUp,
    Pierce,
    Split
}

[CreateAssetMenu(fileName = "UpgradeData", menuName = "Scriptable Objects/UpgradeData")]
public class UpgradeData : ScriptableObject
{
    public UpgradeType upgradeType;

    public string upgradeName;
    public Sprite upgradeImage;
    [TextArea] public string upgradeEffect;
    public int value;

}
