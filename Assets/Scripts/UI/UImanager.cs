using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UImanager : MonoBehaviour
{
    public Conditions health;
    public Conditions hunger;
    public Conditions stamina;

    // Start is called before the first frame update
    void Start()
    {
        CharacterManager.Instance.Player._condition.uiManager = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
