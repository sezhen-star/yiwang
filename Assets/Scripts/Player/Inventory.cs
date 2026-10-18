using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<string> items = new();

    public void AddItem(string itemName)
    {
        items.Add(itemName);

        Debug.Log(itemName + "已加入背包");
    }
}