using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : SingletonBase<UIManager>
{  
    [SerializeField]
    private GameObject inventoryItemsIcons;

    [SerializeField]
    private GameObject sellDialog;

    [SerializeField]
    private TextMeshProUGUI moneyText;
    
    //Here we override the Awake method from the SingletonBase class.
    protected override void Awake()
    {
        //However, we still want to call the Awake method from the SingletonBase class, so we use the "base" keyword.
        base.Awake();
    }

    // Start is called before the first frame update
    void Start()
    {
        foreach(Transform icon in inventoryItemsIcons.transform)
        {
            icon.gameObject.SetActive(false);
        }
    }

    public InventoryItem FindItemIcon(ItemsData itemData)
    {
        foreach(Transform icon in inventoryItemsIcons.transform)
        {
            if(icon.GetComponent<InventoryItem>().itemData == itemData)
            {
                icon.gameObject.SetActive(true);
                icon.GetComponent<InventoryItem>().AddItem();
                return icon.GetComponent<InventoryItem>();
            }
            
        }
        return null;
    }

    public void OpenSellDialog(InventoryItem item)
    {
        sellDialog.GetComponent<SellDialog>().SetItem(item);
        sellDialog.SetActive(true);
    }

    public void CloseSellDialog()
    {
        sellDialog.GetComponent<SellDialog>().Cancel();
    }

    public void UpdateMoneyText(int amount)
    {
        moneyText.text = "$" + amount.ToString();
    }

}
