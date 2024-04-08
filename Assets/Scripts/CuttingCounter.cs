using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounter : BaseCounter
{

    [SerializeField] private KitchenObjectsSO cutKitchenObjectSO;

    public override void Interact(Player player)
    {
        if(!HasKitchenObject())
        {
            //There is no kitchen Object here
            if(player.HasKitchenObject())
            {
                //Player is carrying something
                player.GetKitchenObject().SetKitchenObjectParent(this);
            }
            else
            {
                //Player is not carrying anything
            }
        }
        else
        {
            //There is a kitchen object on this counter
            if(player.HasKitchenObject())
            {
                //Player is carrying something
            }
            else
            {
                //Player is not carrying anything
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }
    }

    public override void InteractAlternate(Player player)
    {
        if(HasKitchenObject())
        {
            //There is a kitchen Object here
            GetKitchenObject().DestroySelf();

            KitchenObjects.SpawnKitchenObject(cutKitchenObjectSO, this);

        }
    }
}
