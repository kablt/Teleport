using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HoverEnterUIHandler : MonoBehaviour
{
    public GameObject uiGameObject; // Assign your UI GameObject in the inspector

    private XRSocketTagInteractor socketTagInteractor;

    private void Awake()
    {
        socketTagInteractor = GetComponent<XRSocketTagInteractor>();
    }

    private void OnEnable()
    {
        // Make sure the component is not null
        if (socketTagInteractor != null && uiGameObject != null)
        {
            // Subscribe to the appropriate events from the XRSocketInteractor
            socketTagInteractor.hoverEntered.AddListener(DisplayUI);
            socketTagInteractor.hoverExited.AddListener(HideUIImmediately);
        }
    }

    private void OnDisable()
    {
        // Always make sure to unsubscribe from events when the object is disabled
        if (socketTagInteractor != null)
        {
            socketTagInteractor.hoverEntered.RemoveListener(DisplayUI);
            socketTagInteractor.hoverExited.RemoveListener(HideUIImmediately);
        }
    }

    private void DisplayUI(HoverEnterEventArgs arg)
    {
        // Show the UI GameObject
        uiGameObject.SetActive(true);
        // Hide it after 2 seconds by invoking the HideUI method
        Invoke("HideUI", 2f);
    }

    private void HideUI()
    {
        // Hide the UI GameObject
        if (uiGameObject.activeSelf)
        {
            uiGameObject.SetActive(false);
        }
    }

    private void HideUIImmediately(HoverExitEventArgs arg)
    {
        // Cancel the delayed HideUI invocation in case the object is removed before the 2 seconds are up
        CancelInvoke("HideUI");
        // Hide the UI GameObject immediately
        HideUI();
    }
}
