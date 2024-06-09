using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] PlayerInput playerInput;
    [SerializeField] Transform leftEdge, rightEdge;
    private float relativePosition = 0.5f;
    private float relativeDirection = 0.0f;
    [SerializeField] private float sensitivity = 0.1f;
    [SerializeField] private GameObject fireballPrefab;
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
    }

    void Update()
    {
        relativePosition = Mathf.Clamp(relativePosition += sensitivity*relativeDirection*Time.deltaTime, 0.0f, 1.0f);
        transform.position = Vector3.Lerp(leftEdge.position, rightEdge.position, relativePosition);
    }

    private void ChangeDirection(InputAction.CallbackContext context){
        relativeDirection = context.ReadValue<Vector2>().x;
    }

    private void Shoot(InputAction.CallbackContext context){
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out RaycastHit hit)){
            Instantiate(fireballPrefab, transform.position, Quaternion.LookRotation(hit.point-transform.position,Vector3.up));
        }
    }
}
