using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateKitchenObject : KitchenObjects
{
    [SerializeField] private List<KitchenObjectsSO> validKitchenObjectSOList;
    private List<KitchenObjectsSO> kitchenObjectsSOList;


    private void Awake()
    {   
        kitchenObjectsSOList = new List<KitchenObjectsSO>();
    }


    public bool TryAddIngredient(KitchenObjectsSO kitchenObjectsSO)
    {   
        if (!validKitchenObjectSOList.Contains(kitchenObjectsSO))
        {
            //Not a valid Ingredient
            return false;
        }
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
