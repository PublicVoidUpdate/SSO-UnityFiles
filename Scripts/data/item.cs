using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "data/Item")]
public class item : ScriptableObject
{
    //sprite name and stackability of item, latter needing energy will be added, and maybe durability
    public Sprite sprite;
    public bool stackable;
    public string itemname;
}
