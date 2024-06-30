using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] PlayerInput playerInput;
    [SerializeField] Transform leftEdge, rightEdge;
    private float relativePosition = 0.5f;
    private float relativeDirection = 0.0f;
    [SerializeField] private float sensitivity = 0.1f;
    [SerializeField] private GameObject fireballPrefab;
    private float Mana = 5f;
    [SerializeField] private Slider slider;
    public int coin;
    [SerializeField] private Text coinText;
    [SerializeField] private Text FinalRezult;
    [SerializeField] private Text FinalCoin;
    [SerializeField] private GameObject LoseText;
    [SerializeField] private GameObject GamePanel;
    [SerializeField] private GameObject FinishPanel;
    [SerializeField] private Button OnMenu;
    [SerializeField] private Button RestartLevel;
    public int MaxCoin;
    private void OnEnable()
    {
        playerInput.Enable();
    }
    private void OnDisable()
    {
        playerInput.Disable();
    }

    private void Awake()
    {
        playerInput = new PlayerInput();
    }
    void Start()
    {
        playerInput.InGame.Movement.started += ChangeDirection;
        playerInput.InGame.Movement.canceled += ChangeDirection;
        playerInput.InGame.Shoot.started += Shoot;
        StartCoroutine(AddMana());
    }

    void Update()
    {
        relativePosition = Mathf.Clamp(relativePosition += sensitivity * relativeDirection * Time.deltaTime, 0.0f, 1.0f);
        transform.position = Vector3.Lerp(leftEdge.position, rightEdge.position, relativePosition);
        slider.value = Mana;
    }

    IEnumerator AddMana()
    {
        while (true)
        {
            if (Mana <= 5f) Mana = Mana + 0.01f;
            yield return new WaitForSeconds(0.01f);
        }
    }

    private void ChangeDirection(InputAction.CallbackContext context)
    {
        relativeDirection = context.ReadValue<Vector2>().x;
    }

    private void Shoot(InputAction.CallbackContext context)
    {
        if (Mana > 1f)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Instantiate(fireballPrefab, transform.position, Quaternion.LookRotation(hit.point - transform.position, Vector3.up));
            }
            Mana = Mana - 1f;
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Finish")) if (PlayerPrefs.GetInt("OpenLevels") == PlayerPrefs.GetInt("PanelsNumber")) PlayerPrefs.SetInt("OpenLevels", PlayerPrefs.GetInt("OpenLevels") + 1);
        if (!other.gameObject.CompareTag("FireBall") && !other.gameObject.CompareTag("Mana")) SceneManager.LoadScene(0);
        if (other.gameObject.CompareTag("Mana")){
            Mana = 5f;
            Destroy(other.gameObject); 
        } 
        if (other.gameObject.CompareTag("Coin")){
            coin++;

        }
    }
}
