using UnityEngine;
using System.Collections;


public class EnterArea : Interactable
{
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private string areaSceneName;
    private string sceneType = "Area";
    [SerializeField] private GameObject ConfimPanel;
    

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
        }
    }

}
