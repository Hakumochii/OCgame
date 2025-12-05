using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterInteraction : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;
    
    public bool isInteractableNear;
    Interactable interactable;

    public void OnInteract(InputAction.CallbackContext ctx)
    {
        if (!ctx.performed) return;
        Debug.Log("interact was pressed");
        if (!isInteractableNear) return;

        interactable.StartInteraction();
    }

    void OnTriggerEnter(Collider other)
    {
        var interact = other.GetComponent<Interactable>();
        if (interact != null)
        {
            interactable = interact;
            isInteractableNear = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Interactable>() == interactable)
        {
            interactable = null;
            isInteractableNear = false;
        }
    }
}
