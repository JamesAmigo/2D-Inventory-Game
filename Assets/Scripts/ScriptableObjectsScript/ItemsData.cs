using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Scriptable Objects/Item")]
public class ItemsData : ScriptableObject
{
    public string itemName;
    public Sprite itemSprite;
    public int itemValue;
    [Range(0, 1)]
    public float dropChance;
}
