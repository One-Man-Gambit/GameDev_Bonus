using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : Interactable
{
    public List<Destructible> targets;


    public override void Interact() 
    {
        foreach (Destructible d in targets) 
        {
            d.Destroy();
        }

        Destroy(this.gameObject);
    }
}
