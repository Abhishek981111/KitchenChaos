using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerCounter : BaseCounter
{
    public event EventHandler OnPlayerGrabbedObject;

    [SerializeField] private KitchenObjectsSO kitchenObjectsSO;


    public override void Interact(Player player) 
    {  
        Transform kitchenObjectsTransform = Instantiate(kitchenObjectsSO.prefab);
        kitchenObjectsTransform.GetComponent<KitchenObjects>().SetKitchenObjectParent(player);
        OnPlayerGrabbedObject?.Invoke(this, EventArgs.Empty);
    }
}
