using Mono.Cecil;
using System.Collections.Generic;   
using TMPro;
using UnityEngine;

public class PlayerInteractor : MonoBehaviour
{
    private Inventory inventory;

    private IInteractable currentInteractable;

    [Header("交互提示")]
    [SerializeField] private TMP_Text promptText; //互动物品的文字

    //相机视野
    [Header("Alt视野检测")]
    [SerializeField] private Camera mainCamera;
    private readonly List<IInteractable> altHighLightedInteractables = new List<IInteractable>(); 


    private void Start()
    {
        inventory = GetComponent<Inventory>();

        //获取摄像机视野
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }

        if (mainCamera == null)
        {
            Debug.LogError("PlayerInteractor 找不到主摄像机。", this);
        }
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

                altHighLightedInteractables.Remove(currentInteractable);

                currentInteractable = null;

                promptText.gameObject.SetActive(false);

                Destroy(item.gameObject);
            }
        }

        //按alt高亮物品
        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            HighLightVisibleInteractables();
        }
        
        if (Input.GetKeyUp(KeyCode.LeftAlt)) 
        {
            ResetHighLight();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        IInteractable interactable = other.GetComponent<IInteractable>();

        if (interactable == null)
        {
            return;
        }

        currentInteractable = interactable;  //进入物品范围

        currentInteractable.HighLight();

        promptText.text = currentInteractable.GetPrompt(); //互动物品的文字出现

        promptText.gameObject.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        IInteractable interactable = other.GetComponent<IInteractable>();

        if (interactable == null || interactable != currentInteractable) return;

        if (!Input.GetKey(KeyCode.LeftAlt))
        {
            interactable.UnHighLight();
        }

        currentInteractable = null;   //离开物品范围

        promptText.gameObject.SetActive(false); //互动物品的文字消失
    }

    private void HighLightVisibleInteractables() //高亮场景内所有物品
    {
        if (mainCamera == null)
        {
            return;
        }

        altHighLightedInteractables.Clear();

        ItemPickUp[] allItems = FindObjectsByType<ItemPickUp>(FindObjectsSortMode.None);

        foreach (ItemPickUp item in allItems)
        {
            if (item == null) continue;

            Renderer itemRenderer = item.GetComponentInChildren<Renderer>();

            Vector3 targetPosition;

            if (itemRenderer != null)
            {
                targetPosition = itemRenderer.bounds.center;
            }
            else
            {
                targetPosition = item.transform.position;
            }

            Vector3 viewPortPosition = mainCamera.WorldToViewportPoint(targetPosition);

            bool isInCameraView =
                viewPortPosition.z > 0f &&
                viewPortPosition.x >= 0f &&
                viewPortPosition.x <= 1f &&
                viewPortPosition.y >= 0f &&
                viewPortPosition.y <= 1f;

            if (!isInCameraView)
            {
                continue;
            }

            item.HighLight();

            altHighLightedInteractables.Add(item);
        }
    }

    private void ResetHighLight() //取消高亮
    {
        foreach (IInteractable interactable in altHighLightedInteractables)
        {
            if (interactable == null) continue;

            if (interactable != currentInteractable)
            {
                interactable.UnHighLight();
            }
        }

        altHighLightedInteractables.Clear();

        if (currentInteractable != null)
        {
            currentInteractable.HighLight();
        }
    }
}