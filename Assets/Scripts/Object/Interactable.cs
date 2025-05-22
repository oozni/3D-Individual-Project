using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float jumpPadSpeed;

    public void ActivateJumpPad()
    {
        CharacterManager.Instance.Player._controller.Jump(jumpPadSpeed);
    }
}
