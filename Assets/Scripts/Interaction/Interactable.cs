using UnityEngine;

public class Interactable : MonoBehaviour
{
    protected GameManager _gameManager;

    public virtual void StartInteraction(){}

    protected void Awake()
    {
        _gameManager = FindFirstObjectByType<GameManager>();
    }
}
