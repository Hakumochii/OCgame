using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    
    public GameObject currentCharacter;
    public Vector3 nextPlayerPlacement;

    [Header("Needs NO input")]
    public string sceneToLoad;
    public GameObject currentPanel;
    public string currentSceneType = "Overworld";
    public string sceneTypeToGoTo;
    public GameObject nextPlayer;
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

        playerInput = FindFirstObjectByType<PlayerInput>();
        Scene scene = SceneManager.GetActiveScene();

        DontDestroyOnLoad(this.gameObject);
    }

    public void SwitchToMap(string map)
    {
        playerInput.SwitchCurrentActionMap(map); 
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        PlaceCharacter();
        playerInput = FindFirstObjectByType<PlayerInput>();
    }

    public void PlaceCharacter()
    {
        currentCharacter = GameObject.FindWithTag("Player");
        currentCharacter.transform.position = nextPlayerPlacement;
    }

    
}
