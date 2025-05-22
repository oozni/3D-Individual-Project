using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerController _controller;
    public PlayerCondition _condition;
    public PlayerCollision _collision;

    public ItemData _itemData;
    public Action addItem;

    private void Awake()
    {
        CharacterManager.Instance.Player = this;
        _controller = GetComponent<PlayerController>();
        _condition = GetComponent<PlayerCondition>();
        _collision = GetComponent<PlayerCollision>();
    }
}
