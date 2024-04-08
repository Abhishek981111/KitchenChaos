using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounter : BaseCounter
{

    [SerializeField] private CuttingRecipeSO[] cuttingRecipeSOArray;

    public override void Interact(Player player)
    {
        if(!HasKitchenObject())
        {
            //There is no kitchen Object here
            if(player.HasKitchenObject())
            {
                //Player is carrying something
                if(HasRecipeWithInput(player.GetKitchenObject().GetKitchenObjectsSO()))
                {
                    //Player is carrying something that can be cut
                    player.GetKitchenObject().SetKitchenObjectParent(this);
                }
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
        if(HasKitchenObject() && HasRecipeWithInput(GetKitchenObject().GetKitchenObjectsSO()))
        {
            //There is a kitchen Object here and it can be cut 
            KitchenObjectsSO outputkitchenObjectSO = GetOutputForInput(GetKitchenObject().GetKitchenObjectsSO());
            GetKitchenObject().DestroySelf();

            KitchenObjects.SpawnKitchenObject(outputkitchenObjectSO, this);

        }
    }

    private bool HasRecipeWithInput(KitchenObjectsSO inputKitchenObjectSO)
    {
        foreach(CuttingRecipeSO cuttingRecipeSO in cuttingRecipeSOArray)
        {
            if (cuttingRecipeSO.input == inputKitchenObjectSO)
            {
                return true;
            }
        }
        return false;
    }

    private KitchenObjectsSO GetOutputForInput(KitchenObjectsSO inputKitchenObjectSO)
    {
        foreach(CuttingRecipeSO cuttingRecipeSO in cuttingRecipeSOArray)
        {
            if (cuttingRecipeSO.input == inputKitchenObjectSO)
            {
                return cuttingRecipeSO.output;
            }
        }
        return null;
    }
}
