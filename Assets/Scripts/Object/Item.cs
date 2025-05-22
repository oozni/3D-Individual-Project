using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    public string GetInteractPrompt();
    public void OnInteract();
}

public class Item : MonoBehaviour, IInteractable
{
    public ItemData data;

    public string GetInteractPrompt() // ��ȣ�ۿ� ������ ������Ʈ���� �÷��̾�� ������ �ȳ� ����
    {
        string str = $"{data.itemName}\n{data.itemDescription}\n{data.itemInteractKey}";
        return str;
    }

    public void OnInteract() // ��ȣ�ۿ� ����
    {
        CharacterManager.Instance.Player._itemData = data;
        CharacterManager.Instance.Player.addItem?.Invoke();

        Destroy(gameObject);
    }
}
