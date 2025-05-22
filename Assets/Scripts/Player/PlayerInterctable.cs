using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInterction : MonoBehaviour
{
    public float checkRayTime; // 몇 초마다 Ray가 생성될 지
    private float lastCheckTime; // Ray가 생성된 마지막 시간
    public float maxCheckDistanc; // Ray 길이
    public LayerMask _layerMask; // 어떤 레이어가 달려있는 오브젝트를 추출 할건지

    public GameObject curInteractObj; // 상호작용한 obj의 정보
    private IInteractable curInteractable; // 캐싱

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
