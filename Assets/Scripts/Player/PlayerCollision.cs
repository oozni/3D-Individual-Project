using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public ObjectManager _objectManager;
    Interactable interactable { get { return _objectManager._interactable; } }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            CharacterManager.Instance.Player._controller.isJump = true;
        }

        if (collision.gameObject.CompareTag("JumpPad"))
        {
            foreach (ContactPoint contact in collision.contacts)
            {
                if (Vector3.Dot(contact.normal, Vector3.up) > 0.9)
                {
                    interactable.ActivateJumpPad();
                }
            }
        }
    }
}