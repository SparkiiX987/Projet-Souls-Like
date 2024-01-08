using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEditor.PackageManager;


public class inventoryManager : MonoBehaviour
{
    private ItemContainer LastItemContainer;
    private Item item = null;
    [SerializeField] Inventory inventory;
    [SerializeField] EventSystem eventSystem;
    [SerializeField] GraphicRaycaster m_Raycaster;
    private bool draging = false;
    [SerializeField] private GameObject DragNDrop;
    [SerializeField] private GameObject StatsDisplayer;


    private void Update()
    {
        StatsDisplayer.gameObject.SetActive(false);

        if (inventory.gameObject.activeInHierarchy)
        {
            Vector3 MousePos = Input.mousePosition;
            PointerEventData pointerEventData = new PointerEventData(eventSystem);
            pointerEventData.position = MousePos;

            DragNDrop.transform.position = MousePos;

            List<RaycastResult> results = new List<RaycastResult>();

            m_Raycaster.Raycast(pointerEventData, results);

            // if the mouse is in an element
            if (results.Count > 0)
            {
                GameObject result = results[0].gameObject;

                //stats displayer
                /*if ((result.tag == "Slots" && result.GetComponent<ItemContainer>().item != null) || (result.tag == "Equipement" && result.GetComponent<EquipementSlot>().item != result.GetComponent<EquipementSlot>().startingItem))
                {
                    StatsDisplayer.gameObject.SetActive(true);
                    StatsDisplayer.GetComponent<StatsDisplayer>().UpdatePosition();
                    StatsDisplayer.GetComponent<StatsDisplayer>().UpdateTexts(result.GetComponent<ItemContainer>().item);
                }
                else
                {
                    StatsDisplayer.gameObject.SetActive(false);
                }*/

                // drag and drop
                if (draging)
                {
                    LastItemContainer.GetComponent<ItemContainer>().itemImage.transform.SetParent(DragNDrop.transform);
                    DragNDrop.transform.position = MousePos;
                }

                // stop drag and drop
                else if (!draging && LastItemContainer != null)
                {
                    LastItemContainer.GetComponent<ItemContainer>().itemImage.transform.SetParent(LastItemContainer.transform);
                }

                // draging item from slot
                if (Input.GetMouseButtonDown(0) && ((result.tag == "Slots" && result.GetComponent<ItemContainer>().item != null)))
                {
                    GameObject itemContainer = result;
                    item = itemContainer.GetComponent<ItemContainer>().item;
                    LastItemContainer = itemContainer.GetComponent<ItemContainer>();
                    draging = true;
                    DragNDrop.transform.position = MousePos;
                }

                // mouse click off
                if (Input.GetMouseButtonUp(0) && draging)
                {
                    draging = false;

                    // if in a slot
                    if (result.tag == "Slots" && result.GetComponent<ItemContainer>().item == null)
                    {
                        SetItemInSlot(result, item);
                        SetItemInLastContainer(LastItemContainer);
                        item = null;
                    }

                    else if (result.tag == "Slots" && result.GetComponent<ItemContainer>().item != null)
                    {
                        SwitchItemSlots(result, LastItemContainer.gameObject);
                    }

                    // if not in slots
                    else
                    {
                        ItemReturn();
                        StatsDisplayer.gameObject.SetActive(false);
                    }
                }
            }
        }

        if (Input.GetMouseButtonUp(0) && draging)
        {
            ItemReturn();
        }
    }

    // methode that return item to his old slot
    private void ItemReturn()
    {
        LastItemContainer.gameObject.GetComponent<ItemContainer>().addItem(item);
        LastItemContainer.gameObject.GetComponent<ItemContainer>().imageUpdate();
        item = null;
        draging = false;
        LastItemContainer.GetComponent<ItemContainer>().itemImage.transform.SetParent(LastItemContainer.transform);
        LastItemContainer.GetComponent<ItemContainer>().itemImage.transform.position = LastItemContainer.transform.position;

    }

    // methode to set item in a slot
    private void SetItemInSlot(GameObject result, Item _item)
    {
        result.GetComponent<ItemContainer>().addItem(_item);
        result.GetComponent<ItemContainer>().imageUpdate();
    }

    private void SwitchItemSlots(GameObject item1, GameObject item2)
    {
        if ((item1.tag == "Slots" && item2.tag == "Slots"))
        {
            ItemReturn();
            Item item = item1.GetComponent<ItemContainer>().item;
            SetItemInSlot(item1, item2.GetComponent<ItemContainer>().item);
            SetItemInSlot(item2, item);
        }
        else
        {
            ItemReturn();
        }
    }

    // methode taht reset item in his last container
    private void SetItemInLastContainer(ItemContainer LastItemContainer)
    {
        LastItemContainer.item = null;
        LastItemContainer.GetComponent<ItemContainer>().imageUpdate();
        LastItemContainer.GetComponent<ItemContainer>().itemImage.transform.position = LastItemContainer.transform.position;
    }
}
