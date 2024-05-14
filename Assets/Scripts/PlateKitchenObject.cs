using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateKitchenObject : KitchenObjects
{
    
    private List<KitchenObjectsSO> kitchenObjectsSOList;


    private void Awake()
    {   
        kitchenObjectsSOList = new List<KitchenObjectsSO>();
    }


    public bool TryAddIngredient(KitchenObjectsSO kitchenObjectsSO)
    {   
        if(kitchenObjectsSOList.Contains(kitchenObjectsSO))
        {
            //Already has this type
            return false;
        }
        else
        {
            kitchenObjectsSOList.Add(kitchenObjectsSO);
            return true;
        }
    }
}
