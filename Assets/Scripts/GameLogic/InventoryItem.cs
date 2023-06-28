using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{

    public ItemsData itemData;
    public int stackCount;

    [SerializeField]
    private TMP_Text nameText;  

    [SerializeField]
    private Image itemImage;  

    [SerializeField]
    private TMP_Text stackCountText;

    private void Start() 
    {
        InitializeData(itemData);
    }

    public void InitializeData(ItemsData data)
    {
        itemData = data;
        this.name = data.itemName;
        itemImage.sprite = data.itemSprite;
        nameText.text = data.itemName;
        stackCount++;
        stackCountText.text = stackCount.ToString();
    }

    public void AddItem()
    {
        stackCount++;
        stackCountText.text = stackCount.ToString();
    }

    public void RemoveItem(int count)
    {
        stackCount -= count;
        stackCountText.text = stackCount.ToString();
        InventoryManager.instance.MoneyChange(itemData.itemValue * count);
        if(stackCount <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    public void StartSell()
    {
        UIManager.instance.OpenSellDialog(this);
    }

}
