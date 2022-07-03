using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MouseItemData : MonoBehaviour //Make into singleton
{
    public Image ItemSprite;
    public Text ItemCount;
    public InventorySlot AssignedInventorySlot;

    void Awake()
    {
        ItemSprite.color = Color.clear;
        ItemCount.text = "";
    }

    public void UpdateMouseSlot(InventorySlot invSlot)
    {
        AssignedInventorySlot.AssignItem(invSlot);
        ItemSprite.sprite = invSlot.ItemData.Icon;
        ItemCount.text = invSlot.StackSize.ToString();
        ItemSprite.color = Color.white;
    }

    void Update()
    {
        if (AssignedInventorySlot.ItemData != null)
        {
            transform.position = Input.mousePosition;

            if (Input.GetMouseButtonDown(0) && !IsMouseOverUI())
            {
                ClearSlot();
            }
        }
    }

    public void ClearSlot()
    {
        AssignedInventorySlot.ClearSlot();
        ItemCount.text = "";
        ItemSprite.color = Color.clear;
        ItemSprite.sprite = null;
    }

    public static bool IsMouseOverUI()
    {
        PointerEventData eventDataCurrentPostion = new PointerEventData(EventSystem.current);
        eventDataCurrentPostion.position = Input.mousePosition;
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPostion, results);
        return results.Count > 0;
    }
}