using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class DisaableGrabbingHands : MonoBehaviour
{
    public GameObject LeftHandModel;
    public GameObject RightHandModel;


    // Start is called before the first frame update
    void Start()
    {
    XRGrabInteractable grabinteractable = GetComponent<XRGrabInteractable>();
        grabinteractable.selectEntered.AddListener(HideGrabbingHand);
        grabinteractable.selectEntered.AddListener(ShowgrabbingHand);
       
    }


    public void HideGrabbingHand(SelectEnterEventArgs args)
    {
        if(args.interactorObject.transform.tag == "Left Hand")
        {
            LeftHandModel.SetActive(false);
        }
        else if(args.interactorObject.transform.tag == "Right Hand")
        {
            RightHandModel.SetActive(false);
        }
    }

    public void ShowgrabbingHand(SelectEnterEventArgs args)
    {
        if (args.interactorObject.transform.tag == "Left Hand")
        {
            LeftHandModel.SetActive(true);
        }
        else if (args.interactorObject.transform.tag == "Right Hand")
        {
            RightHandModel.SetActive(true);
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
