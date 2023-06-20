using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    private static InventoryManager _instance;
    public static InventoryManager instance { get { return _instance; } }

    [SerializeField]
    private GameObject inventoryItemPrefab;
    public Dictionary<ItemsData, InventoryItem> inventoryItems = new Dictionary<ItemsData, InventoryItem>();
    [SerializeField]
    private GameObject inventoryItemsIcons;

    
    private void Awake()
    {
        if(_instance != null && _instance != this)
        {
            Destroy(this);
        }
        else
        {
            _instance = this;
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
