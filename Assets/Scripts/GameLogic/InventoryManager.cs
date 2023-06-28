using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    
    private static InventoryManager _instance;
    public static InventoryManager instance { get { return _instance; } }

    private Dictionary<ItemsData, InventoryItem> inventoryItemsDict = new Dictionary<ItemsData, InventoryItem>();

    private int money;

    
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
        if(inventoryItemsDict.TryGetValue(itemData, out InventoryItem item))
        {
            item.gameObject.SetActive(true);
            item.AddItem();
        }
        else
        {
            inventoryItemsDict.Add(itemData, UIManager.instance.FindItemIcon(itemData));
        }
    }

    public void MoneyChange(int amount)
    {
        money += amount;
        UIManager.instance.UpdateMoneyText(money);
    }
}
