using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class UIPanel : MonoBehaviour
{
    public GameObject firstSelected;

    void OnEnable()
    {
        StartCoroutine(SelectFirstFrameDelayed());
    }

    IEnumerator SelectFirstFrameDelayed()
    {
        yield return null;
        Canvas.ForceUpdateCanvases();

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(firstSelected);
    }

}
