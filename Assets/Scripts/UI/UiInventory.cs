using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiInventory : MonoBehaviour
{
    public ItemSlot[] slots;

    public GameObject inventoryWindow;
    public Transform slotPanel;
    public Transform dropPosition;

    [Header("Select Item")]
    public TextMeshProUGUI selectedItemName;
    public TextMeshProUGUI selectedItemDescripton;
    public TextMeshProUGUI selectedItemStat;
    public TextMeshProUGUI selectedItemStatValue;
    
    public GameObject useButton;
    public GameObject equipButton;
    public GameObject unEquipButton;
    public GameObject dropButton;

    private PlayerController playerController;
    private PlayerCondition PlayerCondition;

    private ItemData selectdeItem;
    int selectdeItemIndex;

    // Start is called before the first frame update
    void Start()
    {
        playerController = CharacterManager.Instance.Player._controller;
        PlayerCondition = CharacterManager.Instance.Player._condition;
        dropPosition = CharacterManager.Instance.Player.dropItemPos;

        playerController.inventory += Toggle;
        CharacterManager.Instance.Player.addItem += AddItem;

        inventoryWindow.SetActive(false);

        slots = new ItemSlot[slotPanel.childCount];

        for (int i = 0; i < slots.Length; i++)
        {
            slots[i] = slotPanel.GetChild(i).GetComponent<ItemSlot>();
            slots[i].index = i;
            slots[i]._inventory = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ClearInfo()
    {
        selectedItemName.text = string.Empty;
        selectedItemDescripton.text = string.Empty;
        selectedItemStat.text = string.Empty;
        selectedItemStatValue.text = string.Empty;

        useButton.SetActive(false);
        equipButton.SetActive(false);
        unEquipButton.SetActive(false);
        dropButton.SetActive(false);
    }

    public void Toggle()
    {
        if (isOpen() == true)
        {
            inventoryWindow.SetActive(false);
        }
        else
        {
            inventoryWindow.SetActive(true);
        }
    }

    public bool isOpen()
    {
        return inventoryWindow.activeInHierarchy;
    }
    private void AddItem()
    {
        ItemData data = CharacterManager.Instance.Player._itemData;

        if (data.isStack == true)
        {
            ItemSlot slot = GetitemStack(data);
            if (slot != null)
            {
                slot.quantity++;
                UpdateUi();
                CharacterManager.Instance.Player._itemData = null;
                return;
            }
        }
        ItemSlot emptySlot = GetEmptySlot();

        if (emptySlot != null)
        {
            emptySlot._item = data;
            emptySlot.quantity = 1;
            UpdateUi();
            CharacterManager.Instance.Player._itemData = null;
        }

        ThrowItem(data);
        CharacterManager.Instance.Player._itemData = null;

    }
    private void UpdateUi()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i]._item != null)
            {
                slots[i].Set();
            }
            else
            {
                slots[i].Clear();
            }    
        }
    }
    private void ThrowItem(ItemData data)
    {
        //Instantiate(data.dropPrefeb, dropPosition.position, Quaternion.Euler(Vector3.one * Random.value * 180));
    }
    ItemSlot GetitemStack(ItemData data)
    {
        for (int i =0; i < slots.Length; i++)
        {
            if (slots[i]._item == data && slots[i].quantity < data.maxStack)
            {
                return slots[i];
            }
        }
        return null;
    }
    ItemSlot GetEmptySlot()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i]._item == null)
            {
                return slots[i];
            }
        }
        return null;
    }

    public void Selectitem(int index)
    {
        if (slots[index]._item == null)
        {
            selectdeItem = slots[index]._item;
            selectdeItemIndex = index;

            selectedItemName.text = selectdeItem.itemName;
            selectedItemDescripton.text = selectdeItem.itemDescription;

            selectedItemStat.text = string.Empty;
            selectedItemStatValue.text = string.Empty;

            for (int i = 0; i < selectdeItem.consumbales.Length; i++)
            {
                selectedItemStat.text += selectdeItem.consumbales[i].consumableType.ToString() + "\n";
                selectedItemStatValue.text = selectdeItem.consumbales[i].value.ToString() + "\n"; ;
            }

            useButton.SetActive(selectdeItem.type == ItemType.Consumable);
            equipButton.SetActive(selectdeItem.type == ItemType.Equipable && slots[index].equip);
            unEquipButton.SetActive(selectdeItem.type == ItemType.Equipable && slots[index].equip);
            dropButton.SetActive(true);
        }
    }

    public void OnUseButton()
    {
        if(selectdeItem.type == ItemType.Consumable)
        {
            for (int i = 0; i <selectdeItem.consumbales.Length; i++)
            {
                switch(selectdeItem.consumbales[i].consumableType)
                {
                    case ConsumableType.Health:
                        PlayerCondition.Heal();
                        break;
                    case ConsumableType.Hunger:
                       // PlayerCondition.Eat();
                        break;
                }
            }
        }
        RemoveSelectedItem();
    }
    public void DropButton()
    {
        ThrowItem(selectdeItem);
        RemoveSelectedItem();
    }
    private void RemoveSelectedItem()
    {
        slots[selectdeItemIndex].quantity--;
        if (slots[selectdeItemIndex].quantity <= 0)
        {
            selectdeItem = null;
            slots[selectdeItemIndex]._item = null;
            selectdeItemIndex = -1;
            ClearInfo();
        }
        UpdateUi();
    }
}
