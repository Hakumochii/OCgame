using UnityEngine;

public class EnterArea : Interactable
{
    [Header("UI Elements")]
    [SerializeField] private GameObject ConfimPanel;

    protected override void StartInteraction()
    {
        Instantiate(ConfimPanel, new Vector3(0, 0, 0), Quaternion.identity);
    }
}
