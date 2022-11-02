using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : Interactable
{
    public GameObject InitialState;
    public GameObject DestroyedState;
    public bool IsDestroyed;

    public override void Interact() 
    {
        Destroy();
    }

    public void Reset() 
    {
        IsDestroyed = true;
        InitialState.SetActive(true);
        DestroyedState.SetActive(false);
    }

    public void Destroy() 
    {
        GameManager.GetInstance().OnObjectDestroyed?.Invoke();
        IsDestroyed = true;
        InitialState.SetActive(false);
        DestroyedState.SetActive(true);
    }
}
