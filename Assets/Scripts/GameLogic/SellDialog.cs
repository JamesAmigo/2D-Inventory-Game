using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SellDialog : MonoBehaviour
{
    private InventoryItem item;

    private int sellAmount = 1;

    [SerializeField]
    private TextMeshProUGUI itemNameText;

    [SerializeField]
    private TextMeshProUGUI itemAmountText;

    [SerializeField]
    private TextMeshProUGUI sellPriceText;
    private void OnEnable() {
        itemNameText.text = "Sell " + item.itemData.itemName + "?";        
        sellPriceText.text = "$" + (item.itemData.itemValue * sellAmount).ToString();
    }
    public void SetItem(InventoryItem item)
    {
        this.item = item;
    }
    public void ChangeAmount(int amount)
    {
        if(sellAmount <= 1 || sellAmount >= item.stackCount)
        {
            return;
        }
        sellAmount += amount;
        itemAmountText.text = sellAmount.ToString();
        sellPriceText.text = "$" + (item.itemData.itemValue * sellAmount).ToString();
    }
    public void SetMin()
    {
        sellAmount = 1;
        itemAmountText.text = sellAmount.ToString();
        sellPriceText.text = "$" + (item.itemData.itemValue * sellAmount).ToString();
    }
    public void SetMax()
    {
        sellAmount = item.stackCount;
        itemAmountText.text = sellAmount.ToString();
        sellPriceText.text = "$" + (item.itemData.itemValue * sellAmount).ToString();
    }
    public void Sell()
    {
        item.RemoveItem(sellAmount);
        Cancel();
    }
    public void Cancel()
    {        
        sellAmount = 1;
        itemAmountText.text = sellAmount.ToString();
        item = null;
        gameObject.SetActive(false);
    }

}
