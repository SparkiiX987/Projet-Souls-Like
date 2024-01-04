using UnityEngine;

[CreateAssetMenu]
public class Weapons : Item
{
    public float damages;
    public WeaponCategory category;
    public WeaponType weaponType;
}

[System.Serializable]
public enum WeaponCategory
{
    twoHanded = 0,
    oneHanded = 1,
    magic = 2,
    distance = 3
}

[System.Serializable]
public enum WeaponType
{
    longSword = 0,
    mace = 1,
    hallebard = 2,
    greatAxe = 3,
    scythe = 4,
    sword = 5,
    flail = 6,
    dagger = 7,
    shield = 8,
    axe = 9,
    stick = 10,
    scepter = 11,
    book = 12,
    arcaneSword = 13,
    gloves = 14,
    bow = 15,
    crossbow = 16,
    gun = 17,
    doubleGun = 18
}