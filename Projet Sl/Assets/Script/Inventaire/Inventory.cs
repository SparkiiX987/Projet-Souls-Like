using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.UI;

public class Inventory : MonoBehaviour
{

    [SerializeField] private List<ItemContainer> inventoryGrid = new();
    [SerializeField] private GameObject Slots;
    [SerializeField] private GameObject SlotsPanel;
    private int i;

    public int slotsCount;
    public Item testItem;


    private void Start()
    {
        gameObject.SetActive(false);
        for (int j = 0; j < slotsCount; j++)
        {
            GameObject go = Instantiate(Slots, SlotsPanel.transform);
            inventoryGrid.Add(go.GetComponent<ItemContainer>());
        }
    }

    public bool TryAddItem(Item item)
    {
        for (i = 0; i < slotsCount; i++)
        {
            if (!inventoryGrid[i].HasItem())
            {
                return true;
            }
        }
        return false;
    }

    public void addItem(Item item)
    {
        if (TryAddItem(item))
        {
            inventoryGrid[i].item = item;
            inventoryGrid[i].itemImage.sprite = item.icon;
            inventoryGrid[i].imageUpdate();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T)) addItem(testItem);
    }
}
