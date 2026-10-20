using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerInteractor : MonoBehaviour
{
    private Inventory inventory;

    private IInteractable currentInteractable;

    private void Start()
    {
        inventory = GetComponent<Inventory>();
    }

    private void Update()
    {
        if (currentInteractable != null && Input.GetKeyDown(KeyCode.E))
        {
            currentInteractable.Interact();

            ItemPickUp item = currentInteractable as ItemPickUp;

            if (item != null)
            {
                inventory.AddItem(item.GetItemName());

                Destroy(item.gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        IInteractable interactable = other.GetComponent<IInteractable>();

        if (interactable != null)
        {
            currentInteractable = interactable;  //进入物品范围

            currentInteractable.HighLight();

            Debug.Log(interactable.GetPrompt());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        IInteractable interactable = other.GetComponent<IInteractable>();

        if (interactable == currentInteractable)
        {
            currentInteractable.UnHighLight();

            currentInteractable = null;   //离开物品范围
        }
    }
}