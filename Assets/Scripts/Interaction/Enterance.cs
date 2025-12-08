using UnityEngine;
using System.Collections;


public class Enterance : Interactable
{
    
    [SerializeField] private GameObject ConfimPanel;
    [SerializeField] private bool trainStation;

    [Header("Fill if NOT a train station")]
    [SerializeField] private string areaSceneName;
    [SerializeField] private string sceneType = "Area";
    [SerializeField] private Vector3 nextPlayerPlacement;

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
          if (!trainStation)
            _gameManager.sceneToLoad = areaSceneName;
            _gameManager.sceneTypeToGoTo = sceneType;
            _gameManager.nextPlayerPlacement = nextPlayerPlacement;
        }
    }

}
