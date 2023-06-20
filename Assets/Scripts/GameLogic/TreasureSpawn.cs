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
        spawnedItems = Instantiate(itemPrefab, Vector3.zero, Quaternion.identity);
        Vector2 randomForce = new Vector2(Random.Range(-200, 200), Random.Range(300, 500));
        float randomTorque = Random.Range(-100, 100);
        spawnedItems.GetComponent<Rigidbody2D>().AddForce(randomForce);
        spawnedItems.GetComponent<Rigidbody2D>().AddTorque(randomTorque);
    }
}
