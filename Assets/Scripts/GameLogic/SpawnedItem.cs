using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SpawnedItem : MonoBehaviour, IPointerEnterHandler
{
    public ItemsData itemData;
    [SerializeField]
    private SpriteRenderer itemSpriteRenderer;


    public void InitializeData(ItemsData data)
    {
        itemData = data;
        this.name = data.itemName;
        itemSpriteRenderer.sprite = data.itemSprite;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(Input.GetMouseButton(0))
        {
            InventoryManager.instance.Add(itemData);
            Destroy(gameObject);
        }
    }
}
