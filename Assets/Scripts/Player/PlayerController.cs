using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Move")]
    public float moveSpeed;
    public float jumpPower;
    public bool isJump = true;
    private Vector2 currentMove;

    [Header("Look")]
    public Transform cameraTransform;
    public float minXLook;
    public float maxXLook; // 
    public float mouseSensitivity; // 마우스 민감도
    private float currentXLook;
    private float currentYLook;
    private Vector2 mouseDeta;


    Rigidbody _rigidbody;
    
    // Start is called before the first frame update
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Look();
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        Move();
    }

    #region Move
    private void Move()
    {
        Vector3 dir = (transform.forward * currentMove.y) + (transform.right * currentMove.x);
        dir *= moveSpeed;
        dir.y = _rigidbody.velocity.y;

        _rigidbody.velocity = dir;
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            currentMove = context.ReadValue<Vector2>();
        }
        else if (context.phase == InputActionPhase.Canceled)
        {
            currentMove = Vector2.zero;
        }
    }
    #endregion

    #region Jump
    public void Jump(float _jumpPower)
    {
        _rigidbody.AddForce((Vector3.up * jumpPower) * _jumpPower, ForceMode.Impulse);
    }
    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started && isJump == true)
        {
            Jump(1);
            isJump = false;
        }
    }
    #endregion

    #region Look
    private void Look()
    {
        currentXLook -= mouseDeta.y * mouseSensitivity;

        currentXLook = Mathf.Clamp(currentXLook, minXLook, maxXLook);

        currentYLook += mouseDeta.x * mouseSensitivity;

        cameraTransform.localEulerAngles = new Vector3(currentXLook, 0f, 0f);

        transform.eulerAngles = new Vector3(0f, currentYLook, 0f);
    }
    public void OnLook(InputAction.CallbackContext context)
    {
        mouseDeta = context.ReadValue<Vector2>();
    }
    #endregion
}
