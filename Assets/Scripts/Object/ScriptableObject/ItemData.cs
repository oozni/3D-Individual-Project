using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Equipable,  // ���
    Consumable, // �Һ�
    Resource    // ��Ÿ
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
    public string itemName; // ������ �̸�
    public string itemDescription; // ������ ����
    public string itemInteractKey; // ��ȣ�ۿ��� �Է� Ű, ����
    public ItemType type; // ������ Ÿ��(���, �Һ�, ��Ÿ)
    public Sprite icon; // ������ �̹���
    public GameObject dropPrefeb; // �������� ������� ����

    [Header("Stacking")]
    public bool isStack; // �κ��丮�� �ϳ��� �������� ���� ���� ���� �� �ִ��� Ȯ��
    public int maxStack; // �κ��丮�� �� ������ ���� �� �ִ���

    [Header("Consumable")]
    public ItemConsumbale[] consumbales;
}
