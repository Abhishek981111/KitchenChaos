using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : MonoBehaviour
{

   [SerializeField] private KitchenObjectsSO kitchenObjectsSO;
   [SerializeField] private Transform counterTopPoint;
   [SerializeField] private ClearCounter secondClearCounter;
   [SerializeField] private bool testing;


   private KitchenObjects kitchenObject;


   private void Update()
   {
      if(testing && Input.GetKeyDown(KeyCode.T))
      {
         if(kitchenObject != null)
         {
            kitchenObject.SetClearCounter(secondClearCounter);
         }
      }
   }


   public void Interact()
   {
      if(kitchenObject == null)
      {
         Transform kitchenObjectsTransform = Instantiate(kitchenObjectsSO.prefab, counterTopPoint);
         kitchenObjectsTransform.GetComponent<KitchenObjects>().SetClearCounter(this);
      }
      else
      {
         Debug.Log(kitchenObject.GetClearCounter());
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
