using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : MonoBehaviour
{

   [SerializeField] private KitchenObjectsSO kitchenObjectsSO;
   [SerializeField] private Transform counterTopPoint;

   public void Interact()
   {
      Debug.Log("Interact!");
      Transform kitchenObjectsTransform = Instantiate(kitchenObjectsSO.prefab, counterTopPoint);
      kitchenObjectsTransform.localPosition = Vector3.zero;

      Debug.Log(kitchenObjectsTransform.GetComponent<KitchenObject>().GetKitchenObjectsSO().objectName);
   }
}
