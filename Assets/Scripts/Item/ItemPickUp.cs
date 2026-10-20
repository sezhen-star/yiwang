using UnityEngine;

public class ItemPickUp : MonoBehaviour, IInteractable
{
    public string itemName;

    private Renderer itemRenderer;

    private Color originalColor;

    private void Awake()
    {
        itemRenderer = GetComponent<Renderer>();

        originalColor = itemRenderer.material.color;
    }

    public string GetPrompt()
    {
        return "[E] 拾取" + itemName;
    }

    public void Interact()
    {
        Debug.Log(itemName + "被拾取");
    }

    public void HighLight()
    {
        itemRenderer.material.color = Color.yellow;
    }

    public void UnHighLight()
    {
        itemRenderer.material.color = originalColor;
    }

    public string GetItemName()
    {
        return itemName;
    }
}