using UnityEngine;
using UnityEngine.InputSystem;

public class UIInputHandler : MonoBehaviour
{
    public void OnSubmit(InputAction.CallbackContext ctx)
    {
        if (!ctx.performed) return;

        Debug.Log("UI Submit");
        // UI confirm logic
    }

    public void OnCancel(InputAction.CallbackContext ctx)
    {
        if (!ctx.performed) return;

        Debug.Log("UI Cancel");
        // Close menu, return, etc.
    }
}

