using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : SingletonBase<InventoryManager>
{

    private Dictionary<ItemsData, InventoryItem> inventoryItemsDict = new Dictionary<ItemsData, InventoryItem>();

    private int money;

    //Here we override the Awake method from the SingletonBase class.
    protected override void Awake()
    {
        //However, we still want to call the Awake method from the SingletonBase class, so we use the "base" keyword.
        base.Awake();
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
