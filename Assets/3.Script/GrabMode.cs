using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class GrabMode : MonoBehaviour
{
    [SerializeField] Button[] stateBt;  //0ÀÌ toggle, 1ÀÌ state
    [SerializeField] GameObject[] hand;

    XRBaseControllerInteractor.InputTriggerType toggle = XRBaseControllerInteractor.InputTriggerType.Toggle;
    XRBaseControllerInteractor.InputTriggerType stateChange = XRBaseControllerInteractor.InputTriggerType.StateChange;

    public void ToggleBT()
    {
        stateBt[0].interactable = false;
        hand[0].GetComponent<XRDirectInteractor>().selectActionTrigger = toggle;
        hand[1].GetComponent<XRDirectInteractor>().selectActionTrigger = toggle;
        stateBt[1].interactable = true;
    }
    public void StateBT()
    {
        stateBt[1].interactable = false;
        hand[1].GetComponent<XRDirectInteractor>().selectActionTrigger = stateChange;
        hand[0].GetComponent<XRDirectInteractor>().selectActionTrigger = stateChange;
        stateBt[0].interactable = true;
    }
}
