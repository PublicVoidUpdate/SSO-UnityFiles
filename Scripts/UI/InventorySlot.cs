using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class InventorySlot : MonoBehaviour, IPointerClickHandler
{
    public InventoryController InventoryController;
    //internal slot features
    public Image icon;
    public TextMeshProUGUI nametext;
    public TextMeshProUGUI count;
    public int Index;


    

    //incoming item and count vs existing
    public void set(slot inc)
    {
        icon.gameObject.SetActive(true);
        nametext.gameObject.SetActive(true);
        count.gameObject.SetActive(true);
        count.text = inc.slotcount.ToString();
        nametext.text = inc.slotitem.itemname;
        icon.sprite = inc.slotitem.sprite;
    }

    public void clear()
    {
        icon.sprite = null;
        icon.gameObject.SetActive(false);
        nametext.gameObject.SetActive(false);
        count.gameObject.SetActive(false);
    }

    
        public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
            InventoryController.buttonclickevent(true, Index);
        //else if (eventData.button == PointerEventData.InputButton.Middle)
        //    InventoryController.buttonclickevent(null, Index);
        else if (eventData.button == PointerEventData.InputButton.Right)
            InventoryController.buttonclickevent(false, Index);
    }
}
