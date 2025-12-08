using UnityEngine;

public class NPCinArea : Interactable
{
    [Header("Dialouge")]
    [SerializeField] private List<SpeechBubble> SpeechBubbles = new List<SpeechBubble>{};
    
    [Header("Dialouge")]

    public override void StartInteraction()
    {
        _gameManager.SwitchToMap("UI");
    }
}
