using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{  
    private static UIManager _instance;
    public static UIManager instance {get{return _instance;}}

    [SerializeField]
    private GameObject inventoryItemsIcons;

    [SerializeField]
    private GameObject sellDialog;

    [SerializeField]
    private TextMeshProUGUI moneyText;

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
        moneyText.text = amount.ToString() + "$";
    }

}
