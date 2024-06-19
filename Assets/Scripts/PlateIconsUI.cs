using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateIconsUI : MonoBehaviour
{
    [SerializeField] private PlateKitchenObject plateKitchenObject;
    [SerializeField] private Transform iconTemplate;


    private void Start()
    {
        plateKitchenObject.OnIngredientAdded += PlateKitchenObject_OnIngredientAdded;
    }

    private void PlateKitchenObject_OnIngredientAdded(object sender, PlateKitchenObject.OnIngredientAddedEventArgs e)
    {
        UpdateVisual();
    }

    private void UpdateVisual()
    {
        foreach(KitchenObjectsSO kitchenObjectsSO in plateKitchenObject.GetKitchenObjectsSOList())
        {
            Transform iconTransform = Instantiate(iconTemplate, transform);
            iconTemplate.GetComponent<PlateIconSingleUI>().SetKitchenObjectSO(kitchenObjectsSO);
        }
    }
}
