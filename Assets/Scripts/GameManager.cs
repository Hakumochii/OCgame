using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;

    State currentState = State.UI;
    enum State { UI, Gameplay, Minigame }

    // Singleton pattern because there should only be one and many scripts acess it
    private static GameManager instance;
    public static GameManager Instance
    {
        // Ensure there is always an instance of the sound manager
        get
        {
            // Check if the instance is null or has been destroyed
            if (instance == null || instance.gameObject == null)
            {
                // Find an existing instance in the scene
                instance = FindObjectOfType<GameManager>();

                // If no instance exists, create a new one
                if (instance == null)
                {
                    GameObject obj = new GameObject(nameof(GameManager));
                    instance = obj.AddComponent<GameManager>();
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
