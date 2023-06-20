using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TreasureSpawn : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField]
    private GameObject spawnedItems;
    [SerializeField]
    private GameObject itemPrefab;
    [SerializeField]
    private List<ItemsData> itemsData;
    private Animator treasureAnim;


    private void Start() 
    {
        treasureAnim = GetComponent<Animator>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        PressTreasure();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        ReleaseTreasure();
    }

    public void PressTreasure()
    {
        treasureAnim.SetTrigger("Press");
    }

    public void ReleaseTreasure()
    {
        treasureAnim.SetTrigger("Release");
        foreach(ItemsData I in RandomItems())
        {
            InstantiateItem(itemPrefab, I);
        }
        
    }
    public List<ItemsData> RandomItems()
    {
        List<ItemsData> resultItems = new List<ItemsData>();
        foreach(ItemsData I in itemsData)
        {
            float random = Random.Range(0f, 1f);
            if(random <= I.dropChance)
            {
                resultItems.Add(I);
            }
        }
        return resultItems;
    }

    public void InstantiateItem(GameObject item, ItemsData data)
    {
        GameObject spawned = Instantiate(item, Vector3.zero, Quaternion.identity);
        spawned.GetComponent<SpawnedItem>().InitializeData(data);
        Vector2 randomForce = new Vector2(Random.Range(-200, 200), Random.Range(300, 500));
        float randomTorque = Random.Range(-100, 100);
        spawned.transform.SetParent(spawnedItems.transform);
        spawned.GetComponent<Rigidbody2D>().AddForce(randomForce);
        spawned.GetComponent<Rigidbody2D>().AddTorque(randomTorque);
    }
}
