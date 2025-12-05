using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonEffects : MonoBehaviour
{
    GameManager _gameManager;

    void Awake()
    {
        _gameManager = FindFirstObjectByType<GameManager>();
    }

    public void GoToScene()
    {
        SceneManager.LoadScene(_gameManager.sceneToLoad);
    }

    public void Cancel()
    {
        Destroy(_gameManager.currentPanel);
        _gameManager.sceneToLoad = null;
        _gameManager.SwitchToMap(_gameManager.currentScene);
    }
}
