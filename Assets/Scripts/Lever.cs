using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    [SerializeField] bool canTurnOffLaser;
    [SerializeField] Animator closedDoorAnimator;
    public event EventHandler OnLeverOff;
    public event EventHandler OnLeverOn;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Lever")
        {
            if (!canTurnOffLaser)
            {
                closedDoorAnimator.SetBool("isOpen", true);
            }
            else
                OnLeverOn?.Invoke(this, EventArgs.Empty);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Lever")
        {
            if (!canTurnOffLaser)
            {
                closedDoorAnimator.SetBool("isOpen", false);
            }
            else
                OnLeverOff?.Invoke(this, EventArgs.Empty);
        }
    }
}

