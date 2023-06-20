using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;

    [SerializeField]
    private GameObject inventoryItemPrefab;
    public Dictionary<ItemsData, InventoryItem> inventoryItems = new Dictionary<ItemsData, InventoryItem>();
    [SerializeField]
    private GameObject inventoryItemsIcons;

    
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogError("InventoryManager already exists");
            Destroy(this);
        }
    }
    public void Add(ItemsData itemData)
    {
        if(inventoryItems.TryGetValue(itemData, out InventoryItem item))
        {
            item.AddItem();
        }
        else
        {
            GameObject newItem = Instantiate(inventoryItemPrefab, inventoryItemsIcons.transform);
            newItem.GetComponent<InventoryItem>().InitializeData(itemData);
            newItem.transform.SetParent(inventoryItemsIcons.transform);

            inventoryItems.Add(itemData, newItem.GetComponent<InventoryItem>());
        }
    }
}
