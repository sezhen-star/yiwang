using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerInteractor : MonoBehaviour
{
    private Inventory inventory;

    private ItemPickUp currentItem;

    private void Start()
    {
        inventory = GetComponent<Inventory>();
    }

    private void Update()
    {
        if (currentItem != null && Input.GetKeyDown(KeyCode.E))
        {
            inventory.AddItem(currentItem.itemName);

            Destroy(currentItem.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        ItemPickUp item = other.GetComponent<ItemPickUp>();

        if (item != null)
        {
            currentItem = item;

            Debug.Log("按E拾取： " + item.itemName);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        ItemPickUp item = other.GetComponent<ItemPickUp>();

        if (item == currentItem)
        {
            currentItem = null;
        }
    }
}