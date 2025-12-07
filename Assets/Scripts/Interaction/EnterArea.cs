using UnityEngine;
using System.Collections;


public class EnterArea : Interactable
{
    private GameManager _gameManager;
    [SerializeField] private string areaSceneName;
    [SerializeField] private string sceneType = "Area";
    [SerializeField] private GameObject ConfimPanel;
    [SerializeField] private Vector3 nextPlayerPlacement;
    
    void Awake()
    {
        _gameManager = FindFirstObjectByType<GameManager>();
    }

    public override void StartInteraction()
    {
        _gameManager.SwitchToMap("UI");
        StartCoroutine(ShowConfimPanel());
    }

    IEnumerator ShowConfimPanel()
    {
        yield return null;

        if (_gameManager.currentPanel == null)
        {
          _gameManager.currentPanel = Instantiate(ConfimPanel, new Vector3(0, 0, 0), Quaternion.identity); 
          _gameManager.sceneToLoad = areaSceneName;
          _gameManager.sceneTypeToGoTo = sceneType;
          _gameManager.nextPlayerPlacement = nextPlayerPlacement;
        }
    }

}
