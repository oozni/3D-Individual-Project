using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Equipable,  // 장비
    Consumable, // 소비
    Resource    // 기타
}

public enum ConsumableType
{
    Health,
    Hunger,
    Stamina
}

[CreateAssetMenu(fileName = "Item", menuName = "New Item")]
public class ItemData : ScriptableObject
{
    [Header("Info")]
    public string itemName;
    public string itemDescription;
    public ItemType type;
    public Sprite icon;
    public GameObject dropPrefeb;

    [Header("Stacking")]
    public bool isStack;
    public int maxStack;
}
