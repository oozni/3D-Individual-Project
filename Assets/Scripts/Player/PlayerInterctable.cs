using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInterction : MonoBehaviour
{
    public float checkRayTime; // �� �ʸ��� Ray�� ������ ��
    private float lastCheckTime; // Ray�� ������ ������ �ð�
    public float maxCheckDistanc; // Ray ����
    public LayerMask _layerMask; // � ���̾ �޷��ִ� ������Ʈ�� ���� �Ұ���

    public GameObject curInteractObj; // ��ȣ�ۿ��� obj�� ����
    private IInteractable curInteractable; // ĳ��

    public TextMeshProUGUI promptText;
    private Camera camera;

    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - lastCheckTime > checkRayTime)
        {
            lastCheckTime = Time.time;

            Ray ray = camera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, maxCheckDistanc, _layerMask))
            {
                if (hit.collider.gameObject != curInteractObj)
                {
                    curInteractObj = hit.collider.gameObject;
                    curInteractable = hit.collider.GetComponent<IInteractable>();
                    SetPromptText();
                }
            }
            else
            {
                curInteractable = null;
                curInteractObj = null;
                promptText.gameObject.SetActive(false);
            }
        }
         
    }

    private void SetPromptText()
    {
        promptText.gameObject.SetActive(true);
        promptText.text = curInteractable.GetInteractPrompt();
    }

    public void OnImventory(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started && curInteractable != null)
        {
            curInteractable.OnInteract();
            curInteractObj = null;
            curInteractable = null;
            promptText.gameObject.SetActive(false);
        }
    }
}
