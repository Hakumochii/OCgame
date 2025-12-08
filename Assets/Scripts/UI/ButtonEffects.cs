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
        _gameManager.currentSceneType = _gameManager.sceneTypeToGoTo;
        _gameManager.sceneTypeToGoTo = null;
        SceneManager.LoadScene(_gameManager.sceneToLoad);
    }

    public void Cancel()
    {
        Destroy(_gameManager.currentPanel);
        _gameManager.sceneToLoad = null;
        _gameManager.SwitchToMap(_gameManager.currentSceneType);
    }
    
    public void GoToNewDistrict(District districtToGoTo)
    {
        _gameManager.sceneToLoad = districtToGoTo.areaSceneName;
        _gameManager.sceneTypeToGoTo = "Overworld";
        _gameManager.nextPlayerPlacement = districtToGoTo.nextPlayerPlacement;
        GoToScene();
    }

}


