using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] Animator closedDoorAnimator;
    [SerializeField] Animator buttonAnimator;
    [SerializeField] Material materialPressedButton;
    [SerializeField] Material materialButton;
    [SerializeField] bool canTurnOffLaser;

    public event EventHandler OnButtonUnpressed;
    public event EventHandler OnButtonPressed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collisioninfo)
    {
            gameObject.GetComponent<MeshRenderer>().material = materialPressedButton;
            buttonAnimator.SetBool("isPressed", true);
       
        if (!canTurnOffLaser)
        {
            closedDoorAnimator.SetBool("isOpen", true);
        }
        else
            OnButtonPressed?.Invoke(this, EventArgs.Empty);
    }
    private void OnCollisionExit(Collision collisioninfo)
    {
            gameObject.GetComponent<MeshRenderer>().material = materialButton;
            buttonAnimator.SetBool("isPressed", false);
        
        if (!canTurnOffLaser)
        {
            closedDoorAnimator.SetBool("isOpen", false);
        }
        else
            OnButtonUnpressed?.Invoke(this, EventArgs.Empty);
    }
}
