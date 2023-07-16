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
    private void Start() 
    {
        if(itemData.dropChance < 0.2f)
        {
            SoundManager2D.instance.PlaySFX("Crown Spawn");
        }
        else if(itemData.dropChance < 0.3f)
        {
            SoundManager2D.instance.PlaySFX("HappyTune");
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(Input.GetMouseButton(0))
        {
            SoundManager2D.instance.PlaySFX("Bop");
            InventoryManager.instance.Add(itemData);
            Destroy(gameObject);
        }
    }
}
