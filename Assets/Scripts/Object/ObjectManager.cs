using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public Interactable _interactable;
    
    // Start is called before the first frame update
    void Start()
    {
        CharacterManager.Instance.Player._collision._objectManager = this;
    }
}
