using UnityEngine;


public class Item : ScriptableObject
{
    public string itemName;
    public Sprite icon;

    public Type itemType;
    public Rarity rarity;

}

[System.Serializable]
public enum Rarity
{
    Commun = 0,
    Rare = 1,
    Epique = 2,
    Legendary = 3,
    Unique = 4
}
[System.Serializable]
public enum Type
{
    Weapon = 0,
    Helmet = 1,
    Chestplate = 2,
    Leging = 3
}
