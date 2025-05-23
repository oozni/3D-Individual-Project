using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    public ItemData _item;

    public Button _button;
    public Image _icon;
    public TextMeshProUGUI quantityText;
    private Outline _outline;

    public UiInventory _inventory;

    public int index; // ���° ������ ��������
    public int quantity; // ��� �������� ������ �ִ���
    public bool equip; // ������ ����������

    private void Awake()
    {
        _outline = GetComponent<Outline>();
    }
    private void OnRnable()
    {
        _outline.enabled = equip;
    }

    public void Set()
    {
        _icon.gameObject.SetActive(true);
        _icon.sprite = _item.icon;
        quantityText.text = quantity > 1 ? quantity.ToString() : string.Empty;

        if (_outline != null )
        {
            _outline.enabled = equip;
        }
    }

    public void Clear()
    {
        _item = null;
        _icon.gameObject.SetActive(false);
        quantityText.text = string.Empty;
    }

    public void OnClickButton()
    {

    }
}
