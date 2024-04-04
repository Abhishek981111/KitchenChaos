using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerCounter : BaseCounter, IKitchenObjectParent
{
    [SerializeField] private KitchenObjectsSO kitchenObjectsSO;
    [SerializeField] private Transform counterTopPoint;


    private KitchenObjects kitchenObject;


    public override void Interact(Player player) 
    {  
        if(kitchenObject == null)
        {
         Transform kitchenObjectsTransform = Instantiate(kitchenObjectsSO.prefab, counterTopPoint);
         kitchenObjectsTransform.GetComponent<KitchenObjects>().SetKitchenObjectParent(this);
        }
        else
        {
         //Give the object to the player
         kitchenObject.SetKitchenObjectParent(player);
        }
    }

    public Transform GetKitchenObjectFollowTransform()
    {
        return counterTopPoint;
    }

    public void SetKitchenObject(KitchenObjects kitchenObject)
    {
        this.kitchenObject = kitchenObject;
    }

    public KitchenObjects GetKitchenObject()
    {
        return kitchenObject;
    }

    public void ClearKitchenObject()
    {
        kitchenObject = null;
    }

    public bool HasKitchenObject()
    {
        return kitchenObject != null;
    }
}
