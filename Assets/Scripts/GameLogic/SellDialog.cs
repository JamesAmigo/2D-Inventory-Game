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
        switch(amount)
        {
            case -1:
                SoundManager2D.instance.PlaySFX("Minus");
                if(sellAmount <= 1)
                {
                    return;
                }
                break;
            case 1:
                SoundManager2D.instance.PlaySFX("Add");
                if(sellAmount >= item.stackCount)
                {
                    return;
                }
                break;
            default:
                break;
        }
        
        sellAmount += amount;
        itemAmountText.text = sellAmount.ToString();
        sellPriceText.text = "$" + (item.itemData.itemValue * sellAmount).ToString();
    }
    public void SetMin()
    {
        SoundManager2D.instance.PlaySFX("Minus");
        sellAmount = 1;
        itemAmountText.text = sellAmount.ToString();
        sellPriceText.text = "$" + (item.itemData.itemValue * sellAmount).ToString();
    }
    public void SetMax()
    {
        SoundManager2D.instance.PlaySFX("Add");
        sellAmount = item.stackCount;
        itemAmountText.text = sellAmount.ToString();
        sellPriceText.text = "$" + (item.itemData.itemValue * sellAmount).ToString();
    }
    public void Sell()
    {
        SoundManager2D.instance.PlaySFX("Sold");
        item.RemoveItem(sellAmount);
        sellAmount = 1;
        itemAmountText.text = sellAmount.ToString();
        item = null;
        gameObject.SetActive(false);
    }
    public void Cancel()
    {        
        SoundManager2D.instance.PlaySFX("Back");
        sellAmount = 1;
        itemAmountText.text = sellAmount.ToString();
        item = null;
        gameObject.SetActive(false);
    }

}
