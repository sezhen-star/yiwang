using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class PlayerInteractor : MonoBehaviour
{
    private Inventory inventory;

    private IInteractable currentInteractable;

    [SerializeField] private TMP_Text promptText; //互动物品的文字

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

            promptText.text = currentInteractable.GetPrompt(); //互动物品的文字出现

            promptText.gameObject.SetActive(true);

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

            promptText.gameObject.SetActive(false); //互动物品的文字消失
        }
    }
}