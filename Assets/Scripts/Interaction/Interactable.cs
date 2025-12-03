using UnityEngine;

public class Interactable : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            StartInteraction();
        }
        else
        {
            return;
        }
        
    }

    protected virtual void StartInteraction(){}
}
