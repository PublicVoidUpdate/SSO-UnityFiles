using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryController : MonoBehaviour
{
    public inventory inventory;
    public List<Button> InventoryButtons;
    public slot cursor;

    public GameObject cursorobject;
    public Image cursoricon;
    public TextMeshProUGUI cursornametext;
    public TextMeshProUGUI cursorcount;

    public void Update()
    {
        cursorobject.transform.position = Input.mousePosition;
    }

    public void buttonclickevent(bool left, int index)
    {
        if(left)
        {
            //stack item
            if((cursor.slotitem == inventory.slots[index].slotitem && cursor.slotitem.stackable) || inventory.slots[index].slotitem == null)
            {
                inventory.slots[index].slotcount += cursor.slotcount;
                inventory.slots[index].slotitem = cursor.slotitem;
                cursor.slotcount = 0;
                cursor.slotitem = null;
                
            }
            //switch item
            else if(cursor.slotitem != inventory.slots[index].slotitem || !cursor.slotitem.stackable)
            {
                slot temp = inventory.slots[index];
                inventory.slots[index] = cursor;
                cursor = temp;
                
            }
            else {
                Debug.LogWarning("Uninplemented inventory click condition");
            };
        } else{
                if((cursor.slotitem == inventory.slots[index].slotitem && cursor.slotitem.stackable) || inventory.slots[index].slotitem == null)
            {
                //drop one item from cursor
                inventory.slots[index].slotcount ++;
                cursor.slotcount --;
                if (cursor.slotcount <= 0)
                {
                    cursor.slotitem = null;
                }
                
            }

            else if(cursor.slotitem != inventory.slots[index].slotitem || !cursor.slotitem.stackable)
            {
                //switch if else
                slot temp = inventory.slots[index];
                inventory.slots[index] = cursor;
                cursor = temp;
                
            }
            else {
                Debug.LogWarning("Uninplemented inventory click condition");
            };
        }
        show();
        Debug.Log("Detected Mouse click, ran click functions and init");
    }

    public void Start()
    {
        //initialize slots and give them an index
        for (int i = 0; i < inventory.slots.Count; i++)
        {
            InventoryButtons[i].gameObject.GetComponent<InventorySlot>().Index = i;
        }
        show();
        Debug.Log("Inventory Slots initialized");
    }

    public void show()
    {
        //update slot image
        for (int i = 0; i < inventory.slots.Count; i++)
        {
            if(inventory.slots[i].slotitem == null)
            {
                InventoryButtons[i].gameObject.GetComponent<InventorySlot>().clear();
            }
            else
            {
                InventoryButtons[i].gameObject.GetComponent<InventorySlot>().set(inventory.slots[i]);
            }
        }

        if (cursor.slotitem != null)
        {
            cursoricon.gameObject.SetActive(true);
            cursoricon.sprite = cursor.slotitem.sprite;
            cursornametext.gameObject.SetActive(true);
            cursornametext.text = cursor.slotitem.itemname;
            cursorcount.gameObject.SetActive(true);
            cursorcount.text = cursor.slotcount.ToString();
        } else
        {
            cursoricon.gameObject.SetActive(false);
            cursornametext.gameObject.SetActive(false);
            cursorcount.gameObject.SetActive(false);
        }
    }
}