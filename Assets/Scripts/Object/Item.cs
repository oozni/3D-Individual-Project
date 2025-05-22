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

    public string GetInteractPrompt() // 상호작용 가능한 오브젝트에서 플레이어에게 보여줄 안내 문구
    {
        string str = $"{data.itemName}\n{data.itemDescription}\n{data.itemInteractKey}";
        return str;
    }

    public void OnInteract() // 상호작용 동작
    {
        CharacterManager.Instance.Player._itemData = data;
        CharacterManager.Instance.Player.addItem?.Invoke();

        Destroy(gameObject);
    }
}
