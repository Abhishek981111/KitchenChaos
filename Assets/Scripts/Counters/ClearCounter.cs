using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : BaseCounter
{

   [SerializeField] private KitchenObjectsSO kitchenObjectsSO;


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
            if(player.GetKitchenObject() is PlateKitchenObject)
            {
               //Player is holding a plate
               PlateKitchenObject plateKitchenObject = player.GetKitchenObject() as PlateKitchenObject;
               if(plateKitchenObject.TryAddIngredient(GetKitchenObject().GetKitchenObjectsSO()))
               {
                  GetKitchenObject().DestroySelf();
               }
            }
         }
         else
         {
            //Player is not carrying anything
            GetKitchenObject().SetKitchenObjectParent(player);
         }
      }
   }
}
