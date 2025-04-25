using UnityEngine;
using UnityEngine.InputSystem;

public class InputPlayer : MonoBehaviour
{
    public static PlayerInput playerInput;

    public static Vector2 MoveInput { get; set; }

    public static bool IsThrowPressed {  get; set; }

    private InputAction MoveAction;
    private InputAction ThrowAction;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();

        MoveAction = playerInput.actions["Move"];
        ThrowAction = playerInput.actions["Throw"];
    }

    private void Update()
    {
        MoveInput = MoveAction.ReadValue<Vector2>();

        IsThrowPressed = ThrowAction.WasPressedThisFrame();
    }
}
