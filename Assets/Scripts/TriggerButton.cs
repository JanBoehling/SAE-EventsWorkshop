using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerButton : MonoBehaviour, IInteractable
{
    [SerializeField] private UnityEvent<bool> onButtonPress;
    private bool isOn;

    public void Interact()
    {
        isOn = !isOn;
        onButtonPress?.Invoke(isOn);
    }
}

public interface IInteractable
{
    public void Interact();
}
