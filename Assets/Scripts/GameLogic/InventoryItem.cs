using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{

    public ItemsData itemData;
    private int stackCount;

    [SerializeField]
    private TMP_Text nameText;  

    [SerializeField]
    private Image itemImage;  

    [SerializeField]
    private TMP_Text stackCountText;  
    public InventoryItem(ItemsData itemData)
    {
        this.itemData = itemData;
        AddItem();
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

    public void RemoveItem()
    {
        stackCount--;
        stackCountText.text = stackCount.ToString();
    }

}
