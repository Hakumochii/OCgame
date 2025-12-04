using UnityEngine;
using UnityEngine.InputSystem;

public class GameplayInputHandler : MonoBehaviour
{
    [SerializeField] private CharacterMovement movement;

    public void OnMove(InputAction.CallbackContext ctx)
    {
        movement.OnMove(ctx);
    }
}
