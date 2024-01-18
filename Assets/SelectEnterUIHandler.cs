using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SelectEnterUIHandler : MonoBehaviour
{
    public GameObject uiGameObject; 

    private XRSocketTagInteractor socketTagInteractor;

    private void Awake()
    {
        socketTagInteractor = GetComponent<XRSocketTagInteractor>();
    }

    private void OnEnable()
    {
     
        if (socketTagInteractor != null && uiGameObject != null)
        {

            socketTagInteractor.selectEntered.AddListener(DisplayUI);
            socketTagInteractor.selectExited.AddListener(HideUIImmediately);
        }
    }

    private void OnDisable()
    {

        if (socketTagInteractor != null)
        {
            socketTagInteractor.selectEntered.RemoveListener(DisplayUI);
            socketTagInteractor.selectExited.RemoveListener(HideUIImmediately);
        }
    }

    private void DisplayUI(SelectEnterEventArgs arg)
    {
        
        uiGameObject.SetActive(true);
        
        Invoke("HideUI", 2f);
    }

    private void HideUI()
    {
        
        if (uiGameObject.activeSelf)
        {
            uiGameObject.SetActive(false);
        }
    }

    private void HideUIImmediately(SelectExitEventArgs arg)
    {
        
        CancelInvoke("HideUI");
        
        HideUI();
    }
}
