using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]

public class slot
{
    public int slotcount;
    public item slotitem;

}

[CreateAssetMenu(menuName = "data/Inventory")]
public class inventory : ScriptableObject
{
    public List<slot> slots;

    
}

