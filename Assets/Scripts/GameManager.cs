using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public string sceneToLoad;
    public GameObject currentPanel;
    public string currentSceneType = "Overworld";
    public string sceneTypeToGoTo;
    PlayerInput playerInput;

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
                instance = FindFirstObjectByType<GameManager>();

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

        playerInput = GetComponent<PlayerInput>();
        Scene scene = SceneManager.GetActiveScene();
    }

    public void SwitchToMap(string map)
    {
        playerInput.SwitchCurrentActionMap(map); 
    }
    
}
