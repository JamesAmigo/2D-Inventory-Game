using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    
    private static InventoryManager _instance;
    public static InventoryManager instance { get { return _instance; } }

    [SerializeField]
    private GameObject inventoryItemPrefab;
    private Dictionary<ItemsData, InventoryItem> inventoryItems = new Dictionary<ItemsData, InventoryItem>();

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
        if(inventoryItems.TryGetValue(itemData, out InventoryItem item))
        {
            item.gameObject.SetActive(true);
            item.AddItem();
        }
        else
        {
            inventoryItems.Add(itemData, UIManager.instance.FindItemIcon(itemData));
        }
    }

    public void MoneyChange(int amount)
    {
        money += amount;
        UIManager.instance.UpdateMoneyText(money);
    }
}
