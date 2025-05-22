using System;
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

[Serializable] public class ItemConsumbale
{
    public ConsumableType consumableType;
    public float value;
}

[CreateAssetMenu(fileName = "Item", menuName = "New Item")]
public class ItemData : ScriptableObject
{
    [Header("Info")]
    public string itemName; // 아이템 이름
    public string itemDescription; // 아이템 설명
    public string itemInteractKey; // 상호작용할 입력 키, 설명
    public ItemType type; // 아이템 타입(장비, 소비, 기타)
    public Sprite icon; // 아이템 이미지
    public GameObject dropPrefeb; // 아이템의 프리펩과 연결

    [Header("Stacking")]
    public bool isStack; // 인벤토리에 하나의 아이템이 여러 개를 가질 수 있는지 확인
    public int maxStack; // 인벤토리에 몇 개까지 가질 수 있는지

    [Header("Consumable")]
    public ItemConsumbale[] consumbales;
}
