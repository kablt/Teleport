using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.UI;
using System;

public class SekectorEnterUIHandler : MonoBehaviour
{
    public GameObject UIGameObject;

    private XRSocketInteractor socketInteractor;

    private void Awake()
    {
        socketInteractor = GetComponent<XRSocketInteractor>();  
    }
    // Start is called before the first frame update
    void Start()
    {
        if(socketInteractor != null && UIGameObject != null)
        {
            socketInteractor.hoverEntered.AddListener(DisplayUI);
            //socketInteractor.hoverEntered.AddListener(HideUIImmediately);
        }
    }

    private void DisplayUI(HoverEnterEventArgs arg0)
    {
        throw new NotImplementedException();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
