using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    PlayerInput playerInput;
    [SerializeField] private GameplayInputHandler gameplay;
    [SerializeField] private UIInputHandler ui;

    private bool IsGameplay => playerInput.currentActionMap.name == "Gameplay";
    private bool IsUI => playerInput.currentActionMap.name == "UI";

    State currentState = State.Gameplay;
    enum State { UI, Gameplay, Minigame }

    //singleton pattern
    private static InputManager instance;
    public static InputManager Instance
    {
        // Ensure there is always an instance of the sound manager
        get
        {
            // Check if the instance is null or has been destroyed
            if (instance == null || instance.gameObject == null)
            {
                // Find an existing instance in the scene
                instance = FindObjectOfType<InputManager>();

                // If no instance exists, create a new one
                if (instance == null)
                {
                    GameObject obj = new GameObject(nameof(InputManager));
                    instance = obj.AddComponent<InputManager>();
                }
            }
            return instance;
        }
    }

    private void Awake()
    {
        // Ensure the instance isn't destroyed when loading new scenes
        if (instance == null || instance.gameObject == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            // If another instance exists, destroy this one
            Destroy(gameObject);
            return;
        }

        playerInput = GetComponent<PlayerInput>();
    }

    public void OnMove(InputAction.CallbackContext ctx)
    {
        if (!IsGameplay) return;
        gameplay.OnMove(ctx);
    }

    public void OnSubmit(InputAction.CallbackContext ctx)
    {
        if (!IsUI) return;
        ui.OnSubmit(ctx);
    }

    public void OnCancel(InputAction.CallbackContext ctx)
    {
        if (!IsUI) return;
        ui.OnCancel(ctx);
    }

    void Update()
    {
        switch (currentState)
        {
            case State.UI:
                playerInput.SwitchCurrentActionMap("UI");
                break;
            case State.Gameplay:
                playerInput.SwitchCurrentActionMap("Gameplay");
                break;
            case State.Minigame:
                ChangeToMinigame();
                break;
        } 
    }

    void ChangeToMinigame()
    {}
}
