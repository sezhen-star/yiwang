using UnityEngine;
public class InteractableObject : MonoBehaviour
{
    private Renderer objectRenderer;

    private Color originalColor;

    private void Awake()
    {
        objectRenderer = GetComponent<Renderer>();

        originalColor = objectRenderer.material.color;
    }

    public void Highlight()
    {
        objectRenderer.material.color = Color.yellow; //HightLight Color
    }

    public void UnHighLight()
    {
        objectRenderer.material.color = originalColor;
    }
}